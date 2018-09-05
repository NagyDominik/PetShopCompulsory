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
        readonly IOwnerRepository _ownerRepository;

        public PetService(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;
        }

        public Pet CreatePet(string name, Types type, DateTime birthdate, DateTime solddate, string color, Owner previousOwner, double price)
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

        public List<Pet> GetAllPets()
        {
            List<Pet> pets = _petRepository.ReadPets().ToList();
            foreach (Pet p in pets) {
                p.PreviousOwner = _ownerRepository.ReadOwners().FirstOrDefault(o => o.ID == p.PreviousOwner.ID);
            }
            return pets;
        }

        public Pet GetPetByID(int id)
        {
            return _petRepository.ReadPets().FirstOrDefault(o => o.ID == id);
        }

        public List<Pet> GetPetsByType(Types type)
        {
            return _petRepository.ReadPets().Where(p => p.Type == type).ToList();
        }

        public List<Pet> GetPetsPriceOrdered(string order)
        {
            if (order == "Asc")
                return _petRepository.ReadPets().OrderBy(pet => pet.Price).ToList();
            else if (order == "Desc")
                return _petRepository.ReadPets().OrderByDescending(pet => pet.Price).ToList();
            else
                return null;
        }

        public List<Pet> GetPetsTopCheap(int num)
        {
            return _petRepository.ReadPets().OrderBy(p => p.Price).Take(num).ToList();
        }

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
