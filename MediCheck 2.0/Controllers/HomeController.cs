using MediCheck_2._0.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Reflection.PortableExecutable;
//using PROG7311_PART2_ST10091214.Data;
//using PROG7311_PART2_ST10091214.Models;
//using static PROG7311_PART2_ST10091214.Data.DatabaseReader;

namespace MediCheck_2._0.Controllers
{
    public class HomeController : Controller
    {
        //DatabaseReader _reader;
        private string con;
        private IConfiguration _config;

        private readonly ILogger<HomeController> _logger;

        public HomeController(IConfiguration configuration)
        {
            _config = configuration;
            con = _config.GetConnectionString("dbConnect");
            _reader = new DatabaseReader(configuration);
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(IFormCollection collection)
        {
            return View(_reader.AllFarmers());
        }

        [HttpGet]
        public IActionResult OptionMenu(string id)
        {
            Employee emp = _reader.GetEmployee(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Index(string choice, string txtUsername, string txtPassword, IFormCollection collection)
        {
            if (choice == "EMPLOYEE")
            {
                Employee employee = _reader.EmployeeValidation(txtUsername, txtPassword);
                if (employee != null)
                {
                    Employee emp = _reader.GetEmployee(employee.emp_id);

                    // Store the farmer object in the session
                    string e = employee.emp_id;

                    // Valid employee login
                    // Redirect to the Options menu view
                    return RedirectToAction("OptionMenu", emp);
                }
            }
            else if (choice == "FARMER")
            {
                Farmer farmer = _reader.FarmerValidation(txtUsername, txtPassword);

                if (farmer != null)
                {
                    Farmer farmerInfo = _reader.GetFarmer(farmer.Id);

                    // Store the farmer object in the session
                    string f = farmer.Id;


                    // Pass the farmerInfo as a model to the profile view
                    return View("~/Views/Farmer/Profile.cshtml", farmerInfo);

                    // Valid farmer login
                    // Redirect to the Farm Profile view
                }
            }
            // Invalid login credentials or choice
            TempData["InvalidCredentialsMessage"] = "Invalid credentials! ";
            // Redirect back to the login view
            return RedirectToAction("Index");
        }

  
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
