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
        public List<BalanceDTO> _balance;
        public LogicMethods logicMethods = new LogicMethods();

        public TestWallet()
        {
            _balance = new  List<BalanceDTO>
            {
                new BalanceDTO { Type = "Deposit", Amount = 100, Date = DateTime.Today.AddDays(-2) },
                new BalanceDTO { Type = "WithDraw", Amount = 50, Date = DateTime.Today.AddDays(-1) }
            };
        }

        [TestMethod]
        public void ShouldShowYourCurrentBalance()
        {
            _balance.Add(new BalanceDTO { Type = "WithDraw", Amount = 25, Date = DateTime.Today });

            var result = logicMethods.ShowBalance(_balance);

            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void ShouldNotShowNegativeBalance()
        {
            _balance.Add(new BalanceDTO { Type = "WithDraw", Amount = 125, Date = DateTime.Today });

            var result = logicMethods.ShowBalance(_balance);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ShouldAddIncomesToYourBalance()
        {
            var deposit = 100;

            var result = logicMethods.AddIncomes(_balance, deposit);

            Assert.IsTrue(result);
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
