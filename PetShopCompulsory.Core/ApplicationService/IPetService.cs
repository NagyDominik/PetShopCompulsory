using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetShopCompulsory.Core
{
    public interface IPetService
    {
        List<Pet> GetPets();
    }
}
