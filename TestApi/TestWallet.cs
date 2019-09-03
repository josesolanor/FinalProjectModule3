using ApiWallet.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestApi
{


    [TestClass]
    public class TestWallet
    {
        private List<BalanceDTO> _balance;
        private ILogicMethods _logicMethods;

        public TestWallet(ILogicMethods logicMethods)
        {
            _balance = new List<BalanceDTO>
            {
                new BalanceDTO
                {
                    Type = "Deposit",
                    Amount = 100,
                    Date = DateTime.Today.AddDays(-2)
                },
                new BalanceDTO
                {
                    Type = "Withdraw ",
                    Amount = 50,
                    Date = DateTime.Today.AddDays(-1)
                }
            };
            _logicMethods = logicMethods;
        }

        [TestMethod]
        public void ShouldShowYourCurrentBalance()
        {
            var newTransaccion = new BalanceDTO
            {
                Type = "Withdraw ",
                Amount = 50,
                Date = DateTime.Today
            };

            _balance.Add(newTransaccion);
,                           
            var result = _logicMethods.ShowBalance(balance);

            Assert.Equals(result, 25);

        }

        [TestMethod]
        public void ShouldNotShowNegativeBalance()
        {

        }
        [TestMethod]
        public void ShouldAddIncomesToYourBalance()
        {

        }
        [TestMethod]
        public void ShouldWithdrawFundsFromYourBalance()
        {

        }
        [TestMethod]
        public void ShouldNotWithdrawNegativesFundsFromYourBalance()
        {

        }
    }
}
