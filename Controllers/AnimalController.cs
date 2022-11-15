using KlinikaWeterynaryjna.Entities;
using KlinikaWeterynaryjna.Models;
using KlinikaWeterynaryjna.Services;
using Microsoft.AspNetCore.Mvc;

namespace KlinikaWeterynaryjna.Controllers
{
    [Route("api")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpPost]
        public ActionResult CreateAnimal([FromBody] Animal animal)
        {
            var id = _animalService.Create(animal);
            return Created($"api/product/{id}", null);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _animalService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] Animal animal, [FromRoute] int id)
        {
            _animalService.Update(id, animal);
            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> GetAnimals([FromQuery] AnimalsQuery query)
        {
            var animals = _animalService.GetAnimals(query);
            return Ok(animals);
        }
    }
}
