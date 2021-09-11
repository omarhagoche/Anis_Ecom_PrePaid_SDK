using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PrePaid_SDK.DAL.Inventory
{
    public class Data_Cards
    {
        SQL_Maneger sql = new SQL_Maneger();

        public Entities.DB.Entitie_StoredProcedure SP_UPs(Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Cards EntityCard)
        {
            try
            {
                List<SqlParameter> Parameters = new List<SqlParameter>
                {
                     new SqlParameter("@CardID_PK", EntityCard.CardID_PK),
                     new SqlParameter("@CardCode",EntityCard.CardCode),
                     new SqlParameter("@CardName",EntityCard.CardName),
                     new SqlParameter("@CardArabicName", EntityCard.CardArabicName),
                     new SqlParameter("@CardEnglishName", EntityCard.CardEnglishName),
                     new SqlParameter("@SubCategoryID_FK", EntityCard.SubCategoryID_FK),
                     new SqlParameter("@CurrencyTypeID_FK", EntityCard.CurrencyTypeID_FK),
                     new SqlParameter("@CardCost", EntityCard.CardCost),
                     new SqlParameter("@CardFaceValue", EntityCard.CardFaceValue),
                     new SqlParameter("@CardPrintName", EntityCard.CardPrintName),
                     new SqlParameter("@CardNote", EntityCard.CardNote),
                     new SqlParameter("@Card_Available", EntityCard.Card_Available)
                };
                return sql.StoredProcedure("Inventory.Data_Cards_Ups", Parameters, true);
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
                return SQL_Maneger.GetDatatable($@"Select * From Inventory.Data_Cards", sql.ServerConnectionString);
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

        public DataTable Select(long SubCategoryID_FK)
        {
            try
            {
                SQL_Maneger.ConnectToServer(sql.ServerConnectionString);
                return SQL_Maneger.GetDatatable($@"Select * From Inventory.View_Data_Cards_With_Logos where SubCategoryID_FK={SubCategoryID_FK}", sql.ServerConnectionString);
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
