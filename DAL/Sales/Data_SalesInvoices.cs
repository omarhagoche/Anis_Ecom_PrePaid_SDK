using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PrePaid_SDK.DAL.Sales
{
    public class Data_SalesInvoices
    {
        SQL_Maneger sql = new SQL_Maneger();

        public Entities.DB.Entitie_StoredProcedure SP_UPs(Entities.DB.PrePaidCardsSystemDB.Sales.Data_SalesInvoices EntitySalesInvoice)
        {
            try
            {
                List<SqlParameter> Parameters = new List<SqlParameter>
                {
                     new SqlParameter("@SalesInvoiceID_PK", EntitySalesInvoice.SalesInvoiceID_PK),
                     new SqlParameter("@OrderID",EntitySalesInvoice.OrderID),
                     new SqlParameter("@SalesInvoiceCode",EntitySalesInvoice.SalesInvoiceCode),
                     new SqlParameter("@SalesInvoiceNumber",EntitySalesInvoice.SalesInvoiceNumber),
                     new SqlParameter("@CompanyID_FK", EntitySalesInvoice.CompanyID_FK),
                     new SqlParameter("@CardID_FK", EntitySalesInvoice.CardID_FK),
                     new SqlParameter("@CardName", EntitySalesInvoice.CardName),
                     new SqlParameter("@CurrencyID_FK", EntitySalesInvoice.CurrencyID_FK),
                     new SqlParameter("@CardCost", EntitySalesInvoice.CardCost),
                     new SqlParameter("@CardPrice", EntitySalesInvoice.CardPrice),
                     new SqlParameter("@ExpireDate", EntitySalesInvoice.ExpireDate),
                     new SqlParameter("@Card_SecretNumber", EntitySalesInvoice.Card_SecretNumber),
                     new SqlParameter("@Card_SerialNumber", EntitySalesInvoice.Card_SerialNumber),
                     new SqlParameter("@Note", EntitySalesInvoice.Note),
                     new SqlParameter("@CreatedByUserID", EntitySalesInvoice.CreatedByUserID),
                     new SqlParameter("@CreatedByUserName", EntitySalesInvoice.CreatedByUserName),

                };
                return sql.StoredProcedure("Sales.Data_SalesInvoices_Ups", Parameters, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
