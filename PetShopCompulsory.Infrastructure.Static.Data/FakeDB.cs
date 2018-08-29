using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopCompulsory.Infrastructure.Static.Data
{
    public static class FakeDB
    {
        public static IEnumerable<Pet> Pets;

        static void InitData()
        {
            Pet pet1 = new Pet() {
                ID = 1,
                Name = "George",
                Type = Types.Goat,
                Birthdate = new DateTime(2011, 11, 11),
                SoldDate = new DateTime(2013, 12, 23),
                Color = "Brown",
                PreviousOwner = "George",
                Price = 49.99
            };
            Pet pet2 = new Pet() {
                ID = 1,
                Name = "Henry",
                Type = Types.Hedgehog,
                Birthdate = new DateTime(2014, 04, 04),
                SoldDate = new DateTime(2014, 06, 06),
                Color = "Gray",
                PreviousOwner = "Henry",
                Price = 29.99
            };
            Pet pet3 = new Pet() {
                ID = 1,
                Name = "Frederic",
                Type = Types.Fish,
                Birthdate = new DateTime(2011, 12, 12),
                SoldDate = new DateTime(2012, 12, 23),
                Color = "Red",
                PreviousOwner = "Freddy",
                Price = 19.99
            };

            Pets.ToList().Add(pet1);
            Pets.ToList().Add(pet2);
            Pets.ToList().Add(pet3);
        }
    }
}
