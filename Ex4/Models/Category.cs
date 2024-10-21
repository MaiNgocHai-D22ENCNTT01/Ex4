using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Ex4.Models
{
    public class Category
    {
        [XmlAttribute("CategoryId")]
        public string CategoryId { get; set; }

        [XmlAttribute("CategoryName")]
        public string CategoryName { get; set; }

        [XmlElement("Product")]
        public List<Product> Products { get; set; } = new List<Product>(); // Initialize the list

        // Optional: A parameterless constructor
        public Category()
        {
            Products = new List<Product>(); // Ensure the list is initialized
        }
    }
}
