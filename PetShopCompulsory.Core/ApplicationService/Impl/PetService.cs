using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShopCompulsory.Core.DomainService;
using PetShopCompulsory.Core.Entity;

namespace PetShopCompulsory.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepository;
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets().ToList();
        }
    }
}
