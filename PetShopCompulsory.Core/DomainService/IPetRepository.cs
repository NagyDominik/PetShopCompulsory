using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopCompulsory.Core.DomainService
{
    public interface IPetRepository
    {
        //Read
        IEnumerable<Pet> ReadAll();
        Pet ReadByIDWithOwner(int id);

        //Save
        Pet Save(Pet petSave);

        //Update
        Pet Update(Pet petUpdate);

        //Delete
        Pet Delete(int id);
    }
}
