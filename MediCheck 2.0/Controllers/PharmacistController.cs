using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
//using MediCheck_2._0.Data;
using System.Net;
using MediCheck_2._0.Models;
using Microsoft.VisualBasic;
using System.Reflection.Emit;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;

namespace MediCheck_2._0.Controllers
{
    public class PharmacistController : Controller
    {
        //database decalaration
        DatabaseReader _reader;

        public PharmacistController(IConfiguration configuration)
        {
            _reader = new DatabaseReader(configuration);
        }

        // GET: PharmacistController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PharmacistController/Details/5
        public ActionResult Details(string id)
        {
            Pharmacist st = _reader.GetFarmer(id);
            return View(st);
        }

        // GET: PharmacistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PharmacistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string id = collection["txtID"];
                string name = collection["txtName"];
                string surname = collection["txtSurname"];
                string password = collection["txtPassword"];

                Pharmacist f = new Pharmacist(id, name, surname, password);
                _reader.AddFarmer(f);

                return RedirectToAction("Index", "Pharmacist");
            }
            catch
            {
                return View();
            }
        }

        // GET: PharmacistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PharmacistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                string fid = collection["txtID"];
                string name = collection["txtName"];
                string surname = collection["txtSurname"];
                string password = collection["txtContactNumber"];
                Pharmacist f = new Pharmacist(fid, name, surname, password);
                _reader.UpdateFarmer(f);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Profile(string id)
        {
            Pharmacist pharmacist = _reader.GetFarmer(id);
            return View(pharmacist);
        }

        // GET: FarmerController1/Delete/5
        public ActionResult Delete(string id)
        {
            Farmer st = _reader.GetFarmer(id);
            return View(st);
        }

        // POST: PharmacistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                _reader.RemoveFarmer(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
