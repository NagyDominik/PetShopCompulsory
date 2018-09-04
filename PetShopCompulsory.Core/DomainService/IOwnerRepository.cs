using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopCompulsory.Core.DomainService
{
    public interface IOwnerRepository
    {
        //Read
        IEnumerable<Owner> ReadOwners();

        //Save
        Owner SaveOwner(Owner ownerSave);

        //Update
        Owner UpdateOwner(Owner ownerUpdate);

        //Delete
        Owner DeleteOwner(int id);
    }
}
