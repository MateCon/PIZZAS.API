using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Pizzas.API.Models;
using Dapper;

namespace Pizzas.API.Services
{
    public static class PizzaService
    {
        public static IEnumerable<Pizza> GetAllPizzas() {
            IEnumerable<Pizza> pizzas = null;
            string query = "SELECT * FROM Pizzas";
            using (SqlConnection db = BD.GetConnection()) {
                pizzas = db.Query<Pizza>(query);
            }
            return pizzas;
        }

        public static Pizza GetPizzaById(int id) {
            Pizza pizza = null;
            string query = "SELECT * FROM Pizzas WHERE id = @pId";
            using (SqlConnection db = BD.GetConnection()) {
                pizza = db.QueryFirstOrDefault<Pizza>(query, new { pId = id });
            }
            return pizza;
        }

        public static int CreatePizza(Pizza pizza) {
            int registrosCreados = 0;
            string query = "INSERT INTO Pizzas(Nombre, LibreGluten, Importe, Descripcion) VALUES (@pNombre, @pLibreGluten, @pImporte, @pDescripcion)";
            using (SqlConnection db = BD.GetConnection()) {
                registrosCreados = db.Execute(query, new { pNombre = pizza.Nombre, pLibreGluten = pizza.LibreGluten, pImporte = pizza.Importe, pDescripcion = pizza.Descripcion });
            }
            return registrosCreados;
        }

        public static int DeletePizza(int id) {
            int registrosBorrados = 0;
            string query = "DELETE FROM Pizzas WHERE @pId = id";
            using (SqlConnection db = BD.GetConnection()) {
                registrosBorrados = db.Execute(query, new { pId = id });
            }
            return registrosBorrados;
        }

        public static int UpdatePizza(int id, Pizza pizza) {
            int registrosModificados = 0;
            string query = "UPDATE Pizzas SET Nombre = @pNombre, LibreGluten = @pLibreGluten, Importe = @pImporte, Descripcion = @pDescripcion WHERE id = @pId";
            using (SqlConnection db = BD.GetConnection()) {
                registrosModificados = db.Execute(query, new { pId = id, pNombre = pizza.Nombre, pLibreGluten = pizza.LibreGluten, pImporte = pizza.Importe, pDescripcion = pizza.Descripcion });
            }
            return registrosModificados;
        }
    }
}