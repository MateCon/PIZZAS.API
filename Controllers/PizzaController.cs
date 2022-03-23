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
            return Ok(BD.GetPizzaById(id));
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza) {
            int registrosCreados = BD.CreatePizza(pizza);
            return Ok("Pizza creada.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id) {
            int registrosBorrados = BD.DeletePizza(id);
            return Ok("Pizza deleted.");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza) {
            int registrosModificados = BD.UpdatePizza(id, pizza);
            return Ok("Pizza modified.");
        }
    }
}
