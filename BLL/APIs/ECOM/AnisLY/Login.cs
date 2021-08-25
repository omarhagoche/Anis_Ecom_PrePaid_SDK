using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Text.Json;
using PrePaid_SDK.Entities.ECOM.AnisLY.Token;

namespace PrePaid_SDK.BLL.APIs.ECOM.AnisLY
{
    public class Login : Login_Token
    {
        public Login()
        {

        }

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
                return JsonConvert.DeserializeObject<Response_Token>(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
