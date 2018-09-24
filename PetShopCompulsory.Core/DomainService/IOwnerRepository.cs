using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopCompulsory.Core.DomainService
{
    public interface IOwnerRepository
    {
        //Read
        IEnumerable<Owner> ReadAll();
        Owner ReadByIDWithPets(int id);

        //Save
        Owner Save(Owner ownerSave);

        //Update
        Owner Update(Owner ownerUpdate);

        //Delete
        Owner Delete(int id);
    }
}
