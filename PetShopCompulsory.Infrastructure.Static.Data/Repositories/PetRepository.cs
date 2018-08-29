using PetShopCompulsory.Core.DomainService;
using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetShopCompulsory.Infrastructure.Static.Data
{
    public class PetRepository : IPetRepository
    {
        public IEnumerable<Pet> ReadPets()
        {
            throw new NotImplementedException();
        }
    }
}
