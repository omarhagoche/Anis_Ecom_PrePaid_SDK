using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PrePaid_SDK.DAL.MyCompany
{
    public class Config_CompanyProfile
    {
        SQL_Maneger sql = new SQL_Maneger();

        public List<Entities.DB.PrePaidCardsSystemDB.MyCompany.Config_CompanyProfile> Select()
        {
            try
            {
                List<Entities.DB.PrePaidCardsSystemDB.MyCompany.Config_CompanyProfile> CompanyProfileList = new List<Entities.DB.PrePaidCardsSystemDB.MyCompany.Config_CompanyProfile>();
                var DT =  SQL_Maneger.GetDatatable("SELECT * FROM MyCompany.Config_CompanyProfile", sql.ServerConnectionString);
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow item in DT.Rows)
                    {
                        CompanyProfileList.Add(
                               new Entities.DB.PrePaidCardsSystemDB.MyCompany.Config_CompanyProfile()
                               {    ConfigurationID_PK = int.Parse(item["ConfigurationID_PK"].ToString()),
                                    CompanyID_FK = int.Parse(item["CompanyID_FK"].ToString()),
                                    ConfigurationCode = item["ConfigurationCode"].ToString(),
                                    ConfigurationValue = item["ConfigurationValue"].ToString()
                               }
                           );
                    }
                }

                return CompanyProfileList;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public Entities.DB.PrePaidCardsSystemDB.MyCompany.Config_CompanyProfile Select(int CompanyID_FK, string ConfigurationCode)
        {
            try
            {
                Entities.DB.PrePaidCardsSystemDB.MyCompany.Config_CompanyProfile CompanyProfile = new Entities.DB.PrePaidCardsSystemDB.MyCompany.Config_CompanyProfile();
                var DT = SQL_Maneger.GetDatatable($@"SELECT * FROM MyCompany.Config_CompanyProfile where CompanyID_FK={CompanyID_FK} AND ConfigurationCode=N'{ConfigurationCode}'", sql.ServerConnectionString);
                if (DT.Rows.Count > 0)
                {
                    CompanyProfile.ConfigurationID_PK = int.Parse(DT.Rows[0]["ConfigurationID_PK"].ToString());
                    CompanyProfile.CompanyID_FK = int.Parse(DT.Rows[0]["CompanyID_FK"].ToString());
                    CompanyProfile.ConfigurationCode = DT.Rows[0]["ConfigurationCode"].ToString();
                    CompanyProfile.ConfigurationValue = DT.Rows[0]["ConfigurationValue"].ToString();
                }

                return CompanyProfile;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Update(int CompanyID_FK, string ConfigurationCode,string ConfigurationValue)
        {
            try
            {
                sql.ExcuteQuery($@"UPDATE MyCompany.Config_CompanyProfile SET ConfigurationValue = N'{ConfigurationValue}' where CompanyID_FK={CompanyID_FK} AND ConfigurationCode=N'{ConfigurationCode}'");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
