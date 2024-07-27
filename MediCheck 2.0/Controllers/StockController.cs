using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediCheck_2._0.Data;
using MediCheck_2._0.Models;
using System.Reflection.PortableExecutable;

namespace MediCheck_2._0.Controllers
{
    public class StockController : Controller
    {
        //database declaration
        DatabaseReader _reader;
        private string con;
        private IConfiguration _config;

        public StockController(IConfiguration configuration)
        {
            _config = configuration;
            con = _config.GetConnectionString("dbConnect");
            _reader = new DatabaseReader(configuration);
        }

        public ActionResult StockByPharmacist(string pharmacistId)
        {
            return View(_reader.GetStockByPharmacistId(pharmacistId));
        }

        public ActionResult FilteredProducts(DateTime? filterByDate, string filterByStockType)
        {
            IEnumerable<Stock> filteredProducts = _reader.FilterStock(filterByDate, filterByStockType);

            // Populate the ViewBag with product types for the dropdown filter
            ViewBag.ProductTypes = _reader.GetStockTypes();

            return View(filteredProducts);
        }

        // GET: StockController
        public ActionResult Index(DateTime? dateFilter, string productTypeFilter)
        {
            IEnumerable<Stock> products;

            if (dateFilter.HasValue && !string.IsNullOrEmpty(productTypeFilter))
            {
                products = _reader.StockByDateAndType(dateFilter.Value, productTypeFilter);
            }
            else if (dateFilter.HasValue)
            {
                products = _reader.FilterStockByDate(dateFilter.Value);
            }
            else if (!string.IsNullOrEmpty(productTypeFilter))
            {
                products = _reader.FilterStockByType(productTypeFilter);
            }
            else
            {
                products = _reader.AllStock();
            }

            ViewBag.Product_Types = _reader.GetStockTypes();

            if (products == null || !products.Any())
            {
                TempData["Message"] = "No products matching the filter criteria were found.";
                return RedirectToAction(nameof(Index));
            }

            return View(products);
        }

        // GET: StockController/Details/5
        public ActionResult Details(string id)
        {
            Stock st = _reader.GetStock(id);
            return View(st);
        }

        // GET: StockController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string pharmacistId, IFormCollection collection)
        {
            try
            {
                string pid = collection["txtStockID"];
                string fid = collection["txtPhamarcistID"];
                string name = collection["txtName"];
                DateTime date = DateTime.Parse(collection["txtDate"]);
                string type = collection["txtType"];
                int quantity = int.Parse(collection["txtQuantity"]);

                Stock p = new Stock(pid, fid, name, date, type, quantity);
                _reader.AddStock(p);

                return View("ProductByFarmer", _reader.GetStockByPharmacistId(fid));
            }
            catch
            {
                return View();
            }
        }

        // GET: StockController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StockController/Edit/5
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

        // GET: StockController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StockController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, string pharmacistId, IFormCollection collection)
        {
            try
            {
                _reader.RemoveStock(id);
                return RedirectToAction("StockByPharmacist", new { pharmacistId });
            }
            catch
            {
                return View();
            }
        }
    }
}
