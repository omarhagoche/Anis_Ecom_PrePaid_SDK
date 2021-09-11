using System;
using System.Collections.Generic;
using System.Text;

namespace PrePaid_SDK.Entities.DB.PrePaidCardsSystemDB.Inventory
{
	public class Data_SubCategories
	{
		public long SubCategoryID_PK { get; set; }
		public long CategoryID_FK { get; set; }
		public string SubCategoryCode { get; set; }
		public string SubCategoryName { get; set; }
		public string SubCategoryDescription { get; set; }
		public byte[] SubGategory_Logo { get; set; }
		public bool? SubCategory_Available { get; set; }
        public int UsageCounter { get; set; }
    }
}
