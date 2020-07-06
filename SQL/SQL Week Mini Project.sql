--====1.1====
SELECT CustomerID, CompanyName, Address, City, PostalCode, Country
FROM Customers
WHERE City IN ('London', 'Paris');

--====1.2====
SELECT *
FROM Products
WHERE QuantityPerUnit LIKE '%bottle%';

--====1.3====
SELECT p.ProductName, s.CompanyName, s.Country
FROM Products p
INNER JOIN Suppliers s
	ON p.SupplierID = s.SupplierID
WHERE QuantityPerUnit LIKE '%bottle%';

--====1.4====
SELECT c.CategoryName, COUNT(*) AS "Products in Category"
FROM Products p
JOIN Categories c ON p.CategoryID = c.CategoryID
GROUP BY c.CategoryName
ORDER BY "Products in Category" DESC;

--====1.5====
SELECT TitleOfCourtesy + ' ' + FirstName + ' ' + LastName AS "Name", City
FROM Employees
WHERE Country = 'UK';

--====1.6====
SELECT r.RegionDescription, FORMAT(SUM(od.Quantity * (od.UnitPrice * (1 - od.Discount))),'c', 'en_GB') AS "Sales" 
FROM [Order Details] od
INNER JOIN Orders o
	ON od.OrderID = o.OrderID
INNER JOIN EmployeeTerritories et
	ON et.EmployeeID = o.EmployeeID
INNER JOIN Territories t
	ON et.TerritoryID = t.TerritoryID
INNER JOIN Region r
	ON t.RegionID = r.RegionID
GROUP BY r.RegionDescription
HAVING SUM(od.Quantity * (od.UnitPrice * (1 - od.Discount))) > 1000000
ORDER BY "Sales" DESC;

--====1.7====
SELECT COUNT(*) AS "No. of Orders"
FROM Orders
WHERE Freight > 100 AND (ShipCountry IN ('USA', 'UK'));

--====1.8====
SELECT TOP 1 OrderID, FORMAT(SUM((UnitPrice*Quantity) * Discount),'c', 'en-GB') AS "Discount Amount"
FROM [Order Details]
GROUP BY OrderID
ORDER BY SUM((UnitPrice * Quantity) * Discount) DESC

--====2.1====
CREATE TABLE Spartans
(
	SeperateTitle VARCHAR(20),
	FirstName VARCHAR(20),
	LastName VARCHAR(30),
	University VARCHAR(35),
	Course VARCHAR(30),
	Score INT
);

--====2.2====
INSERT INTO Spartans
VALUES
(
	'Mr.',
	'Harry',
	'Derbyshire',
	'University of Life',
	'Computer Science',
	90
),
(
    'Mr',
    'Christopher',
    'Norman',
    'University Of Bristol',
    'Physics',
    60
);

--====3.1====
SELECT e.FirstName + ' ' + e.LastName AS "Employee Name", m.FirstName + ' ' + m.LastName AS "Manager Name"
FROM Employees e
LEFT JOIN Employees m
	ON e.ReportsTo = m.EmployeeID
WHERE m.FirstName + ' ' + m.LastName IS NOT NULL

--====3.2====
SELECT s.CompanyName, SUM(od.Quantity * (od.UnitPrice * (1 - od.Discount))) AS "Supplier Total"
FROM [Order Details] od
INNER JOIN Products p
	ON od.ProductID = p.ProductID
INNER JOIN Suppliers s
	ON p.SupplierID = s.SupplierID
GROUP BY s.CompanyName
HAVING SUM(od.Quantity * (od.UnitPrice * (1 - od.Discount))) > 10000
ORDER BY SUM(od.Quantity * (od.UnitPrice * (1 - od.Discount))) DESC;

--====3.3====
SELECT TOP 10 c.customerID, c.CompanyName, FORMAT(SUM(od.Quantity * (od.UnitPrice * (1 - od.Discount))), 'c', 'en_GB') AS "Money Spent"
FROM [Order Details] od
INNER JOIN Orders o
	ON od.OrderID = o.OrderID
INNER JOIN Customers c
	ON o.CustomerID = c.CustomerID
WHERE OrderDate >
	(
	SELECT DATEADD(yyyy, -1, MAX(OrderDate))
	FROM Orders
	) AND o.ShippedDate IS NOT NULL 
GROUP BY c.CustomerID, c.CompanyName
ORDER BY SUM(od.Quantity * (od.UnitPrice * (1 - od.Discount))) DESC;

--====3.4====
SELECT MONTH(OrderDate) Month, YEAR(OrderDate) Year, AVG(CAST(DATEDIFF(d, OrderDate, ShippedDate) AS DECIMAL(10,2))) AS ShipTime 
FROM orders  
WHERE ShippedDate IS NOT NULL 
GROUP BY YEAR(OrderDate), MONTH(OrderDate) 
ORDER BY Year ASC, Month ASC 