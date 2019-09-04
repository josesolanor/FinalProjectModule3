using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ClientWallet.Services
{
    public class ClientConfig
    {

        public HttpClient Initial()
        {

            var Host = Environment.GetEnvironmentVariable("SERVICE");
            var Port = Environment.GetEnvironmentVariable("SERVICE_PORT");
            var Client = new HttpClient();

            if (Host is null || Port is null)
            {
                Client = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:20002/")
                };
                
            }
            else
            {
                Client = new HttpClient
                {
                    BaseAddress = new Uri($"http://{Host}:{Port}/")
                };
            }
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return Client;          
        }
    }
}
