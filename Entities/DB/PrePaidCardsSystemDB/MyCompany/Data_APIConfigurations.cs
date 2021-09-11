using System;
using System.Collections.Generic;
using System.Text;

namespace PrePaid_SDK.Entities.DB.PrePaidCardsSystemDB.MyCompany
{
	public class Data_APIConfigurations
	{
		public int ConfigurationID_PK { get; set; }
		public int CompanyID_FK { get; set; }
		public string Configuration_Value { get; set; }
        public string ServiceLanguage { get; set; }
        public bool PINnumber_IsEnabled { get; set; }
        public int PINnumber_Amount { get; set; }
		public int PINnumber { get; set; }
		public bool BuyingPrice_IsEnabled { get; set; }

	}
}
