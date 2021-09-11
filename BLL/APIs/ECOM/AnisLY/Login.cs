using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Text.Json;
using PrePaid_SDK.Entities.ECOM.AnisLY.Token;
using System.Data;
using System.IO;

namespace PrePaid_SDK.BLL.APIs.ECOM.AnisLY
{
    public class Login : Login_Token
    {
        public Login()
        {

        }

        /// <summary>
        /// Get AccessToken
        /// </summary>
        /// <returns></returns>
        public Response_Token Access()
        {
            try
            {
                var request = new RestSharp.RestRequest(RestSharp.Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("grant_type", this.grant_type);
                request.AddParameter("client_id", this.client_id);
                request.AddParameter("client_secret", this.client_secret);
                request.AddParameter("password", this.password);
                request.AddParameter("email", this.email);
                var Result = new HTTP.Requests().HttpRequest("https://identity-staging.anis.ly/connect/token", request);
                if (Result.ToLower().Contains("error"))
                {
                    return new Response_Token()
                    {
                        completed = false,
                        access_token = Result
                    };
                }
                else
                {
                    return JsonConvert.DeserializeObject<Response_Token>(Result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get AccessToken Using RefreshToken
        /// </summary>
        /// <returns></returns>
        public Response_Token ReAccess(string RefreshToken)
        {
            try
            {
                var request = new RestSharp.RestRequest(RestSharp.Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("grant_type", this.grant_type);
                request.AddParameter("client_id", this.client_id);
                request.AddParameter("client_secret", this.client_secret);
                request.AddParameter("refresh_token", RefreshToken);
                var Result = new HTTP.Requests().HttpRequest("https://identity-staging.anis.ly/connect/token", request);
                if (Result.ToLower().Contains("error"))
                {
                    return new Response_Token()
                    {
                        completed = false,
                        access_token = Result
                    };
                }
                else
                {
                    return JsonConvert.DeserializeObject<Response_Token>(Result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void POST_Configuration()
        {
            try
            {
                Entities.DB.PrePaidCardsSystemDB.MyCompany.Data_APIConfigurations configurations = new Entities.DB.PrePaidCardsSystemDB.MyCompany.Data_APIConfigurations();
                configurations.CompanyID_FK = 1;
                configurations.Configuration_Value = JsonConvert.SerializeObject(this);
                configurations.ServiceLanguage = Settings.Configuration.ServiceLanguage;
                configurations.PINnumber_IsEnabled = Settings.Configuration.PINnumber_IsEnabled;
                configurations.PINnumber_Amount = Settings.Configuration.PINnumber_Amount;
                configurations.PINnumber = Settings.Configuration.PINnumber;
                configurations.BuyingPrice_IsEnabled = Settings.Configuration.BuyingPrice_IsEnabled;
                new DAL.MyCompany.Data_APIConfigurations().Insert(configurations);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Initialize_DB_Connection()
        {
            try
            {
                if (!String.IsNullOrEmpty(Entities.DB.PrePaidCardsSystemDB.ConnectionEntity.DBName))
                {
                    if (!Entities.DB.PrePaidCardsSystemDB.ConnectionEntity.IsWinAuth)
                    {
                        Entities.DB.PrePaidCardsSystemDB.ConnectionEntity.SqlConnection = $@"Data Source={Entities.DB.PrePaidCardsSystemDB.ConnectionEntity.DBServerName};Initial Catalog={Entities.DB.PrePaidCardsSystemDB.ConnectionEntity.DBName};Integrated Security=SSPI;User ID={Entities.DB.PrePaidCardsSystemDB.ConnectionEntity.DBUserName};Password={Entities.DB.PrePaidCardsSystemDB.ConnectionEntity.DBPassword};";
                    }
                    else
                    {
                        Entities.DB.PrePaidCardsSystemDB.ConnectionEntity.SqlConnection = $@"Server={Entities.DB.PrePaidCardsSystemDB.ConnectionEntity.DBServerName};Database={Entities.DB.PrePaidCardsSystemDB.ConnectionEntity.DBName};Integrated Security=SSPI;";
                    }

                    DAL.SQL_Maneger.ConnectToServer(new DAL.SQL_Maneger().ServerConnectionString); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Login_Token GET_API_Configuration()
        {
            try
            {
                DAL.MyCompany.Data_APIConfigurations DAL_configurations = new DAL.MyCompany.Data_APIConfigurations();
                var DT = DAL_configurations.Select(1);
                if (DT.Rows.Count > 0)
                {
                    return JsonConvert.DeserializeObject<Login_Token>(DT.Rows[0]["Configuration_Value"].ToString());
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GET_API_Language()
        {
            try
            {
                DAL.MyCompany.Data_APIConfigurations DAL_configurations = new DAL.MyCompany.Data_APIConfigurations();
                var DT = DAL_configurations.Select(1);
                if (DT.Rows.Count > 0)
                {
                    return DT.Rows[0]["ServiceLanguage"].ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entities.DB.PrePaidCardsSystemDB.MyCompany.Data_APIConfigurations GET_CurrentService_Configuration(int CompanyID)
        {
            try
            {
                Entities.DB.PrePaidCardsSystemDB.MyCompany.Data_APIConfigurations configuration = new Entities.DB.PrePaidCardsSystemDB.MyCompany.Data_APIConfigurations();
                DAL.MyCompany.Data_APIConfigurations DAL_configurations = new DAL.MyCompany.Data_APIConfigurations();
                var DT = DAL_configurations.Select(CompanyID);
                if (DT.Rows.Count > 0)
                {
                    configuration.ConfigurationID_PK = int.Parse(DT.Rows[0]["ConfigurationID_PK"].ToString());
                    configuration.CompanyID_FK = int.Parse(DT.Rows[0]["CompanyID_FK"].ToString());
                    configuration.Configuration_Value = DT.Rows[0]["Configuration_Value"].ToString();
                    configuration.ServiceLanguage =  DT.Rows[0]["ServiceLanguage"].ToString();
                    configuration.PINnumber_IsEnabled = bool.Parse(DT.Rows[0]["PINnumber_IsEnabled"].ToString());
                    configuration.PINnumber_Amount = int.Parse(DT.Rows[0]["PINnumber_Amount"].ToString());
                    configuration.PINnumber = int.Parse(DT.Rows[0]["PINnumber"].ToString());
                    configuration.BuyingPrice_IsEnabled = bool.Parse(DT.Rows[0]["BuyingPrice_IsEnabled"].ToString());
                }
                return configuration;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UPDATE_API_Language(string ServiceLanguageCode)
        {
            try
            {
                DAL.MyCompany.Data_APIConfigurations DAL_configurations = new DAL.MyCompany.Data_APIConfigurations();
                DAL_configurations.Update(ServiceLanguageCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entities.DB.PrePaidCardsSystemDB.MyCompany.Data_Companies> GET_Companies()
        {
            try
            {

                List<Entities.DB.PrePaidCardsSystemDB.MyCompany.Data_Companies> list = new List<Entities.DB.PrePaidCardsSystemDB.MyCompany.Data_Companies>();

                DAL.MyCompany.Data_Companies companies = new DAL.MyCompany.Data_Companies();
                var DT = companies.Select();
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow Company in DT.Rows)
                    {
                        list.Add(
                            new Entities.DB.PrePaidCardsSystemDB.MyCompany.Data_Companies()
                            {
                                CompanyID_PK = int.Parse(Company["CompanyID_PK"].ToString()),
                                CompanyName = Company["CompanyName"].ToString(),
                                CompanyEnglishName = Company["CompanyEnglishName"].ToString(),
                                CompanyLogo = Company["CompanyLogo"] as byte[]
                            }
                        );
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entities.DB.PrePaidCardsSystemDB.MyCompany.Config_CompanyProfile> GET_CompaniesProfiles()
        {
            try
            {
                DAL.MyCompany.Config_CompanyProfile DAL_Profile = new DAL.MyCompany.Config_CompanyProfile();
                return DAL_Profile.Select();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entities.DB.PrePaidCardsSystemDB.MyCompany.Config_CompanyProfile GET_CompanyProfile(int CompanyID_FK,string ConfigurationCode)
        {
            try
            {
                DAL.MyCompany.Config_CompanyProfile DAL_Profile = new DAL.MyCompany.Config_CompanyProfile();
                return DAL_Profile.Select(CompanyID_FK, ConfigurationCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_CompanyProfile(int CompanyID_FK, string ConfigurationCode, string ConfigurationValue)
        {
            try
            {
                DAL.MyCompany.Config_CompanyProfile DAL_Profile = new DAL.MyCompany.Config_CompanyProfile();
                DAL_Profile.Update(CompanyID_FK, ConfigurationCode, ConfigurationValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
