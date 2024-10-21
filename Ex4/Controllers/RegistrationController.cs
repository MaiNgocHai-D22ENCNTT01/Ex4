using Ex4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ex4.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Details", model);
            }
            return View(model);
        }

        public ActionResult Details(RegistrationModel model)
        {
            return View(model);
        }
    }
}