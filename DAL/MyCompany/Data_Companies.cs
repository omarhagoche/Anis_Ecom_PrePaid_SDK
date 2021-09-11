using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PrePaid_SDK.DAL.MyCompany
{
    public class Data_Companies
    {
        SQL_Maneger sql = new SQL_Maneger();

        public DataTable Select()
        {
            try
            {
                SQL_Maneger.ConnectToServer(sql.ServerConnectionString);
                return SQL_Maneger.GetDatatable($@"
                SELECT * FROM MyCompany.Data_Companies", sql.ServerConnectionString);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                SQL_Maneger.DisconnectToServer(sql.ServerConnectionString);
            }
        }
    }
}
