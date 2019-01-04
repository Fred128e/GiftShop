using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace GiftShopMVC.Data
{
    public class GiftShopDbContext : DbContext
    {
        public GiftShopDbContext (DbContextOptions<GiftShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<GiftShopMVC.Models.GiftViewModel> Gift { get; set; }
    }
}
