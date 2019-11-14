using ApiWallet;
using WalletCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using TechTalk.SpecFlow;
using TestClient.Mocks;

namespace TestClient.Specs
{
    [Binding]
    public class VerSaldoSteps
    {
        private WebApplicationFactory<Startup> _factory;
        private HttpClient client;
        private HttpResponseMessage response;

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

        [Given(@"Que soy un cliente http")]
        public void GivenQueSoyUnClienteHttp()
        {
            client = ConstructorWebHostBuilderConfigured().CreateClient();
        }

        [When(@"Hago un request GET hacia el url de mi saldo")]
        public async System.Threading.Tasks.Task WhenHagoUnRequestGETHaciaElUrlDeMiSaldo()
        {
            var url = "/api/Balances/Showbalance";
            response = await client.GetAsync(url);

        }

        [Then(@"Recibo una respuesta con http (.*)")]
        public void ThenReciboUnaRespuestaConHttp(int httpStatus)
        {
            Assert.AreEqual(httpStatus, (int)response.StatusCode);
        }

        [Then(@"Recibo el valor de mi saldo con valor (.*)")]
        public async System.Threading.Tasks.Task ThenReciboElValorDeMiSaldoEnUnJSONConTamanoDeCadena(int number)
        {
            var result = JsonConvert.DeserializeObject<decimal>(await response.Content.ReadAsStringAsync());

            Assert.AreEqual(expected: number, actual: result);
        }
    }
}