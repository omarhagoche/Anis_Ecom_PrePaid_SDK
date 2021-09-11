using System;
using System.Collections.Generic;
using System.Text;

namespace PrePaid_SDK.Entities.DB.PrePaidCardsSystemDB.Sales
{
	public class Data_SalesInvoices
	{
		public long SalesInvoiceID_PK { get; set; }
        public string OrderID { get; set; }
        public string SalesInvoiceCode { get; set; }
		public string SalesInvoiceNumber { get; set; }
		public int CompanyID_FK { get; set; }
		public long CardID_FK { get; set; }
		public string CardName { get; set; }
		public int CurrencyID_FK { get; set; }
		public decimal CardCost { get; set; }
		public double CardPrice { get; set; }
		public string ExpireDate { get; set; }
		public string Card_SecretNumber { get; set; }
		public string Card_SerialNumber { get; set; }
		public string Note { get; set; }
		public int CreatedByUserID { get; set; }
		public string CreatedByUserName { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
