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

        public Pet SaveNewPet(Pet newPet)
        {
            return _petRepository.SavePet(newPet);
        }

        #region Getter methds

        public List<Pet> GetAllPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        public List<Pet> GetPetsByType(Types type)
        {
            throw new NotImplementedException();
        }

        public List<Pet> GetPetsPriceOrdered()
        {
            throw new NotImplementedException();
        }

        public List<Pet> GetPetsTopCheap(int num)
        {
            throw new NotImplementedException();
        }
        #endregion

        public Pet UpdatePet(Pet petUpdate)
        {
            return _petRepository.UpdatePet(petUpdate);
        }

        public Pet RemovePet(int id)
        {
            return _petRepository.DeletePet(id);
        }
    }
}
