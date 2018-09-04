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

        public Owner CreateOwner(string firstname, string lastname, string address, string phonenum, string email)
        {
            Owner newOwner = new Owner()
            {
                FirstName = firstname,
                LastName = lastname,
                Address = address,
                PhoneNumber = phonenum,
                Email = email
            };
            return newOwner;
        }

        public Pet SaveNewPet(Pet newPet)
        {
            return _petRepository.SavePet(newPet);
        }

        public Owner SaveNewOwner(Owner newOwner)
        {
            return _ownerRepository.SaveOwner(newOwner);
        }

        #region Getter methds
        #region Pet
        public List<Pet> GetAllPets()
        {
            return _petRepository.ReadPets().ToList();
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
        #endregion

        #region Owner
        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.ReadOwners().ToList();
        }

        public Owner GetOwnerByID(int id)
        {
            return _ownerRepository.ReadOwners().FirstOrDefault(o => o.ID == id);
        }
        #endregion

        #endregion

        public Pet UpdatePet(Pet petUpdate)
        {
            return _petRepository.UpdatePet(petUpdate);
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            return _ownerRepository.UpdateOwner(ownerUpdate);
        }

        public Pet RemovePet(int id)
        {
            return _petRepository.DeletePet(id);
        }

        public Owner RemoveOwner(int id)
        {
            return _ownerRepository.DeleteOwner(id);
        }
    }
}
