namespace FINNETT.data
{
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="ListToDataTable" />
    /// </summary>
    public class ListToDataTable
    {
        /// <summary>
        /// The ConvertListToDataTable
        /// </summary>
        /// <param name="list">The list<see cref="List{string[]}"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (string[] array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (string[] array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }
    }
}