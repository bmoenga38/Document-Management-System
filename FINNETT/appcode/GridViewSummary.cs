
using System;

public enum SummaryOperation { Sum, Avg, Count, Custom }

public delegate void CustomSummaryOperation(string column, string groupName, object value);

public delegate object SummaryResultMethod(string column, string groupName);

/// <summary>
/// A class that represents a summary operation defined to a column
/// </summary>
public class GridViewSummary
{
    #region Fields

    private readonly string _column;
    private readonly SummaryOperation _operation;
    private readonly CustomSummaryOperation _customOperation;
    private readonly SummaryResultMethod _getSummaryMethod;
    private GridViewGroup _group;
    private object _value;
    private string _formatString;
    private int _quantity;
    private bool _automatic;
    private bool _treatNullAsZero = true;

    #endregion Fields

    #region Properties

    public string Column => _column;

    public SummaryOperation Operation => _operation;

    public CustomSummaryOperation CustomOperation => _customOperation;

    public SummaryResultMethod GetSummaryMethod => _getSummaryMethod;

    public GridViewGroup Group => _group;

    public object Value => _value;

    public string FormatString
    {
        get { return _formatString; }
        set { _formatString = value; }
    }

    public int Quantity => _quantity;

    public bool Automatic
    {
        get { return _automatic; }
        set { _automatic = value; }
    }

    public bool TreatNullAsZero
    {
        get { return _treatNullAsZero; }
        set { _treatNullAsZero = value; }
    }

    #endregion Properties

    #region Constructors

    private GridViewSummary(string col, GridViewGroup grp)
    {
        _column = col;
        _group = grp;
        _value = null;
        _quantity = 0;
        _automatic = true;
        _treatNullAsZero = false;
    }

    public GridViewSummary(string col, string formatString, SummaryOperation op, GridViewGroup grp) : this(col, grp)
    {
        _formatString = formatString;
        _operation = op;
        _customOperation = null;
        _getSummaryMethod = null;
    }

    public GridViewSummary(string col, SummaryOperation op, GridViewGroup grp) : this(col, string.Empty, op, grp)
    {
    }

    public GridViewSummary(string col, string formatString, CustomSummaryOperation op, SummaryResultMethod getResult, GridViewGroup grp) : this(col, grp)
    {
        _formatString = formatString;
        _operation = SummaryOperation.Custom;
        _customOperation = op;
        _getSummaryMethod = getResult;
    }

    public GridViewSummary(string col, CustomSummaryOperation op, SummaryResultMethod getResult, GridViewGroup grp) : this(col, string.Empty, op, getResult, grp)
    {
    }

    #endregion Constructors

    internal void SetGroup(GridViewGroup g)
    {
        _group = g;
    }

    public bool Validate()
    {
        if (_operation == SummaryOperation.Custom)
        {
            return (_customOperation != null && _getSummaryMethod != null);
        }
        else
        {
            return (_customOperation == null && _getSummaryMethod == null);
        }
    }

    public void Reset()
    {
        _quantity = 0;
        _value = null;
    }

    public void AddValue(object newValue)
    {
        // Increment to (later) calc the Avg or for other calcs
        _quantity++;

        // Built-in backoffice
        if (_operation == SummaryOperation.Sum || _operation == SummaryOperation.Avg)
        {
            if (_value == null)
            {
                _value = newValue;
            }
            else
            {
                _value = PerformSum(_value, newValue);
            }
        }
        else
        {
            // Custom operation
            if (_customOperation != null)
            {
                // Call the custom operation
                if (_group != null)
                {
                    _customOperation(_column, _group.Name, newValue);
                }
                else
                {
                    _customOperation(_column, null, newValue);
                }
            }
        }
    }

    public void Calculate()
    {
        if (_operation == SummaryOperation.Avg)
        {
            _value = PerformDiv(_value, _quantity);
        }
        if (_operation == SummaryOperation.Count)
        {
            _value = _quantity;
        }
        else if (_operation == SummaryOperation.Custom)
        {
            if (_getSummaryMethod != null)
            {
                _value = _getSummaryMethod(_column, null);
            }
        }
        // if this.Operation == SummaryOperation.Avg
        // this.Value already contains the correct value
    }

    #region Built-in Summary backoffice

    private object PerformSum(object a, object b)
    {
        object zero = 0;

        if (a == null)
        {
            if (_treatNullAsZero)
            {
                a = 0;
            }
            else
            {
                return null;
            }
        }

        if (b == null)
        {
            if (_treatNullAsZero)
            {
                b = 0;
            }
            else
            {
                return null;
            }
        }

        if (a == null || a.ToString() == string.Empty)
        {
            a = 0;
        }

        if (b == null || b.ToString() == string.Empty)
        {
            b = 0;
        }
        // Convert to proper type before add
        switch (a.GetType().FullName)
        {
            case "System.Int16": return Convert.ToInt16(a) + Convert.ToInt16(b);
            case "System.Int32": return Convert.ToInt32(a) + Convert.ToInt32(b);
            case "System.Int64": return Convert.ToInt64(a) + Convert.ToInt64(b);
            case "System.UInt16": return Convert.ToUInt16(a) + Convert.ToUInt16(b);
            case "System.UInt32": return Convert.ToUInt32(a) + Convert.ToUInt32(b);
            case "System.UInt64": return Convert.ToUInt64(a) + Convert.ToUInt64(b);
            case "System.Single": return Convert.ToSingle(a) + Convert.ToSingle(b);
            case "System.Double": return Convert.ToDouble(a) + Convert.ToDouble(b);
            case "System.Decimal": return Convert.ToDecimal(a) + Convert.ToDecimal(b);
            case "System.Byte": return Convert.ToByte(a) + Convert.ToByte(b);
            case "System.String": return a.ToString() + b.ToString();
        }

        return null;
    }

    private object PerformDiv(object a, int b)
    {
        object zero = 0;

        if (a == null)
        {
            return (_treatNullAsZero ? zero : null);
        }

        // Don't raise an exception, just return null
        if (b == 0)
        {
            return null;
        }

        // Convert to proper type before div
        switch (a.GetType().FullName)
        {
            case "System.Int16": return Convert.ToInt16(a) / b;
            case "System.Int32": return Convert.ToInt32(a) / b;
            case "System.Int64": return Convert.ToInt64(a) / b;
            case "System.UInt16": return Convert.ToUInt16(a) / b;
            case "System.UInt32": return Convert.ToUInt32(a) / b;
            case "System.Single": return Convert.ToSingle(a) / b;
            case "System.Double": return Convert.ToDouble(a) / b;
            case "System.Decimal": return Convert.ToDecimal(a) / b;
            case "System.Byte": return Convert.ToByte(a) / b;
                // Operator '/' cannot be applied to operands of type 'ulong' and 'int'
                //case "System.UInt64": return Convert.ToUInt64(a) / b;
        }

        return null;
    }

    #endregion Built-in Summary backoffice
}