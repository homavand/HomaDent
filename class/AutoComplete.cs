using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dentistry
{
    public class AutoComplete
    {
        public AutoCompleteStringCollection AutoCompleteControl(string FieldName , string TableName  )
        {
            AutoCompleteStringCollection FieldCollection = new AutoCompleteStringCollection();

            
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.Text;
            objCommand.CommandText = "SELECT [" + FieldName + "] FROM [" + TableName + "] ";
           

            DataTable dataTable = new DataTable();
            System.Data.SqlClient.SqlDataAdapter sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
            sqlDataAdapter.SelectCommand = objCommand;
            sqlDataAdapter.Fill(dataTable);
            
            
            if(dataTable != null)
               if(dataTable.Rows.Count != 0)
                  for(int i =0 ;i<dataTable.Rows.Count ; i++)
                  {
                    DataRow DataRow = (DataRow)dataTable.Rows[i];
                    FieldCollection.Add(DataRow[FieldName].ToString());
                  }
        
            return FieldCollection;
           
        }
    }
}
