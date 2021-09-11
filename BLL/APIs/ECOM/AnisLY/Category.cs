using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using PrePaid_SDK.Entities.ECOM.AnisLY.Categories;
using System.Data;

namespace PrePaid_SDK.BLL.APIs.ECOM.AnisLY
{
    public class Category
    {
        public Category()
        {

        }

        public Categories.Root GET(string AccessToken, string SelectedServiceLanguage)
        {
            try
            {
                var request = new RestSharp.RestRequest(RestSharp.Method.GET);
                request.AddHeader("Authorization", $"Bearer {AccessToken}");
                if (SelectedServiceLanguage == Settings.ServiceLanguage.ar.ToString())
                {
                    request.AddHeader("Accept-Language", $"{SelectedServiceLanguage}");
                }
                else if (SelectedServiceLanguage == Settings.ServiceLanguage.en.ToString())
                {
                    request.AddHeader("Accept-Language", $"{SelectedServiceLanguage}");
                }
                else
                {
                    request.AddHeader("Accept-Language", $"{SelectedServiceLanguage}");
                }
                var Result = new HTTP.Requests().HttpRequest("https://gateway-staging.anis.ly/api/consumers/v1/categories", request);
                return JsonConvert.DeserializeObject<Categories.Root>(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Categories> GET()
        {
            try
            {
                List<Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Categories> categoriesList = new List<Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Categories>();
                DAL.Inventory.Data_Categories DAL = new DAL.Inventory.Data_Categories();
                var DT = DAL.Select();
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow category in DT.Rows)
                    {
                        categoriesList.Add(
                            new Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Categories()
                            {
                                CategoryID_PK = int.Parse(category["CategoryID_PK"].ToString()),
                                CompanyID_FK = int.Parse(category["CompanyID_FK"].ToString()),
                                CategoryCode = category["CategoryCode"].ToString(),
                                CategoryName = category["CategoryName"].ToString(),
                                CategoryDescription = category["CategoryDescription"].ToString(),
                                Category_Logo = category["Category_Logo"] as byte[],
                                Category_Available = bool.Parse(category["Category_Available"].ToString()),
                                UsageCounter = int.Parse(category["UsageCounter"].ToString())
                            }
                        );
                    }

                    return categoriesList;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entities.DB.Entitie_StoredProcedure SP_UPs(Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Categories category)
        {
            try
            {
                DAL.Inventory.Data_Categories DAL = new DAL.Inventory.Data_Categories();
                return DAL.SP_UPs(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
