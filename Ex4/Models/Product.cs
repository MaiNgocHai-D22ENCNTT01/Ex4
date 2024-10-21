using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Ex4.Models
{
    public class Product
    {
        [XmlElement("ProductId")]
        public string ProductId { get; set; }

        [XmlElement("ProductName")]
        public string ProductName { get; set; }

        [XmlElement("Unit")]
        public string Unit { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}