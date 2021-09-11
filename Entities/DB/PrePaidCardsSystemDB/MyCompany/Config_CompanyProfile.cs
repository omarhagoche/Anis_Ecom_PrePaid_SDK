using System;
using System.Collections.Generic;
using System.Text;

namespace PrePaid_SDK.Entities.DB.PrePaidCardsSystemDB.MyCompany
{
    public class Config_CompanyProfile
    {
        public int ConfigurationID_PK { get; set; }
        public int CompanyID_FK { get; set; }
        public string ConfigurationCode { get; set; }
        public string ConfigurationValue { get; set; }
    }
}
