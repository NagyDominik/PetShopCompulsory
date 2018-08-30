using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopCompulsory.Core.DomainService
{
    public interface IPetRepository
    {
        //Read
        IEnumerable<Pet> ReadPets();

        //Save
        Pet SavePet(Pet petSave);

        //Update
        Pet UpdatePet(Pet petUpdate);

        //Delete
        Pet DeletePet(int id);
    }
}
