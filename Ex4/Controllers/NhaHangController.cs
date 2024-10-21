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
    public class NhaHangController : Controller
    {
        // GET: NhaHang
        public ActionResult Index()
        {
            return View();
        }
        private NhaHang LoadData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NhaHang));
            using (FileStream fileStream = new FileStream(Server.MapPath("~/App_Data/NhaHang.xml"), FileMode.Open))
            {
                return (NhaHang)serializer.Deserialize(fileStream);
            }
        }
    }
}