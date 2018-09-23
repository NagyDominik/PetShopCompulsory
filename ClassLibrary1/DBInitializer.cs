﻿using PetShopCompulsory.Core.Entity;
using PetShopCompulsory.Infrastructure.Data;
using System;

namespace PetShop.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetShopCompulsoryContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            Owner prewOwner1 = new Owner {
                FirstName = "Dave",
                LastName = "McColgan",
                Address = "93 Mendota Road",
                Email = "dave@dmail.com",
                PhoneNumber = "5246727702"
            };

            Owner prewOwner2 = new Owner {
                FirstName = "Munroe",
                LastName = "Wardlaw",
                Address = "6 Commercial Lane",
                Email = "mwardlaw7@hubpages.com",
                PhoneNumber = "5359527708"
            };

            ctx.Owners.Add(prewOwner1);
            ctx.Owners.Add(prewOwner2);

            Pet pet1 = new Pet {
                Name = "Diego",
                Type = Types.Dog,
                Birthdate = DateTime.Now.AddMonths(-3),
                SoldDate = DateTime.Now,
                Color = "Brown",
                PreviousOwner = prewOwner1,
                Price = 199.9
            };

            Pet pet2 = new Pet {
                Name = "Tom",
                Type = Types.Turtle,
                Birthdate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now,
                Color = "Yellow",
                PreviousOwner = prewOwner1,
                Price = 299.9
            };

            Pet pet3 = new Pet {
                Name = "Cat",
                Type = Types.Cat,
                Birthdate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now,
                Color = "Blue",
                PreviousOwner = prewOwner2,
                Price = 399.9
            };

            Pet pet4 = new Pet {
                Name = "Snek",
                Type = Types.Snake,
                Birthdate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now,
                Color = "Red",
                PreviousOwner = prewOwner2,
                Price = 499.9
            };

            Pet pet5 = new Pet {
                Name = "Rat",
                Type = Types.Fish,
                Birthdate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now,
                Color = "Grey",
                PreviousOwner = prewOwner2,
                Price = 99.9
            };

            Pet pet6 = new Pet {
                Name = "Goat",
                Type = Types.Goat,
                Birthdate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now,
                Color = "Grey",
                PreviousOwner = prewOwner2,
                Price = 149.9
            };

            ctx.Pets.Add(pet1);
            ctx.Pets.Add(pet2);
            ctx.Pets.Add(pet3);
            ctx.Pets.Add(pet4);
            ctx.Pets.Add(pet5);
            ctx.Pets.Add(pet6);


            ctx.SaveChanges();
        }
    }
}