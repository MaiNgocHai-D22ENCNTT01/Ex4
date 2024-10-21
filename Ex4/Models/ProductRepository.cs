using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Ex4.Models
{
    public class ProductRepository
    {
        private string xmlFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Products.xml");

        public List<Product> GetAllProducts()
        {
            XElement xElement = XElement.Load(xmlFilePath);
            var products = from prod in xElement.Elements("Product")
                           select new Product
                           {
                               ProductId = prod.Element("ProductId").Value,
                               ProductName = prod.Element("ProductName").Value,
                               Unit = prod.Element("Unit").Value,
                               Price = int.Parse(prod.Element("Price").Value)
                           };
            return products.ToList();
        }

        public Product GetProductById(string id)
        {
            return GetAllProducts().FirstOrDefault(p => p.ProductId == id);
        }

        public void AddProduct(Product product)
        {
            XElement xElement = XElement.Load(xmlFilePath);
            xElement.Add(new XElement("Product",
                            new XElement("ProductId", product.ProductId),
                            new XElement("ProductName", product.ProductName),
                            new XElement("Unit", product.Unit),
                            new XElement("Price", product.Price)));
            xElement.Save(xmlFilePath);
        }

        public void UpdateProduct(Product product)
        {
            XElement xElement = XElement.Load(xmlFilePath);
            XElement prodElement = xElement.Elements("Product").FirstOrDefault(p => p.Element("ProductId").Value == product.ProductId);
            if (prodElement != null)
            {
                prodElement.Element("ProductName").Value = product.ProductName;
                prodElement.Element("Unit").Value = product.Unit;
                prodElement.Element("Price").Value = product.Price.ToString();
                xElement.Save(xmlFilePath);
            }
        }

        public void DeleteProduct(string id)
        {
            XElement xElement = XElement.Load(xmlFilePath);
            XElement prodElement = xElement.Elements("Product").FirstOrDefault(p => p.Element("ProductId").Value == id);
            if (prodElement != null)
            {
                prodElement.Remove();
                xElement.Save(xmlFilePath);
            }
        }
    }
}