using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetShopCompulsory.Core
{
    public interface IPetService
    {
        //Create new Pet
        Pet CreatePet(string name, Types type, DateTime birthdate, DateTime solddate, string color, Owner previousOwner, double price);
        Owner CreateOwner(string firstname, string lastname, string address, string phonenum, string email);

        //Save
        Pet SaveNewPet(Pet newPet);
        Owner SaveNewOwner(Owner newOwner);

        //Read
        List<Pet> GetAllPets();
        List<Pet> GetPetsByType(Types type);
        List<Pet> GetPetsPriceOrdered(string order);
        List<Pet> GetPetsTopCheap(int num);

        List<Owner> GetAllOwners();
        Owner GetOwnerByID(int id);

        //Update
        Pet UpdatePet(Pet petUpdate);
        Owner UpdateOwner(Owner ownerUpdate);

        //Remove
        Pet RemovePet(int id);
        Owner RemoveOwner(int id);
    }
}
