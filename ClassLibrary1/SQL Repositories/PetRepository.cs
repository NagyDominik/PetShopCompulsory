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

        public Pet Delete(int id)
        {
            Pet pet =_ctx.Pets.Remove(new Pet { ID = id }).Entity;
            _ctx.SaveChanges();
            return pet;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _ctx.Pets;
        }

        public Pet ReadByIDWithOwner(int id)
        {
            return _ctx.Pets.Include(p => p.PreviousOwner).FirstOrDefault(p => p.ID == id);
        }

        public Pet Save(Pet petSave)
        {
            var changeTracker = _ctx.ChangeTracker.Entries<Owner>();
            if (petSave.PreviousOwner != null) {
                _ctx.Attach(petSave.PreviousOwner);
            }
            petSave =_ctx.Pets.Add(petSave).Entity;
            _ctx.SaveChanges();
            return petSave;
        }

        public Pet Update(Pet petUpdate)
        {
            _ctx.Pets.Update(petUpdate);
            petUpdate.PreviousOwner = _ctx.Owners.FirstOrDefault(o => o.ID == petUpdate.PreviousOwner.ID);
            _ctx.Pets.Add(petUpdate);
            _ctx.SaveChanges();
            return petUpdate;
        }
    }
}
