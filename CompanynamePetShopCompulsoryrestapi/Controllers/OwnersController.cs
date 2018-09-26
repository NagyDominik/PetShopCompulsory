using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopCompulsory.Core;
using PetShopCompulsory.Core.ApplicationService;
using PetShopCompulsory.Core.Entity;

namespace CompanynamePetShopCompulsoryrestapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerservice;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerservice = ownerService;
        }

        // GET: api/Owner
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _ownerservice.GetAllOwners();
        }

        // GET: api/Owner/5
        [HttpGet("{id}", Name = "Get")]
        public Owner Get(int id)
        {
            return _ownerservice.GetOwnerByID(id);
        }

        // POST: api/Owner
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner newowner)
        {
            Owner result = null;
            try {
                result = _ownerservice.SaveNewOwner(newowner);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
            
            if (result != null)
                return Ok("Owner with ID: " + newowner.ID + " has been added!");
            else
                return BadRequest("Something went wrong!");
        }

        // POST api/pets/multipost
        [HttpPost("multipost")]
        public ActionResult<Owner> PostMulti([FromBody] Owner[] owners)
        {
            bool passed = true;
            foreach (Owner owner in owners) {
                Owner result = _ownerservice.SaveNewOwner(owner);
                if (result == null)
                    passed = false;
            }
            if (passed)
                return Ok("Owners with has been added!");
            else
                return BadRequest("Something went wrong!");
        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner updateowner)
        {
            if (id != updateowner.ID) {
                return BadRequest("The owner ID in the URL does not mach the ID in the given owner object!");
            }
            Owner result = _ownerservice.UpdateOwner(updateowner);
            if (result != null)
                return Ok("Owner with ID: " + id + " has been updated!");
            else
                return BadRequest("Something went wrong!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            Owner result = _ownerservice.RemoveOwner(id);
            if (result != null)
                return Ok("Owner with ID: " + id + " has been deleted!");
            else
                return BadRequest("Something went wrong!");
        }
    }
}
