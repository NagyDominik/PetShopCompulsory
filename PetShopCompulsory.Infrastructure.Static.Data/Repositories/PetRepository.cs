using PetShopCompulsory.Core.DomainService;
using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShopCompulsory.Infrastructure.Static.Data
{
    public class PetRepository : IPetRepository
    {
        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }

        public Pet SavePet(Pet petSave)
        {
            petSave.ID = FakeDB.PetID++;
            List<Pet> pets = FakeDB.Pets.ToList();
            pets.Add(petSave);
            FakeDB.Pets = pets;
            return petSave;
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            List<Pet> pets = FakeDB.Pets.ToList();
            Pet pet = pets.FirstOrDefault(p => p.ID == petUpdate.ID);
            pet = petUpdate;

        }

        public Pet DeletePet(Pet petDelete)
        {
            throw new NotImplementedException();
        }
    }
}
