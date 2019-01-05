using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GiftShopMVC.Data;
using GiftShopMVC.Models;
using GiftShopMVC.Services;

namespace GiftShopMVC.Controllers
{
    public class GiftsHomeController : Controller
    {
        private readonly IGiftRepository _iGiftRepository;
        private readonly GiftShopDbContext _context;

        public GiftsHomeController(GiftShopDbContext context, IGiftRepository giftRepository)
        {
            _context = context;
            _iGiftRepository = giftRepository;
        }

        // GET: GiftsHome
        public IActionResult Index()
        {
            var gifts = _iGiftRepository.GetGifts().Result;
            return View(gifts);
        }

        // GET: GiftsHome/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GiftsHome/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("GiftId,Title,Description,CreationDate,GenderId")] GiftViewModel giftViewModel)
        {
            if (!ModelState.IsValid)
            {
                _iGiftRepository.AddGift(giftViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(giftViewModel);
        }

        private bool GiftViewModelExists(int id)
        {
            return _context.Gift.Any(e => e.GiftId == id);
        }
    }
}
