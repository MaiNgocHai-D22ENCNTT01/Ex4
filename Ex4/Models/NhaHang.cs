using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Ex4.Models
{
    [XmlRoot("NhaHang")]
    public class NhaHang
    {
        [XmlElement("Category")]
        public List<Category> Categories { get; set; }
    }
}