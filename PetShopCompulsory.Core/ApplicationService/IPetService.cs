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
        List<Pet> GetPets();
        List<Pet> GetPetsByType();

        //Update
        Pet UpdatePet(Pet petUpdate);

        //Remove
        Pet RemovePet(Pet petDelete);
        Pet RemovePetByID(int id);
    }
}
