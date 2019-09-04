using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientWallet.Models;
using System.Net.Http;
using ClientWallet.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ClientWallet.Controllers
{
    public class HomeController : Controller
    {
        WalletApi _api;
        List<Wallet> walletList;

        public HomeController()
        {
            _api = new WalletApi();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Balance()
        {
            string result = "";

            HttpResponseMessage responseMessage = await _api.GetBalance();
            if (responseMessage.IsSuccessStatusCode)
            {
                result = responseMessage.Content.ReadAsStringAsync().Result;

                return Json(result);
            }
            else
            {
                ViewBag.Message = "Error en el servidor.";
                return Json(result);
            }
            
        }

        [HttpPost]
        public IActionResult AddDeposit(Balance balance)
        {
            balance.Type = TransactionType.Deposit;
            HttpResponseMessage responseMessage = _api.AddTransaction(balance);

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;

                TempData["Msg"] = $"Deposito realizado correctamente, Monto:{balance.Amount}";
                return RedirectToAction("Index");
            }
            else
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                var jsonResult = JsonConvert.DeserializeObject(result);
                TempData["ApiMsg"] = jsonResult;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult AddWithdraw(Balance balance)
        {
            balance.Type = TransactionType.WithDraw;
            HttpResponseMessage responseMessage = _api.AddTransaction(balance);

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;

                TempData["Msg"] = $"Retiro realizado correctamente, Monto:{balance.Amount}";
                return RedirectToAction("Index");
            }
            else
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                var jsonResult = JsonConvert.DeserializeObject(result);
                TempData["ApiMsg"] = jsonResult;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Wallet()
        {
            HttpResponseMessage responseMessage = await _api.GetWallet();
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                walletList = JsonConvert.DeserializeObject<List<Wallet>>(result);
                return View(walletList);
            }
            else
            {
                ViewBag.Message = "Error en el servidor.";
                return View(walletList);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
