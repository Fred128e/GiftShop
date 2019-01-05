﻿using System;
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
    public class GirlGiftsController : Controller
    {
        private readonly IGiftRepository _iGiftRepository;
        private readonly GiftShopDbContext _context;

        public GirlGiftsController(GiftShopDbContext context,IGiftRepository giftRepository)
        {
            _context = context;
            _iGiftRepository = giftRepository;
        }

        // GET: GirlGifts
        public IActionResult Index(int id)
        {
            var gifts = _iGiftRepository.GetGenderGift(2).Result;
            return View(gifts);

        }

        // GET: GirlGifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftViewModel = await _context.Gift
                .FirstOrDefaultAsync(m => m.GiftId == id);
            if (giftViewModel == null)
            {
                return NotFound();
            }

            return View(giftViewModel);
        }

        // GET: GirlGifts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GirlGifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GiftId,Title,Description,CreationDate,GenderId")] GiftViewModel giftViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giftViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giftViewModel);
        }

        // GET: GirlGifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftViewModel = await _context.Gift.FindAsync(id);
            if (giftViewModel == null)
            {
                return NotFound();
            }
            return View(giftViewModel);
        }

        // POST: GirlGifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GiftId,Title,Description,CreationDate,GenderId")] GiftViewModel giftViewModel)
        {
            if (id != giftViewModel.GiftId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giftViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiftViewModelExists(giftViewModel.GiftId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(giftViewModel);
        }

        // GET: GirlGifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftViewModel = await _context.Gift
                .FirstOrDefaultAsync(m => m.GiftId == id);
            if (giftViewModel == null)
            {
                return NotFound();
            }

            return View(giftViewModel);
        }

        // POST: GirlGifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giftViewModel = await _context.Gift.FindAsync(id);
            _context.Gift.Remove(giftViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiftViewModelExists(int id)
        {
            return _context.Gift.Any(e => e.GiftId == id);
        }
    }
}
