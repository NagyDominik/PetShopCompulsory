﻿using Microsoft.EntityFrameworkCore;
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

        public Pet DeletePet(int id)
        {
            Pet pet = _ctx.Pets.FirstOrDefault(p => p.ID == id);
            _ctx.Pets.Remove(pet);
            _ctx.SaveChanges();
            return pet;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }

        public Pet SavePet(Pet petSave)
        {
            //_ctx.Entry(petSave.PreviousOwner).State = EntityState.Unchanged;
            petSave.PreviousOwner = _ctx.Owners.FirstOrDefault(o => o.ID == petSave.PreviousOwner.ID);
            _ctx.Pets.Add(petSave);
            _ctx.SaveChanges();
            return petSave;
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            _ctx.Pets.Update(petUpdate);
            petUpdate.PreviousOwner = _ctx.Owners.FirstOrDefault(o => o.ID == petUpdate.PreviousOwner.ID);
            _ctx.Pets.Add(petUpdate);
            _ctx.SaveChanges();
            return petUpdate;
        }
    }
}