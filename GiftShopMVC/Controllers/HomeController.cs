using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GiftShop.Models;
using Microsoft.AspNetCore.Mvc;
using GiftShopMVC.Models;
using Newtonsoft.Json;

namespace GiftShopMVC.Controllers
{
    public class HomeController:Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task <IActionResult> About()
        {
            var httpClient = _httpClientFactory.CreateClient();

            // pass through a dummy name
            var response = await httpClient
                .GetAsync($"https://localhost:44347/api/gifts/");

            if(response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<Gift>>(await response.Content.ReadAsStringAsync());
            }
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0,Location = ResponseCacheLocation.None,NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
