//------------------------------------------------------------------------------------------
// Copyright © 2006 Agrinei Sousa [www.agrinei.com]
//
// Esse código fonte é fornecido sem garantia de qualquer tipo.
// Sinta-se livre para utilizá-lo, modificá-lo e distribuí-lo,
// inclusive em aplicações comerciais.
// É altamente desejável que essa mensagem não seja removida.
//------------------------------------------------------------------------------------------

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public delegate void GroupEvent(string groupName, object[] values, GridViewRow row);

/// <summary>
/// A class that represents a group consisting of a set of columns
/// </summary>
public class GridViewGroup
{
    #region Fields

    private readonly string[] _columns;
    private object[] _actualValues;
    private int _quantity;
    private bool _automatic;
    private bool _hideGroupColumns;
    private readonly bool _isSuppressGroup;
    private bool _generateAllCellsOnSummaryRow;
    private GridViewSummaryList mSummaries;

    #endregion Fields

    #region Properties

    public string[] Columns => _columns;

    public object[] ActualValues => _actualValues;

    public int Quantity => _quantity;

    public bool Automatic
    {
        get { return _automatic; }
        set { _automatic = value; }
    }

    public bool HideGroupColumns
    {
        get { return _hideGroupColumns; }
        set { _hideGroupColumns = value; }
    }

    public bool IsSuppressGroup => _isSuppressGroup;

    public bool GenerateAllCellsOnSummaryRow
    {
        get { return _generateAllCellsOnSummaryRow; }
        set { _generateAllCellsOnSummaryRow = value; }
    }

    public string Name => string.Join("+", _columns);

    public GridViewSummaryList Summaries => mSummaries;

    #endregion Properties

    #region Constructors

    public GridViewGroup(string[] cols, bool isSuppressGroup, bool auto, bool hideGroupColumns, bool generateAllCellsOnSummaryRow)
    {
        mSummaries = new GridViewSummaryList();
        _actualValues = null;
        _quantity = 0;
        _columns = cols;
        _isSuppressGroup = isSuppressGroup;
        _automatic = auto;
        _hideGroupColumns = hideGroupColumns;
        _generateAllCellsOnSummaryRow = generateAllCellsOnSummaryRow;
    }

    public GridViewGroup(string[] cols, bool auto, bool hideGroupColumns, bool generateAllCellsOnSummaryRow) : this(cols, false, auto, hideGroupColumns, generateAllCellsOnSummaryRow)
    {
    }

    public GridViewGroup(string[] cols, bool auto, bool hideGroupColumns) : this(cols, auto, hideGroupColumns, false)
    {
    }

    #endregion Constructors

    internal void SetActualValues(object[] values)
    {
        _actualValues = values;
    }

    public bool ContainsSummary(GridViewSummary s)
    {
        return mSummaries.Contains(s);
    }

    public void AddSummary(GridViewSummary s)
    {
        if (ContainsSummary(s))
        {
            throw new Exception("Summary already exists in this group.");
        }

        if (!s.Validate())
        {
            throw new Exception("Invalid summary.");
        }

        ///s._group = this;
        s.SetGroup(this);
        mSummaries.Add(s);
    }

    public void Reset()
    {
        _quantity = 0;

        foreach (GridViewSummary s in mSummaries)
        {
            s.Reset();
        }
    }

    public void AddValueToSummaries(object dataitem)
    {
        _quantity++;

        foreach (GridViewSummary s in mSummaries)
        {
            s.AddValue(DataBinder.Eval(dataitem, s.Column));
        }
    }

    public void CalculateSummaries()
    {
        foreach (GridViewSummary s in mSummaries)
        {
            s.Calculate();
        }
    }
}