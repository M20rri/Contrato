using Contrato.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Contrato.Service
{
    public class PayMob : IPayMob
    {
        private readonly Integration _integration;

        public PayMob(Integration integration)
        {
            _integration = integration;
        }

        public async Task<GenerateTokenVM> GenerateToken()
        {
            Integration body = new Integration
            {
                api_key = _integration.api_key
            };

            var client = new RestClient("https://accept.paymob.com/api/auth/tokens");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return JsonConvert.DeserializeObject<GenerateTokenVM>(response.Content);
            }
            throw new ApplicationException(response.Content);

        }

        public async Task<OrderRegistryResVM> ProductRegistration(OrderRegistryReqVM model)
        {
            var client = new RestClient("https://accept.paymob.com/api/ecommerce/orders");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(model), ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return JsonConvert.DeserializeObject<OrderRegistryResVM>(response.Content);
            }
            throw new ApplicationException(response.Content);
        }

        public async Task<PaymentKeyResVM> PaymentKey(PaymentKeyReqVM model)
        {
            model.integration_id = _integration.integration_id;

            var client = new RestClient("https://accept.paymob.com/api/acceptance/payment_keys");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(model), ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return JsonConvert.DeserializeObject<PaymentKeyResVM>(response.Content);
            }
            throw new ApplicationException(response.Content);
        }

       
    }
}
