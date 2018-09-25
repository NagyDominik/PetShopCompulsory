using Microsoft.EntityFrameworkCore;
using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopCompulsory.Infrastructure.Data
{
    public class PetShopCompulsoryContext : DbContext
    {
        public PetShopCompulsoryContext(DbContextOptions<PetShopCompulsoryContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.PreviousOwner)
                .WithMany(o => o.Pets)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}