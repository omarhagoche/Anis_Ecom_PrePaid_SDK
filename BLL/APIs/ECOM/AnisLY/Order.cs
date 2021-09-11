using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using PrePaid_SDK.Entities.ECOM.AnisLY.Wallet;

namespace PrePaid_SDK.BLL.APIs.ECOM.AnisLY
{
    public class Order : Entities.ECOM.AnisLY.Wallet.Order
    {
        public Order_Response.Root POST_Order(string AccessToken)
        {
            try
            {
                var Json = JsonConvert.SerializeObject(this);
                var request = new RestSharp.RestRequest(RestSharp.Method.POST);
                request.AddHeader("Authorization", $"Bearer {AccessToken}");
                request.AddJsonBody(Json);
                var Result = new HTTP.Requests().HttpRequest($"https://gateway-staging.anis.ly/api/consumers/v1/order", request);
                return JsonConvert.DeserializeObject<Order_Response.Root>(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entities.DB.Entitie_StoredProcedure SP_UPs(Entities.DB.PrePaidCardsSystemDB.Sales.Data_SalesInvoices SalesInvoice)
        {
            try
            {
                DAL.Sales.Data_SalesInvoices DAL = new DAL.Sales.Data_SalesInvoices();
                return DAL.SP_UPs(SalesInvoice);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
