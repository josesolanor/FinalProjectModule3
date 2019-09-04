using ClientWallet.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientWallet.Services
{
    public class WalletApi
    {
        ClientConfig _api;

        public WalletApi()
        {
            _api = new ClientConfig();
        }

        public HttpResponseMessage AddTransaction(Balance data)
        {
            HttpClient client = _api.Initial();

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, $"" + client.BaseAddress + "api/Balances");

                var options = new
                {
                    type = data.Type,
                    amount = data.Amount
                };

                var stringData = JsonConvert.SerializeObject(options);
                var content = new StringContent(stringData, Encoding.UTF8, "application/json");
                requestMessage.Content = new StringContent(stringData, Encoding.UTF8, "application/json");
                response = client.SendAsync(requestMessage).Result;
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                Console.WriteLine(ex);
                return response;
            }
        }

        public async Task<HttpResponseMessage> GetWallet()
        {
            HttpClient client = _api.Initial();

            try
            {
                HttpResponseMessage res = await client.GetAsync("api/Balances");
                return res;
            }
            catch (Exception)
            {
                HttpResponseMessage message = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
                return message;
            }
        }

        public async Task<HttpResponseMessage> GetBalance()
        {
            HttpClient client = _api.Initial();

            try
            {
                HttpResponseMessage res = await client.GetAsync("api/Balances/Showbalance");
                return res;
            }
            catch (Exception)
            {
                HttpResponseMessage message = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
                return message;
            }
        }
    }
}
