using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftShop.Models;

namespace GiftShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftsController : ControllerBase
    {
        private readonly GiftShopDbContext _context;

        public GiftsController(GiftShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Gifts
        [HttpGet]
        public IEnumerable<Gift> GetGift()
        {
            //var client = new HttpClient();
            //var baseurl = "https://localhost:44347/api/Gifts/gender{0}{1}{2}";
            //var uri = string.Format(baseurl, 2,2,3);
            ////HttpResponseMessage response = client.GetAsync(uri).Result;
            //if(response.IsSuccessStatusCode)
            //{
            //    var gits = response.Content.ReadAsAsync<List<Gift>>().Result;
            //    return gits;
            //}
            return _context.Gift;
        }

        // GET: api/Gifts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGift([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gift = await _context.Gift.FindAsync(id);

            if (gift == null)
            {
                return NotFound();
            }

            return Ok(gift);
        }

        [HttpGet("gender/{id}")]
        public IActionResult GetGenderGifts([FromRoute] int id)
        {
            var gifts = _context.Gift.Where(g => g.GenderId == id);
            if (gifts.ToList().Count == 0)
                return NotFound();
            return Ok(gifts.ToList());
           
            
        }

        // PUT: api/Gifts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGift([FromRoute] int id, [FromBody] Gift gift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gift.GiftId)
            {
                return BadRequest();
            }

            _context.Entry(gift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiftExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Gifts
        [HttpPost]
        public async Task<IActionResult> PostGift([FromBody] Gift gift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           // var client = new HttpClient();
           // await client.PostAsJsonAsync("https://34123:/sdfsdf7½1",gift);
           //// await client.GetAsync("htt");
            _context.Gift.Add(gift);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGift", new { id = gift.GiftId }, gift);
        }

        // DELETE: api/Gifts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGift([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gift = await _context.Gift.FindAsync(id);
            if (gift == null)
            {
                return NotFound();
            }

            _context.Gift.Remove(gift);
            await _context.SaveChangesAsync();

            return Ok(gift);
        }

        private bool GiftExists(int id)
        {
            return _context.Gift.Any(e => e.GiftId == id);
        }
    }
}