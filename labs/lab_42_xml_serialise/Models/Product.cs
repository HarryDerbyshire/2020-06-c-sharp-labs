using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace lab_42_xml_serialise.Models
{
    [Serializable]
    public partial class Product
    {
        [XmlElement("ProductId")]
        public int ProductId { get; set; }
        [XmlElement("ProductName")]
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        [XmlElement("UnitPrice")]
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }

    [XmlRoot("Products")]
    public class Products
    {
        [XmlElement("Product")]
        public List<Product> ProductList { get; set; }
    }
}
