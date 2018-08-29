using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopCompulsory.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();
    }
}
