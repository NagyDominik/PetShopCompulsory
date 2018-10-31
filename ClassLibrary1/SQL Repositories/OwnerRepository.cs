using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Owner> ReadAll()
        {
            return _ctx.Owners;
        }

        public IEnumerable<Owner> ReadFiltered(Filter filter)
        {
            return _ctx.Owners
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public Owner ReadByIDWithPets(int id)
        {
            return _ctx.Owners.Include(o => o.Pets).FirstOrDefault(o => o.ID == id);
        }

        public Owner Save(Owner ownerSave)
        {
            if (ownerSave.Pets != null) {
                foreach (Pet pet in ownerSave.Pets) {
                    _ctx.Attach(pet);
                }
            }
            ownerSave = _ctx.Owners.Add(ownerSave).Entity;
            _ctx.SaveChanges();
            return ownerSave;
        }

        public Owner Update(Owner ownerUpdate)
        {
            //_ctx.Owners.Update(ownerUpdate);
            //_ctx.SaveChanges();
            //return ownerUpdate;

            _ctx.Attach(ownerUpdate).State = EntityState.Modified;
            _ctx.Entry(ownerUpdate).Collection(o => o.Pets).IsModified = true;
            _ctx.SaveChanges();
            return ownerUpdate;
        }

        public Owner Delete(int id)
        {
            Owner owner = _ctx.Owners.Remove(new Owner { ID = id }).Entity;
            _ctx.SaveChanges();
            return owner;
        }

        public int Count()
        {
            return _ctx.Owners.Count();
        }
    }
}
