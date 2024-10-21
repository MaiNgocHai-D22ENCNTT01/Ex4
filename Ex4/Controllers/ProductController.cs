using Ex4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Ex4.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository _repository = new ProductRepository();
        // GET: Product
        private NhaHang LoadData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NhaHang));
            using (FileStream fileStream = new FileStream(Server.MapPath("~/App_Data/NhaHang.xml"), FileMode.Open))
            {
                return (NhaHang)serializer.Deserialize(fileStream);
            }
        }

        public ActionResult Index(string categoryId)
        {
            NhaHang nhaHang = LoadData();
            ViewBag.Categories = nhaHang.Categories;
            if (string.IsNullOrEmpty(categoryId))
            {
                return View(nhaHang.Categories.SelectMany(c => c.Products).ToList()); // Lấy tất cả sản phẩm
            }
            var category = nhaHang.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            return View(category?.Products ?? new List<Product>());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Edit(string id)
        {
            var product = _repository.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Delete(string id)
        {
            var product = _repository.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            _repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}