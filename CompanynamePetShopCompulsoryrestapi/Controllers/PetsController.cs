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
            Pet result = _petservice.SaveNewPet(pet);
            if (result != null)
                return Ok("Pet with ID: " + result.ID + " has been added!");
            else
                return BadRequest("Something went wrong!");
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            pet.ID = id;
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
