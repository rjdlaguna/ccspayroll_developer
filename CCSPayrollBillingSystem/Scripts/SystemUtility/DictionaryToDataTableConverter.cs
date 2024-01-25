using System;
using System.Collections.Generic;
using System.Data;

namespace CCSPayrollBillingSystem.Scripts.SystemUtility
{
    public class DictionaryToDataTableConverter
    {
        public DataTable ConvertToDataTable(List<Dictionary<string, object>> dataList)
        {
            DataTable dataTable = new DataTable();

            // If the list is empty, return an empty DataTable
            if (dataList == null || dataList.Count == 0)
                return dataTable;

            // Add columns to the DataTable based on the keys in the first non-empty dictionary
            Dictionary<string, object> firstNonEmptyDictionary = dataList.Find(d => d.Count > 0);
            if (firstNonEmptyDictionary == null)
                return dataTable;

            foreach (KeyValuePair<string, object> kvp in firstNonEmptyDictionary)
            {
                DataColumn column = new DataColumn(kvp.Key, kvp.Value?.GetType() ?? typeof(object));
                dataTable.Columns.Add(column);
            }

            // Ensure the DataTable has columns before creating a new row
            if (dataTable.Columns.Count == 0)
                return dataTable;

            // Add rows to the DataTable based on values in each dictionary
            foreach (var data in dataList)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (DataColumn column in dataTable.Columns)
                {
                    string columnName = column.ColumnName;
                    if (data.ContainsKey(columnName) && data[columnName] != null && data[columnName] != DBNull.Value)
                    {
                        dataRow[columnName] = data[columnName];
                    }
                    else
                    {
                        dataRow[columnName] = 0;
                    }
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}
