using PetShopCompulsory.Core.DomainService;
using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopCompulsory.Infrastructure.Data.SQL_Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        readonly PetShopCompulsoryContext _ctx;

        public OwnerRepository(PetShopCompulsoryContext ctx)
        {
            _ctx = ctx;
        }

        public Owner DeleteOwner(int id)
        {
            Owner owner = _ctx.Owners.FirstOrDefault(p => p.ID == id);
            _ctx.Owners.Remove(owner);
            _ctx.SaveChanges();
            return owner;
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _ctx.Owners;
        }

        public Owner SaveOwner(Owner ownerSave)
        {
            _ctx.Owners.Add(ownerSave);
            _ctx.SaveChanges();
            return ownerSave;
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            _ctx.Owners.Update(ownerUpdate);
            _ctx.SaveChanges();
            return ownerUpdate;
        }
    }
}
