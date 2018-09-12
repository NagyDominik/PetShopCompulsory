using Microsoft.EntityFrameworkCore;
using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopCompulsory.Infrastructure.Static.Data
{
    public class PetShopCompulsoryContext : DbContext
    {
        public PetShopCompulsoryContext(DbContextOptions<PetShopCompulsoryContext> opt) : base(opt)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}