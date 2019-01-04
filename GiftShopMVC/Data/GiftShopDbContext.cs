using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GiftShop.Models
{
    public class GiftShopDbContext : DbContext
    {
        public GiftShopDbContext (DbContextOptions<GiftShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<GiftShop.Models.Gift> Gift { get; set; }
    }
}
