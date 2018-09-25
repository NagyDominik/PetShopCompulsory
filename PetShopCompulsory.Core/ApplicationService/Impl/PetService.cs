using System;
using System.Collections.Generic;
using System.IO;
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
            return _petRepository.Save(newPet);
        }

        public List<Pet> GetAllPets()
        {
            List<Pet> pets = _petRepository.ReadAll().ToList();
            return pets;
        }

        public Pet GetPetByID(int id)
        {
            return _petRepository.ReadByIDWithOwner(id);
        }

        public List<Pet> GetPetsByType(Types type)
        {
            return _petRepository.ReadAll().Where(p => p.Type == type).ToList();
        }

        public List<Pet> GetPetsPriceOrdered(string order)
        {
            if (order == "Asc")
                return _petRepository.ReadAll().OrderBy(pet => pet.Price).ToList();
            else if (order == "Desc")
                return _petRepository.ReadAll().OrderByDescending(pet => pet.Price).ToList();
            else
                return null;
        }

        public List<Pet> GetPetsTopCheap(int num)
        {
            return _petRepository.ReadAll().OrderBy(p => p.Price).Take(num).ToList();
        }

        public List<Pet> GetPetsFiltered(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0) {
                throw new InvalidDataException("CurrentPage and ItemsPage must be zero or more");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _petRepository.Count()) {
                throw new InvalidDataException("Index out of boundary, CurrentPage is to high");
            }

            return _petRepository.ReadFiltered(filter).ToList();
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            return _petRepository.Update(petUpdate);
        }

        public Pet RemovePet(int id)
        {
            return _petRepository.Delete(id);
        }
    }
}
