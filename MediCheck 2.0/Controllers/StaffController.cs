using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using MediCheck_2._0.Data;
//using MediCheck_2._0.Models;
using System.Configuration;

namespace MediCheck_2._0.Controllers
{
    public class StaffController : Controller
    {
        //database decalaration
        DatabaseReader _reader;
        private string con;
        private IConfiguration _config;

        public StaffController(IConfiguration configuration)
        {
            _config = configuration;
            con = _config.GetConnectionString("dbConnect");
            _reader = new DatabaseReader(configuration);
        }

        public ActionResult StaffTraining()
        {

            return View(_reader.StaffTraining());
        }

        // GET: StaffController
        public ActionResult Index(string id)
        {
            Staff st = _reader.GetStaff(id);
            return View(st);
        }

        // GET: StaffController/Details/5
        public ActionResult Details()
        {
            return View(_reader.AllStaff());
        }

        // GET: StaffController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string id = collection["txtID"];
                string name = collection["txtName"];
                string surname = collection["txtSurname"];
                string occupation = collection["txtOccupation"];
                string password = collection["txtPassword"];
                Staff f = new Staff(id, name, surname, occupation, password);
                _reader.AddEmployee(f);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StaffController/Edit/5
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

        // GET: StaffController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StaffController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                string eid = collection["txtID"];
                string name = collection["txtName"];
                string surname = collection["txtSurname"];
                string occuppatin = collection["txtOccupation"];
                Staff e = new Staff(eid, name, surname, occuppatin);
                _reader.UpdateEmployee(e);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                _reader.RemoveEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
