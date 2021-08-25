using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using PrePaid_SDK.Entities.ECOM.AnisLY.Categories;

namespace PrePaid_SDK.BLL.APIs.ECOM.AnisLY
{
    public class Category
    {
        public Category()
        {

        }

        public Categories.Root GET(string AccessToken)
        {
            try
            {
                var request = new RestSharp.RestRequest(RestSharp.Method.GET);
                request.AddHeader("Authorization", $"Bearer {AccessToken}");
                var Result = new HTTP.Requests().HttpRequest("https://gateway-staging.anis.ly/api/consumers/v1/categories", request);
                return JsonConvert.DeserializeObject<Categories.Root>(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
