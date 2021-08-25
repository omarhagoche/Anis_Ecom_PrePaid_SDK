using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrePaid_SDK.BLL.HTTP
{
    public class Requests
    {
        public string HttpRequest(string URL, RestRequest RequestHeader)
        {
            try
            {
                var client = new RestClient(URL);
                client.Timeout = -1;
                IRestResponse response = client.Execute(RequestHeader);
                return response.Content;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
