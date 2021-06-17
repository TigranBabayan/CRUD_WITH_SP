using CRUD_WITH_SP.Infrastructure;
using CRUD_WITH_SP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_WITH_SP.Controllers
{

   
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        // GET: Product
        public ProductController(IProduct product)
        {
            _product = product;
        }
        public ActionResult Index()
        {
            List<Product> products = _product.GetAll().ToList();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0) return NotFound();
            Product product = _product.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _product.Insert(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0) return NotFound();
            Product product = _product.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                if (id <= 0) return NotFound();
                if (ModelState.IsValid)
                {
                    _product.Update(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0) return NotFound();
            Product product = _product.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product)
        {
            try
            {

                _product.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
