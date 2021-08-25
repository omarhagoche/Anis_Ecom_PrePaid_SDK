using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PrePaid_SDK.Entities.ECOM.AnisLY.Cards;

namespace PrePaid_SDK.BLL.APIs.ECOM.AnisLY
{
    public class Card
    {
        public Cards.Root GET_SubCategoryCards(string AccessToken, string subCategoryID)
        {
            try
            {
                var request = new RestSharp.RestRequest(RestSharp.Method.GET);
                request.AddHeader("Authorization", $"Bearer {AccessToken}");
                var Result = new HTTP.Requests().HttpRequest($"https://gateway-staging.anis.ly/api/consumers/v1/categories/{subCategoryID}", request);
                return JsonConvert.DeserializeObject<Cards.Root>(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
