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
        IEnumerable<Owner> ReadFiltered(Filter filter);
        Owner ReadByIDWithPets(int id);

        //Save
        Owner Save(Owner ownerSave);

        //Update
        Owner Update(Owner ownerUpdate);

        //Delete
        Owner Delete(int id);

        //Count
        int Count();
    }
}
