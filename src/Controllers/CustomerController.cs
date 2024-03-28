//Customer Controller
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Update a customer in the database
        public IActionResult UpdateCustomer(Customer customer)
        {
            string connectionString = "Data Source=(local);Initial Catalog=YourDatabaseName;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                //update the Customer table in the database
                string query = "UPDATE Customer SET Name = @Name, Address = @Address, Email = @Email, Phone = @Phone WHERE Id = " + customer.Id;//@Id";
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@Id", customer.Id);
                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@Address", customer.Address);

                //execute the db command
                command.ExecuteNonQuery();
            }
            //Code to update the customer in the database
            return View();
        }

    }
}