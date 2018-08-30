using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShopCompulsory.Core.DomainService;
using PetShopCompulsory.Core.Entity;

namespace PetShopCompulsory.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet CreatePet(string name, Types type, DateTime birthdate, DateTime solddate, string color, string previousOwner, double price)
        {
            Pet newPet = new Pet
            {
                Name = name,
                Type = type,
                Birthdate = birthdate,
                SoldDate = solddate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };
            return newPet;
        }

        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        public List<Pet> GetPetsByType()
        {
            throw new NotImplementedException();
        }

        public Pet RemovePet(Pet petDelete)
        {
            throw new NotImplementedException();
        }

        public Pet RemovePetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Pet SaveNewPet(Pet newPet)
        {
            return _petRepository.SavePet(newPet);
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
