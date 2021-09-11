using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PrePaid_SDK.DAL.Inventory
{
    public class Data_SubCategories
    {
        SQL_Maneger sql = new SQL_Maneger();

        public Entities.DB.Entitie_StoredProcedure SP_UPs(Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories EntitySubCategory)
        {
            try
            {
                List<SqlParameter> Parameters = new List<SqlParameter>
                {
                     new SqlParameter("@SubCategoryID_PK", EntitySubCategory.SubCategoryID_PK),
                     new SqlParameter("@CategoryID_FK",EntitySubCategory.CategoryID_FK),
                     new SqlParameter("@SubCategoryCode",EntitySubCategory.SubCategoryCode),
                     new SqlParameter("@SubCategoryName", EntitySubCategory.SubCategoryName),
                     new SqlParameter("@SubCategoryDescription", EntitySubCategory.SubCategoryDescription),
                     new SqlParameter("@SubCategory_Available", EntitySubCategory.SubCategory_Available),
                     new SqlParameter("@SubGategory_Logo", EntitySubCategory.SubGategory_Logo),
                     new SqlParameter("@UsageCounter", EntitySubCategory.UsageCounter)
                };
                return sql.StoredProcedure("Inventory.Data_SubCategories_Ups", Parameters, true);
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
                return SQL_Maneger.GetDatatable($@"Select * From Inventory.Data_SubCategories", sql.ServerConnectionString);
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

        public DataTable Select(long CategoryID_FK)
        {
            try
            {
                SQL_Maneger.ConnectToServer(sql.ServerConnectionString);
                return SQL_Maneger.GetDatatable($@"Select * From Inventory.Data_SubCategories where CategoryID_FK={CategoryID_FK}", sql.ServerConnectionString);
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

        public Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories Select_SubCategoryID_PK(long SubCategoryID_PK)
        {
            try
            {
                Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories SubCategory = new Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories();
                SQL_Maneger.ConnectToServer(sql.ServerConnectionString);
                var DT = SQL_Maneger.GetDatatable($@"Select * From Inventory.Data_SubCategories where SubCategoryID_PK={SubCategoryID_PK}", sql.ServerConnectionString);
                if (DT.Rows.Count > 0)
                {
                    SubCategory.SubCategoryID_PK = long.Parse(DT.Rows[0]["SubCategoryID_PK"].ToString());
                    SubCategory.CategoryID_FK = int.Parse(DT.Rows[0]["CategoryID_FK"].ToString());
                    SubCategory.UsageCounter = int.Parse(DT.Rows[0]["UsageCounter"].ToString());
                    SubCategory.SubCategory_Available = bool.Parse(DT.Rows[0]["SubCategory_Available"].ToString());
                    SubCategory.SubCategoryCode = DT.Rows[0]["SubCategoryCode"].ToString();
                    SubCategory.SubCategoryName = DT.Rows[0]["SubCategoryName"].ToString();
                    SubCategory.SubCategoryDescription = DT.Rows[0]["SubCategoryDescription"].ToString();
                    SubCategory.SubGategory_Logo = DT.Rows[0]["SubGategory_Logo"] as byte[];
                }

                return SubCategory;
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

        public void Update_UsageCounter(long SubCategoryID_PK,int UsageCounter)
        {
            try
            {
                sql.ExcuteQuery($@"UPDATE [Asarya_PrePaidCards_System].[Inventory].[Data_SubCategories]
                SET [UsageCounter] = {UsageCounter}
                WHERE [SubCategoryID_PK] = {SubCategoryID_PK}");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
