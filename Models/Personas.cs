using System;

namespace Pizzas.API.Models
{
    public class Persona 
    {
        public int      Id                  { get; set; }
        public string   Nombre              { get; set; }
        public string   Apellido            { get; set; }
        public string   Username            { get; set; }
        public string   Password            { get; set; }
        public string   Token               { get; set; }
        public string   TokenExpirationDate { get; set; }
    }
}
