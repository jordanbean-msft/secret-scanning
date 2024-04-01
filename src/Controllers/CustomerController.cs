// Customer controller
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Update customer details
        public IActionResult UpdateCustomer(Customer customer)
        {
            // connect to Azure SQL and update customer
            SqlConnection sqlConnection = new SqlConnection("Server=tcp:myserver.database.windows.net,1433;Initial Catalog=mydatabase;Persist Security Info=False;User ID=myusername;Password=mypassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();
            string query = "UPDATE Customer SET Name = '" + customer.Name + "', Address = '" + customer.Address + "' WHERE Id = '" + customer.Id + "'";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            
            // Update customer details
            return View();
        }        
    }
}