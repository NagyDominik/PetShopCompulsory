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
            int index = pets.FindIndex(p => p.ID == petUpdate.ID);
            pets[index] = petUpdate;
            FakeDB.Pets = pets;
            return petUpdate;
        }

        public Pet DeletePet(int id)
        {
            List<Pet> pets = FakeDB.Pets.ToList();
            Pet petDelete = pets.FirstOrDefault(p => p.ID == id);
            pets.Remove(petDelete);
            FakeDB.Pets = pets;
            return petDelete;
        }
    }
}
