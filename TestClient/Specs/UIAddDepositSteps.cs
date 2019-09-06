using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TestClient.Specs
{
    [Binding]
    public class UIAddDepositSteps
    {
        IWebDriver currentDriver;
        decimal data;
        string balanceData, newBalanceData;

        [Given(@"El monto de (.*) bolivianos")]
        public void GivenElMontoDeBolivianos(int number)
        {
            data = number;
        }

        [When(@"Navego a la pagina principal")]
        public void WhenNavegoALaPaginaPrincipal()
        {
            currentDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            {
                Url = "http://localhost:20001"
            };
        }

        [When(@"Hago click en el boton Depositar")]
        public void WhenHagoClickEnElBotonDepositar()
        {
            currentDriver.FindElement(By.Name("Depositar")).Click();
        }

        [When(@"Lleno el campo del monto a depositar")]
        public void WhenLlenoElCampoDelMontoADepositar()
        {
            System.Threading.Thread.Sleep(2000);
            balanceData = currentDriver.FindElement(By.Id("dataBalance")).GetAttribute("innerHTML");
            currentDriver.FindElement(By.Name("Amount")).SendKeys(data.ToString());

        }

        [When(@"Hago click en Aceptar")]
        public void WhenHagoClickEnAceptar()
        {
            currentDriver.FindElement(By.Name("Aceptar")).Click();
        }

        [Then(@"Se debe actualizar el saldo")]
        public void ThenSeDebeActualizaElSaldo()
        {
            System.Threading.Thread.Sleep(2000);

            newBalanceData = currentDriver.FindElement(By.Id("dataBalance")).GetAttribute("innerHTML");
            Assert.AreNotSame(balanceData, newBalanceData);
            Assert.That(currentDriver.FindElement(By.Id("dataBalance")).Displayed);
            currentDriver.Quit();
        }
    }
}
