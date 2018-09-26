using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopCompulsory.Core;
using PetShopCompulsory.Core.Entity;

namespace CompanynamePetShopCompulsoryrestapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petservice;

        public PetsController(IPetService petService)
        {
            _petservice = petService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petservice.GetAllPets();
        }

        // GET api/pets?page
        [HttpGet("f")]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] Filter filter)
        {
            try {
                return Ok(_petservice.GetPetsFiltered(filter));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petservice.GetPetByID(id);
        }

        // POST api/pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            Pet result = null;
            try {
                result = _petservice.SaveNewPet(pet);
            }
            catch (Exception e) {
                BadRequest(e.Message);
            }
            if (result != null)
                return Ok("Pet with ID: " + result.ID + " has been added!");
            else
                return BadRequest("Something went wrong!");
        }

        // POST api/pets/multipost
        [HttpPost("multipost")]
        public ActionResult<Pet> PostMulti([FromBody] Pet[] pets)
        {
            bool passed = true;
            foreach (Pet pet in pets) {
                try {
                    Pet result = _petservice.SaveNewPet(pet);
                    if (result == null)
                        passed = false;
                }
                catch (Exception e) {
                    BadRequest(e.Message);
                }
            }
            if (passed)
                return Ok("Pets with has been added!");
            else
                return BadRequest("Something went wrong!");
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id != pet.ID) {
                return BadRequest("The pet ID in the URL does not mach the ID in the given pet object!");
            }
            Pet result = _petservice.UpdatePet(pet);
            if (result != null)
                return Ok("Pet with ID: " + id + " has been updated!");
            else
                return BadRequest("Something went wrong!");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            Pet result = _petservice.RemovePet(id);
            if (result != null)
                return Ok("Pet with ID: " + id + " has been deleted!");
            else
                return BadRequest("Something went wrong!");
        }
    }
}
