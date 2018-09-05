using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopCompulsory.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner CreateOwner(string firstname, string lastname, string address, string phonenum, string email);

        Owner SaveNewOwner(Owner newOwner);

        List<Owner> GetAllOwners();
        Owner GetOwnerByID(int id);

        Owner UpdateOwner(Owner ownerUpdate);

        Owner RemoveOwner(int id);
    }
}
