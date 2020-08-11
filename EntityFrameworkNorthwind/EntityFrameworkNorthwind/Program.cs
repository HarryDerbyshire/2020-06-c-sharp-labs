using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Linq;
using System.Threading;

namespace EntityFrameworkNorthwind
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                #region Example Code
                //var orderQuery =
                //    from order in db.Orders
                //    where order.Freight > 750
                //    select order;

                //foreach (var order in orderQuery)
                //{
                //    Console.WriteLine($"{order.CustomerId} paid {order.Freight} for shipping to {order.ShipCity}");
                //}

                //var orderQuerywithCust =
                //    from order in db.Orders.Include(o => o.Customer)
                //    where order.Freight > 750
                //    select order;

                //foreach (var order in orderQuerywithCust)
                //{
                //    if (order.Customer != null) //To avoid null pointer exceptions if there is no customer associated
                //        Console.WriteLine($"{order.Customer.ContactName} of {order.Customer.City} paid {order.Freight} for shipping");
                //}

                //var orderQueryUsingInnerJoin =
                //    from order in db.Orders
                //    where order.Freight > 750
                //    join customer in db.Customers on order.CustomerId equals customer.CustomerId
                //    select new { CustomerContactName = customer.ContactName, City = customer.City, Freight = order.Freight };

                //foreach (var result in orderQueryUsingInnerJoin)
                //{
                //    Console.WriteLine($"{result.CustomerContactName} of {result.City} paid {result.Freight} for shipping");
                //}
                #endregion

                #region Exercise 1
                #region 1.1
                var query1p1 =
                    from customer in db.Customers
                    where customer.City == "London" || customer.City == "Paris"
                    select customer;

                foreach (var result in query1p1)
                {
                    Console.WriteLine($"{result.CustomerId}: {result.CompanyName} is based in {result.Address}, {result.PostalCode}, {result.City}");
                }

                //1.1 using Lambda syntax
                var query1p1Lambda = db.Customers.Where(c => c.City == "London" || c.City == "Paris");

                Console.WriteLine("Exercise 1.1:\n");
                foreach (var result in query1p1Lambda)
                {
                    Console.WriteLine($"{result.CustomerId}: {result.CompanyName} is based in {result.Address}, {result.PostalCode}, {result.City}");
                }
                #endregion
                #region 1.2
                var query1p2 = db.Products.Where(p => p.QuantityPerUnit.Contains("bottle"));

                Console.WriteLine("\nExercise 1.2:\n");
                foreach (var result in query1p2)
                {
                    Console.WriteLine($"{result.ProductId}: {result.ProductName}");
                }
                #endregion
                #region 1.3
                var query1p3 =
                    from product in db.Products
                    where product.QuantityPerUnit.Contains("bottle")
                    join supplier in db.Suppliers on product.SupplierId equals supplier.SupplierId
                    select new { productId = product.ProductId, productName = product.ProductName, supplierName = supplier.CompanyName, supplierCountry = supplier.Country };

                Console.WriteLine("\nExercise 1.3:\n");
                foreach (var result in query1p3)
                {
                    Console.WriteLine($"{result.productId}: {result.productName} from {result.supplierName} based in {result.supplierCountry}");
                }
                #endregion
                #region 1.4
                var query1p4 =
                    from product in db.Products
                    join category in db.Categories on product.CategoryId equals category.CategoryId
                    group product by category.CategoryName into results
                    select new { Category = results.Key, ProductCount = results.Count() };

                Console.WriteLine("\nExercise 1.4:\n");
                foreach (var result in query1p4)
                {
                    Console.WriteLine($"{result.Category}: {result.ProductCount}");
                }
                #endregion
                #region 1.5
                var query1p5 = db.Employees.Where(e => e.Country == "UK");

                Console.WriteLine("\nExercise 1.5:\n");

                foreach (var result in query1p5)
                {
                    Console.WriteLine($"{result.TitleOfCourtesy} {result.FirstName} {result.LastName} lives in {result.City}");
                }
                #endregion
                #region 1.6
                var query1p6 =
                    from orderDetails in db.OrderDetails
                    join order in db.Orders on orderDetails.OrderId equals order.OrderId
                    join employeeTerritory in db.EmployeeTerritories on order.EmployeeId equals employeeTerritory.EmployeeId
                    join territory in db.Territories on employeeTerritory.TerritoryId equals territory.TerritoryId
                    join region in db.Region on territory.RegionId equals region.RegionId
                    group orderDetails by region.RegionDescription into results
                    where results.Sum(od => od.Quantity * (od.UnitPrice * (1 - (decimal)od.Discount))) > 1000000
                    select new {region = results.Key, salesTotal = results.Sum(od => od.Quantity * (od.UnitPrice * (1 - (decimal)od.Discount)))};

                Console.WriteLine("\nExercise 1.6\n");

                foreach(var result in query1p6)
                {
                    Console.WriteLine($"{result.region.Trim()}: {result.salesTotal}");
                }
                #endregion
                #region 1.7
                var query1p7Lambda = db.Orders.Where(o => o.Freight > 100 && (o.ShipCountry == "USA" || o.ShipCountry == "UK")).Count();
                Console.WriteLine("\nExercise 1.7:\n");
              
                Console.WriteLine(query1p7Lambda);

                #endregion
                #endregion
            }

        }
    }
}
