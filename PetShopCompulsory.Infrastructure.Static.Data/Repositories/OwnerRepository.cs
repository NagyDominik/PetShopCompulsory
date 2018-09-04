using PetShopCompulsory.Core.DomainService;
using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopCompulsory.Infrastructure.Static.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        public IEnumerable<Owner> ReadOwners()
        {
            return FakeDB.Owners;
        }

        public Owner SaveOwner(Owner ownerSave)
        {
            ownerSave.ID = FakeDB.OwnerID++;
            List<Owner> owners = FakeDB.Owners.ToList();
            owners.Add(ownerSave);
            FakeDB.Owners = owners;
            return ownerSave;
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            List<Owner> owners = FakeDB.Owners.ToList();
            int index = owners.FindIndex(o => o.ID == ownerUpdate.ID);
            owners[index] = ownerUpdate;
            FakeDB.Owners = owners;
            return ownerUpdate;
        }

        public Owner DeleteOwner(int id)
        {
            List<Owner> owners = FakeDB.Owners.ToList();
            Owner ownerDelete = owners.FirstOrDefault(o => o.ID == id);
            owners.Remove(ownerDelete);
            FakeDB.Owners = owners;
            return ownerDelete;
        }
    }
}
