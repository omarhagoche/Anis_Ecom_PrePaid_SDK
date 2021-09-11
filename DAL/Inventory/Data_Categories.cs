using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PrePaid_SDK.DAL.Inventory
{
    public class Data_Categories
    {
        SQL_Maneger sql = new SQL_Maneger();

        public Entities.DB.Entitie_StoredProcedure SP_UPs(Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Categories EntityCategory)
        {
            try
            {
                List<SqlParameter> Parameters = new List<SqlParameter>
                {
                     new SqlParameter("@CategoryID_PK", EntityCategory.CategoryID_PK),
                     new SqlParameter("@CompanyID_FK",EntityCategory.CompanyID_FK),
                     new SqlParameter("@CategoryCode",EntityCategory.CategoryCode),
                     new SqlParameter("@CategoryName", EntityCategory.CategoryName),
                     new SqlParameter("@CategoryDescription", EntityCategory.CategoryDescription),
                     new SqlParameter("@Category_Available", EntityCategory.Category_Available),
                     new SqlParameter("@Category_Logo", EntityCategory.Category_Logo),
                     new SqlParameter("@UsageCounter", EntityCategory.UsageCounter)
                };
                return sql.StoredProcedure("Inventory.Data_Categories_Ups", Parameters,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select()
        {
            try
            {
                SQL_Maneger.ConnectToServer(sql.ServerConnectionString);
                return SQL_Maneger.GetDatatable($@"Select * From Inventory.Data_Categories", sql.ServerConnectionString);
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

        public Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Categories Select(long CategoryID_PK)
        {
            try
            {
                Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Categories category = new Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Categories();
                SQL_Maneger.ConnectToServer(sql.ServerConnectionString);
                var DT = SQL_Maneger.GetDatatable($@"Select * From Inventory.Data_Categories where [CategoryID_PK] = {CategoryID_PK}", sql.ServerConnectionString);
                if (DT.Rows.Count > 0)
                {
                    category.CategoryID_PK = long.Parse(DT.Rows[0]["CategoryID_PK"].ToString());
                    category.CompanyID_FK = int.Parse(DT.Rows[0]["CompanyID_FK"].ToString());
                    category.UsageCounter = int.Parse(DT.Rows[0]["UsageCounter"].ToString());
                    category.Category_Available = bool.Parse(DT.Rows[0]["Category_Available"].ToString());
                    category.CategoryCode = DT.Rows[0]["CategoryCode"].ToString();
                    category.CategoryName = DT.Rows[0]["CategoryName"].ToString();
                    category.CategoryDescription = DT.Rows[0]["CategoryDescription"].ToString();
                    category.Category_Logo = DT.Rows[0]["Category_Logo"] as byte[];
                }

                return category;
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

        public void Update_UsageCounter(long CategoryID_PK, int UsageCounter)
        {
            try
            {
                sql.ExcuteQuery($@"UPDATE [Asarya_PrePaidCards_System].[Inventory].[Data_Categories]
                SET [UsageCounter] = {UsageCounter}
                WHERE [CategoryID_PK] = {CategoryID_PK}");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
