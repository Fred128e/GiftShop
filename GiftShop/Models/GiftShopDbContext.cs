using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GiftShop.Models
{
    public partial class GiftShopDbContext : DbContext
    {
        public GiftShopDbContext()
        {
        }

        public GiftShopDbContext(DbContextOptions<GiftShopDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Gift> Gift { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=GiftShopDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.GenderId).ValueGeneratedNever();

                entity.Property(e => e.Gender1)
                    .IsRequired()
                    .HasColumnName("Gender")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Gift>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Rowversion)
                    .IsRequired()
                    .HasColumnName("rowversion")
                    .IsRowVersion();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Gift)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gift_Gender");
            });
        }
    }
}
