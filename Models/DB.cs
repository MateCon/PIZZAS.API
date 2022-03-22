using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Pizzas.API.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=A-BTA-22;
            DataBase=DAI-Pizzas;Trusted_Connection=True;";

        public static IEnumerable<Pizza> GetAllPizzas() {
            IEnumerable<Pizza> pizzas = null;
            string query = "SELECT * FROM Pizzas";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                pizzas = db.Query<Pizza>(query);
            }
            return pizzas;
        }

        public static Pizza GetPizzaById(int id) {
            Pizza pizza = null;
            string query = "SELECT * FROM Pizzas WHERE id = @pId";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                pizza = db.QueryFirstOrDefault<Pizza>(query, new { pId = id });
            }
            return pizza;
        }

        // no terminado
        public static void Create(Pizza pizza) {
            int registrosCreados = 0;
            string query = "INSERT INTO Pizzas";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                registrosCreados = db.Execute<Pizza>(query, new { pId = id });
            }
            return pizza;
        }
    }
}