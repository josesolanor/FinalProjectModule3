using ApiWallet;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace TestClient.Specs
{
    [Binding]
    public class VerSaldoSteps
    {
        private WebApplicationFactory<Startup> _factory;
        private HttpClient client;
        private HttpResponseMessage response;

        [BeforeScenario]
        public void Initialize()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Given(@"Que soy un cliente http")]
        public void GivenQueSoyUnClienteHttp()
        {
            client = _factory.CreateClient();
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
            Assert.AreEqual(httpStatus, response.StatusCode);
        }
        
        [Then(@"Recibo el valor de mi saldo en un JSON con tamaño de cadena (.*)")]
        public async System.Threading.Tasks.Task ThenReciboElValorDeMiSaldoEnUnJSONConTamanoDeCadena(int number)
        {
            var result = JsonConvert.DeserializeObject<string[]>(await response.Content.ReadAsStringAsync());

            Assert.AreEqual(expected: number, actual: result.Length);
        }
    }
}
