using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetShopCompulsory.Core
{
    public interface IPetService
    {
        //Create new Pet
        Pet CreatePet(string name, Types type, DateTime birthdate, DateTime solddate, string color, string previousOwner, double price);

        //Save
        Pet SaveNewPet(Pet newPet);

        //Read
        List<Pet> GetAllPets();
        List<Pet> GetPetsByType(Types type);
        List<Pet> GetPetsPriceOrdered(string order);
        List<Pet> GetPetsTopCheap(int num);

        //Update
        Pet UpdatePet(Pet petUpdate);

        //Remove
        Pet RemovePet(int id);

    }
}
