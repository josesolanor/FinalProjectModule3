using ApiWallet.Core;
using ApiWallet.Interfaces;
using ApiWallet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestApi
{


    [TestClass]
    public class TestWallet
    {
        
        public LogicMethods logicMethods = new LogicMethods();

        [TestMethod]
        public void ShouldShowYourCurrentBalance()
        {
            List<BalanceDTO> _balance = new List<BalanceDTO>
            {
                new BalanceDTO
                {
                    Type = "Deposit",
                    Amount = 100,
                    Date = DateTime.Today
                },
                new BalanceDTO
                {
                    Type = "WithDraw",
                    Amount = 50,
                    Date = DateTime.Today
                },
                new BalanceDTO
                {
                    Type = "WithDraw",
                    Amount = 25,
                    Date = DateTime.Today
                }
            };

            var result = logicMethods.ShowBalance(_balance);

            Assert.AreEqual(25, result);
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
