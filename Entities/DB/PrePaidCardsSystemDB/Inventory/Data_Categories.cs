using System;
using System.Collections.Generic;
using System.Text;

namespace PrePaid_SDK.Entities.DB.PrePaidCardsSystemDB.Inventory
{
	public class Data_Categories
	{
		public long CategoryID_PK { get; set; }
		public int CompanyID_FK { get; set; }
		public string CategoryCode { get; set; }
		public string CategoryName { get; set; }
		public string CategoryDescription { get; set; }
		public byte[] Category_Logo { get; set; }
		public bool? Category_Available { get; set; }
	}
}
