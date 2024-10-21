using Ex4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ex4.Controllers
{
    public class HTMLHelperController : Controller
    {
        // GET: HTMLHelper
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FormRegister()
        {
            // Create list for drop-down list
            ViewBag.listCountry = new List<Country>() {
            new Country(){ID= "0",Name="-- Chọn Quốc Gia --"},
            new Country(){ID="VN" ,Name="Việt Nam"},
            new Country(){ID="AT",Name="AUSTRALIA"},
            new Country(){ID="UK",Name="Anh"},
            new Country(){ID="FR",Name="Pháp"},
            new Country(){ID="US",Name="Mỹ"},
            new Country(){ID="KP",Name="Hàn Quốc"},
            new Country(){ID="HU",Name="Hồng Kong"},
            new Country(){ID="CN",Name="Trung Quốc"},
        };

            return View();
        }

        public ActionResult Register()
        {

            // Retrieve values from form fields and pass them to the view
            TempData["UName"] = Request["txtUName"];
            TempData["Pass"] = Request["txtPass"];
            TempData["FName"] = Request["txtFName"];
            TempData["Gender"] = Request["Gender"];
            TempData["Address"] = Request["txtAddress"];
            TempData["Email"] = Request["txtEmail"];
            TempData["Country"] = Request["Country"];

            string fvr = "";
            if (Request["Reading"] != null && Request["Reading"].Contains("true")) fvr += "Reading, ";
            if (Request["Shopping"] != null && Request["Shopping"].Contains("true")) fvr += "Shopping, ";
            if (Request["Sport"] != null && Request["Sport"].Contains("true")) fvr += "Sport, ";

            // Remove the last comma and space, if any
            if (fvr.Length > 0)
            {
                fvr = fvr.Substring(0, fvr.Length - 2);
            }

            TempData["Favourist"] = fvr;

            return View();
        }
    }
}