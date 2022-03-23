using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;

namespace Pizzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        [HttpGet("all")]
        public IActionResult GetAll() {
            return Ok(BD.GetAllPizzas());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            Pizza pizza = BD.GetPizzaById(id);
            if(pizza != null) {
                return Ok(pizza);
            }
            return BadRequest("Error");
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza) {
           if(BD.CreatePizza(pizza) > 0) {
                return Ok("Pizza creada");
           }
           return BadRequest("Error");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id) {
            if(BD.DeletePizza(id) > 0) {
                return Ok("Pizza deleted");
            }
            return BadRequest("Error");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza) {
            if(BD.UpdatePizza(id, pizza) > 0) {
                return Ok("Pizza modified");
            }
            return BadRequest("Error");
        }
    }
}
