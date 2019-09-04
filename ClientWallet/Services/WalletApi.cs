using ClientWallet.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            HttpResponseMessage message = new HttpResponseMessage();
            return message;
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

        public HttpResponseMessage GetBalance()
        {
            HttpResponseMessage message = new HttpResponseMessage();
            return message;
        }
    }
}
