using lab_42_xml_serialise.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace lab_42_xml_serialise
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            //List<Products> xmlProductsReadFromTheInternet = new List<Products>();

            using (var db = new NorthwindContext())
            {
                products = db.Products.Take(5).ToList(); // Only takes 5 entries
            }

            //products.ForEach(p => Console.WriteLine($"{p.ProductId}: {p.ProductName}"));

            var xmlProducts = new XElement(
                "Products",
                    from p in products
                    select new XElement("Product",
                        new XElement("ProductId", p.ProductId),
                        new XElement("ProductName", p.ProductName),
                        new XElement("UnitPrice", p.UnitPrice)
                    )
            );

            // Save document
            var xmlProductsDocument = new XDocument(xmlProducts);
            xmlProductsDocument.Save("Products.xml");

            // Print to check
            //Console.WriteLine(xmlProductsDocument);

            var XMlProducts = new Products();

            // Assume data being sent to us over the internet - it can be very large so safest to stream
            using (var reader = new StreamReader("Products.xml"))
            {
                // Deserialise from XML to Northwind Products
                var serialiser = new XmlSerializer(typeof(Products)); // Have to use typeof to tell it what it
                XMlProducts = (Products)serialiser.Deserialize(reader);
            }

            XMlProducts.ProductList.ForEach(p => Console.WriteLine($"{p.ProductId}: {p.ProductName} costs £{p.UnitPrice}"));

        }

      
    }

    //[XmlRoot("Products")]
    //public class Products
    //{
    //    [XmlElement("ProductID")]
    //    public int ProductId { get; set; }

    //    [XmlElement("ProductName")]
    //    public string ProductName { get; set; }

    //    [XmlElement("UnitPrice")]
    //    public decimal UnitPrice { get; set; }
    //}
}
