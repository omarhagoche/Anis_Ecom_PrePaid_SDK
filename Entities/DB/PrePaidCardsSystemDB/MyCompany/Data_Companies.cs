using System;
using System.Collections.Generic;
using System.Text;

namespace PrePaid_SDK.Entities.DB.PrePaidCardsSystemDB.MyCompany
{
	public class Data_Companies
	{
		public int CompanyID_PK { get; set; }
		public string CompanyName { get; set; }
		public string CompanyEnglishName { get; set; }
		public byte[] CompanyLogo { get; set; }
	}
}
