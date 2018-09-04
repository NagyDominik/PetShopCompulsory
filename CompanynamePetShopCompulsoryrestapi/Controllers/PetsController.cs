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
            return _petservice.GetAllPets().FirstOrDefault(p => p.ID == id);
        }

        // POST api/pets
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine("Post: {0}", value);
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Console.WriteLine("Pet {0} updated");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petservice.RemovePet(id);
        }
    }
}
