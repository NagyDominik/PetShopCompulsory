using Microsoft.EntityFrameworkCore;
using PetShopCompulsory.Core.DomainService;
using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopCompulsory.Infrastructure.Data.SQL_Repositories
{
    public class PetRepository : IPetRepository
    {
        readonly PetShopCompulsoryContext _ctx;

        public PetRepository(PetShopCompulsoryContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _ctx.Pets;
        }

        public IEnumerable<Pet> ReadFiltered(Filter filter)
        {
            return _ctx.Pets
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public Pet ReadByIDWithOwner(int id)
        {
            return _ctx.Pets.Include(p => p.PreviousOwner).FirstOrDefault(p => p.ID == id);
        }

        public Pet Save(Pet petSave)
        {
            //var changeTracker = _ctx.ChangeTracker.Entries<Owner>();
            //if (petSave.PreviousOwner != null && changeTracker.FirstOrDefault(oe => oe.Entity.ID == petSave.PreviousOwner.ID) == null) {
            //    _ctx.Attach(petSave.PreviousOwner);
            //}
            //petSave =_ctx.Pets.Add(petSave).Entity;
            //_ctx.SaveChanges();
            //return petSave;

            _ctx.Attach(petSave).State = EntityState.Added;
            _ctx.SaveChanges();
            return petSave;
        }

        public Pet Update(Pet petUpdate)
        {
            //var changeTracker = _ctx.ChangeTracker.Entries<Owner>();
            //if (petUpdate.PreviousOwner != null && changeTracker.FirstOrDefault(oe => oe.Entity.ID == petUpdate.PreviousOwner.ID) == null) {
            //    _ctx.Attach(petUpdate.PreviousOwner);
            //}
            //else {
            //    _ctx.Entry(petUpdate).Reference(p => p.PreviousOwner).IsModified = true;
            //}
            //petUpdate = _ctx.Pets.Update(petUpdate).Entity;
            //_ctx.SaveChanges();
            //return petUpdate;

            _ctx.Attach(petUpdate).State = EntityState.Modified;
            _ctx.Entry(petUpdate).Reference(p => p.PreviousOwner).IsModified = true;
            _ctx.SaveChanges();
            return petUpdate;
        }

        public Pet Delete(int id)
        {
            Pet pet = _ctx.Pets.Remove(new Pet { ID = id }).Entity;
            _ctx.SaveChanges();
            return pet;
        }

        public int Count()
        {
            return _ctx.Pets.Count();
        }
    }
}
