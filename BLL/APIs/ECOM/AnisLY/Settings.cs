using System;
using System.Collections.Generic;
using System.Text;

namespace PrePaid_SDK.BLL.APIs.ECOM.AnisLY
{
    public class Settings
    {

        public static Entities.ECOM.AnisLY.Token.Response_Token Response_Token = new Entities.ECOM.AnisLY.Token.Response_Token();
        public static Entities.DB.PrePaidCardsSystemDB.MyCompany.Data_APIConfigurations Configuration = new Entities.DB.PrePaidCardsSystemDB.MyCompany.Data_APIConfigurations();
        public static Entities.DB.PrePaidCardsSystemDB.SysPermistions.Workstations workstation = new Entities.DB.PrePaidCardsSystemDB.SysPermistions.Workstations();

        public enum ServiceLanguage
        {
            ar,
            en
        }
        public enum Services
        {
            Anis
        }
    }
}
