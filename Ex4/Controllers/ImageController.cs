using Ex4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ex4.Controllers
{
    public class ImageController : Controller
    {
        private readonly string _imagePath = "~/Content/Images/";
        // GET: Image
        public ActionResult Index()
        {
            var images = Directory.GetFiles(Server.MapPath(_imagePath)).Select(x => new ImageModel
            {
                FileName = Path.GetFileName(x),
                FilePath = Url.Content(_imagePath + Path.GetFileName(x))
            }).ToList();

            return View(images);
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath(_imagePath), fileName);
                file.SaveAs(path);
            }
            else
            {
                ViewBag.Message = "No file selected or file is empty.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string fileName)
        {
            var path = Path.Combine(Server.MapPath(_imagePath), fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return RedirectToAction("Index");
        }
    }
}