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
        public IEnumerable<Pizza> GetAll() {
            return BD.GetAllPizzas();
        }

        [HttpGet("{id}")]
        public Pizza GetById(int id) {
            return BD.GetPizzaById(id);
        }
    }
}
