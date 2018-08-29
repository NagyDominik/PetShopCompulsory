using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopCompulsory.Infrastructure.Static.Data
{
    public static class FakeDB
    {
        public static IEnumerable<Pet> PetList;

        static void InitData()
        {
            Pet pet1 = new Pet() {
                ID = 1,
                Name = "George",
                Type = Types.Goat,
                Birthdate = new DateTime(2011, 11, 11),
                SoldDate = ,
                Color = "Brown",
                PreviousOwner = "George",
                Price = 49.99,
            };
        }
    }
}
