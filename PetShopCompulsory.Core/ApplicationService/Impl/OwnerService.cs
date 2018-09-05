using PetShopCompulsory.Core.DomainService;
using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopCompulsory.Core.ApplicationService.Impl
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public Owner CreateOwner(string firstname, string lastname, string address, string phonenum, string email)
        {
            Owner newOwner = new Owner() {
                FirstName = firstname,
                LastName = lastname,
                Address = address,
                PhoneNumber = phonenum,
                Email = email
            };
            return newOwner;
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.ReadOwners().ToList();
        }

        public Owner GetOwnerByID(int id)
        {
            return _ownerRepository.ReadOwners().FirstOrDefault(o => o.ID == id);
        }

        public Owner SaveNewOwner(Owner newOwner)
        {
            return _ownerRepository.SaveOwner(newOwner);
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            return _ownerRepository.UpdateOwner(ownerUpdate);
        }

        public Owner RemoveOwner(int id)
        {
            return _ownerRepository.DeleteOwner(id);
        }
    }
}
