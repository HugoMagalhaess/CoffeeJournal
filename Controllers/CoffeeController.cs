using CoffeeJournal.Interfaces;
using CoffeeJournal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : Controller
    {
        private readonly ICoffeeRepository _coffeeRepository;

        public CoffeeController(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Coffee>))]
        public IActionResult GetCoffees()
        {
            var coffees = _coffeeRepository.GetCoffees();
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(coffees);
        }

        [HttpGet("{coffeeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Coffee>))]
        [ProducesResponseType(400)]
        public IActionResult GetCoffee(int coffeeId)
        {

            if(!_coffeeRepository.CoffeeExists(coffeeId))
                    return NotFound();

            var coffee = _coffeeRepository.GetCoffee(coffeeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(coffee);
        }

    }
}
