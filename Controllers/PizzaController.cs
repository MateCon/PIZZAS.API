using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Services;
using Pizzas.API.Models;

namespace Pizzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        [HttpGet("all")]
        public IActionResult GetAll() {
            try {
                return Ok(PizzaService.GetAllPizzas());
            } catch(Exception error) {
                return NotFound(error);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            try {
                Pizza pizza = PizzaService.GetPizzaById(id);
                if(pizza != null) {
                    return Ok(pizza);
                }
                return BadRequest("Error");
            } catch(Exception error) {
                return NotFound(error);
            }
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza) {
            try {
                if(PizzaService.CreatePizza(pizza) > 0) {
                        return Ok("Pizza creada");
                }
                return BadRequest("Error");
            } catch(Exception error) {
                return NotFound(error);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id) {
            try {
                if(PizzaService.DeletePizza(id) > 0) {
                    return Ok("Pizza deleted");
                }
                return BadRequest("Error");
            } catch(Exception error) {
                return NotFound(error);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza) {
            try {
                if(PizzaService.UpdatePizza(id, pizza) > 0) {
                    return Ok("Pizza modified");
                }
                return BadRequest("Error");
            } catch(Exception error) {
                return NotFound(error);
            }
        }
    }
}
