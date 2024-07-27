using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using MediCheck_2._0.Data;
//using MediCheck_2._0.Models;
using System.Configuration;
using System.Reflection.PortableExecutable;

namespace MediCheck_2._0.Controllers
{
    public class AdminController : Controller
    {
        //database decalaration
        DatabaseReader _reader;
        private string con;
        private IConfiguration _config;

        public AdminController(IConfiguration configuration)
        {
            _config = configuration;
            con = _config.GetConnectionString("dbConnect");
            _reader = new DatabaseReader(configuration);
        }

        [HttpPost]
        public IActionResult Index(string txtUsername, string txtPassword)
        {
            Administrator ad = _reader.GetAdmin(txtUsername, txtPassword);
            if (ad != null)
            {
                // Valid employee login
                // Redirect to the Options menu view
                return RedirectToAction("OptionsMenu");
            }
            // Invalid login credentials or choice
            TempData["InvalidCredentialsMessage"] = "Invalid credentials! ";
            // Redirect back to the login view
            return RedirectToAction("Index");
        }

        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
