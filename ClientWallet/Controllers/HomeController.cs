﻿using System;
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

        public async Task<IActionResult> Index()
        {
            
            HttpResponseMessage responseMessage = await _api.GetBalance();
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

        public async Task<IActionResult> Privacy()
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