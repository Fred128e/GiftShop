using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GiftShopMVC.Models;
using GiftShopMVC.Services;

namespace GiftShopMVC.Controllers
{
    public class HomeController:Controller
    {
        private readonly IGiftRepository _iGiftRepository;
        public HomeController(IGiftRepository giftRepository)
        {
            _iGiftRepository = giftRepository;
        }
        public IActionResult Index()
        {
            var gifts = _iGiftRepository.GetGifts().Result;
            return View(gifts);
        }

        public IActionResult GetGenderGifts(int id)
        {
            var gifts = _iGiftRepository.GetGenderGift(2).Result;
            return View(gifts);
        }

        public IActionResult CreateGift([FromForm] GiftViewModel gift)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var gifts= _iGiftRepository.AddGift(gift);
            return View(gifts);
        }

        [ResponseCache(Duration = 0,Location = ResponseCacheLocation.None,NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
