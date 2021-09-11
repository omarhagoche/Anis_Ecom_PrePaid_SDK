using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using PrePaid_SDK.Entities.ECOM.AnisLY.Cards;

namespace PrePaid_SDK.BLL.APIs.ECOM.AnisLY
{
    public class Card
    {
        public Cards.Root GET_SubCategoryCards(string AccessToken, string subCategoryID, string SelectedServiceLanguage)
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
                var Result = new HTTP.Requests().HttpRequest($"https://gateway-staging.anis.ly/api/consumers/v1/categories/{subCategoryID}", request);
                return JsonConvert.DeserializeObject<Cards.Root>(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Cards> GET_SubCategoryCards(long SubCategoryID_FK)
        {
            try
            {
                List<Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Cards> CardsList = new List<Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Cards>();
                DAL.Inventory.Data_Cards DAL = new DAL.Inventory.Data_Cards();
                var DT = DAL.Select(SubCategoryID_FK);
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow Card in DT.Rows)
                    {
                        CardsList.Add(
                            new Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Cards()
                            {
                                CardID_PK = int.Parse(Card["CardID_PK"].ToString()),
                                CardCode = Card["CardCode"].ToString(),
                                CardName = Card["CardName"].ToString(),
                                CardArabicName = Card["CardArabicName"].ToString(),
                                CardEnglishName = Card["CardEnglishName"].ToString(),
                                SubCategoryID_FK = Int64.Parse(Card["SubCategoryID_FK"].ToString()),
                                CurrencyTypeID_FK = int.Parse(Card["CurrencyTypeID_FK"].ToString()),
                                CardCost = double.Parse(Card["CardCost"].ToString()),
                                CardFaceValue = Card["CardFaceValue"].ToString(),
                                CardPrintName = Card["CardPrintName"].ToString(),
                                CardNote = Card["CardNote"].ToString(),
                                Card_Available = bool.Parse(Card["Card_Available"].ToString()),

                                SubGategory_Logo = Card["SubGategory_Logo"] as byte[],
                                SubCategoryCode = Card["SubCategoryCode"].ToString()
                            }
                        );
                    }

                    return CardsList;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entities.DB.Entitie_StoredProcedure SP_UPs(Entities.DB.PrePaidCardsSystemDB.Inventory.Data_Cards Card)
        {
            try
            {
                DAL.Inventory.Data_Cards DAL = new DAL.Inventory.Data_Cards();
                return DAL.SP_UPs(Card);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
