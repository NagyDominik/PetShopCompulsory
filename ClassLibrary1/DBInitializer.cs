using PetShopCompulsory.Core.Entity;
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

            string password = "1234";
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            Owner prewOwner1 = new Owner {
                FirstName = "Dave",
                LastName = "McColgan",
                Address = "93 Mendota Road",
                Email = "dave@fakemail.com",
                PhoneNumber = "52467277",
                Username = "ASD",
                IsAdmin = true,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            Owner prewOwner2 = new Owner {
                FirstName = "Munroe",
                LastName = "Wardlaw",
                Address = "6 Commercial Lane",
                Email = "mwardlaw7@fakemail.com",
                PhoneNumber = "53595277",
                Username = "ASDASD",
                IsAdmin = false,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
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
                Name = "Terry",
                Type = Types.Turtle,
                Birthdate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now,
                Color = "Green",
                PreviousOwner = prewOwner1,
                Price = 299.9
            };

            Pet pet3 = new Pet {
                Name = "Clyde",
                Type = Types.Cat,
                Birthdate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now,
                Color = "Orange",
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
                Name = "Nemo",
                Type = Types.Fish,
                Birthdate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now,
                Color = "Grey",
                PreviousOwner = prewOwner2,
                Price = 99.9
            };

            Pet pet6 = new Pet {
                Name = "Greg",
                Type = Types.Goat,
                Birthdate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now,
                Color = "Grey",
                PreviousOwner = prewOwner2,
                Price = 149.9
            };

            Pet pet7 = new Pet {
                Name = "Greg",
                Type = Types.Goat,
                Birthdate = DateTime.Now.AddYears(-5),
                SoldDate = DateTime.Now,
                Color = "Grey",
                PreviousOwner = null,
                Price = 149.9
            };

            ctx.Pets.Add(pet1);
            ctx.Pets.Add(pet2);
            ctx.Pets.Add(pet3);
            ctx.Pets.Add(pet4);
            ctx.Pets.Add(pet5);
            ctx.Pets.Add(pet6);
            ctx.Pets.Add(pet7);

            ctx.SaveChanges();
        }

        // This method computes a hashed and salted password using the HMACSHA512 algorithm.
        // The HMACSHA512 class computes a Hash-based Message Authentication Code (HMAC) using 
        // the SHA512 hash function. When instantiated with the parameterless constructor (as
        // here) a randomly Key is generated. This key is used as a password salt.

        // The computation is performed as shown below:
        //   passwordHash = SHA512(password + Key)

        // A password salt randomizes the password hash so that two identical passwords will
        // have significantly different hash values. This protects against sophisticated attempts
        // to guess passwords, such as a rainbow table attack.
        // The password hash is 512 bits (=64 bytes) long.
        // The password salt is 1024 bits (=128 bytes) long.
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
