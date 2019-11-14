using ApiWallet;
using WalletCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;
using TestClient.Mocks;


namespace TestClient.Specs
{
    [Binding]
    public class AddTransactionSteps
    {
        private WebApplicationFactory<Startup> _factory;
        private HttpClient client;
        private HttpResponseMessage response;
        private object options;

        [BeforeScenario(Order = 1)]
        public void Initialize()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [BeforeScenario(Order = 2)]
        public WebApplicationFactory<Startup> ConstructorWebHostBuilderConfigured()
        {
            return _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IRepositoryBalance, ShowBalanceMock>();
                });
            });
        }

        [Given(@"Que soy un cliente no humano http")]
        public void GivenQueSoyUnClienteNoHumanoHttp()
        {
            client = ConstructorWebHostBuilderConfigured().CreateClient();
        }

        [When(@"Cargo los datos de TYPE '(.*)' AMOUNT (.*)")]
        public void WhenCargoLosDatosDeTYPEAMOUNT(string type, int amount)
        {
            options = new
            {
                type = type,
                amount = amount
            };
        }

        [When(@"Hago un request POST hacia el url de realizar transaccion")]
        public async System.Threading.Tasks.Task WhenHagoUnRequestPOSTHaciaElUrlDeRealizarTransaccionAsync()
        {
            var url = "/api/Balances";

            var stringData = JsonConvert.SerializeObject(options);
            var content = new StringContent(stringData, Encoding.UTF8, "application/json");

            HttpContent data = content;

            response = await client.PostAsync(url, data);
        }

        [Then(@"Recibo una respuesta con el valor http (.*)")]
        public void ThenReciboUnaRespuestaConElValorHttp(int httpStatus)
        {
            Assert.AreEqual(httpStatus, (int)response.StatusCode);
        }
    }
}
