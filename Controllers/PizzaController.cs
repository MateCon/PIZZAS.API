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
            return Ok(PizzaService.GetAllPizzas());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            Pizza pizza = PizzaService.GetPizzaById(id);
            if(pizza != null) {
                return Ok(pizza);
            }
            return BadRequest("Error");
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza) {
           if(PizzaService.CreatePizza(pizza) > 0) {
                return Ok("Pizza creada");
           }
           return BadRequest("Error");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id) {
            if(PizzaService.DeletePizza(id) > 0) {
                return Ok("Pizza deleted");
            }
            return BadRequest("Error");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza) {
            if(PizzaService.UpdatePizza(id, pizza) > 0) {
                return Ok("Pizza modified");
            }
            return BadRequest("Error");
        }
    }
}
