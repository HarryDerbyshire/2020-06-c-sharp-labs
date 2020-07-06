--====London Employees====
SELECT *
FROM Employees
WHERE City = 'London';

SELECT DISTINCT City From Employees;

--====Alternative London Employees====
SELECT COUNT(*) AS "Number of employees in London"
FROM Employees
Where City = 'London';

--====Dr. role====
SELECT *
FROM Employees
WHERE TitleOfCourtesy = 'Dr.';

--====Discontinued products====
SELECT * FROM Products
WHERE Discontinued = 1;

--====Alternative discontinued products====
SELECT COUNT(*) AS "Number of discontinued products"
FROM Products
WHERE Discontinued = 1;

--====Selecting certain fields using specific arg====
SELECT CompanyName, City, Country, Region
FROM Customers
WHERE Region = 'BC';

--====Ordering by ContactName alphabetically can use DESC====
SELECT CompanyName, ContactName
FROM Customers
WHERE Country = 'France'
ORDER BY ContactName ASC;

--====Select the top x amount of results====
SELECT TOP 10 CompanyName, City
FROM Customers
WHERE Country = 'France';

--====The WHERE section is using a conditional can also have OR
SELECT ProductName, UnitPrice
FROM Products
WHERE CategoryID = 1 AND Discontinued = 0;

--====Using operators to define ranges====
SELECT ProductName, UnitPrice
FROM Products
WHERE UnitsInStock > 0 AND UnitPrice > 29.99;

--====DISTINCT removes the duplicates====
SELECT DISTINCT Country
FROM Customers
WHERE ContactTitle = 'Owner';

--====The INTO means that it creates a new table with the data from the query====
SELECT CompanyName, ContactName, Phone
INTO FrenchCustomers
FROM Customers
WHERE Country = 'France'

DROP TABLE FrenchCustomers;

--====We use LIKE instead of = when we are using wildcards because it isn't saying it is equal to it. The Ch% returns any result starting with Ch====
SELECT ProductName
FROM Products
WHERE ProductName LIKE 'Ch%';

--====The modulo in the front means that is any results ending in ager====
SELECT ProductName
FROM Products
WHERE ProductName LIKE '%ager';

--==== %char% will return aything with char in it regardless of position====
SELECT ProductName
FROM Products
WHERE ProductName LIKE '%ost%';

--====You can use [] to create a range of characters similar to RegEx====
SELECT ProductName
FROM Products
WHERE ProductName LIKE '%[zxy]%';

--====The underscore represents one single character====
SELECT *
FROM Customers
WHERE Region LIKE '_A';

--====Mini task showing the use of IN, IN is equiv of the second statement (like = OR =  )====
SELECT *
FROM Customers
WHERE Region IN ('WA', 'SP');

SELECT *
FROM Customers
WHERE Region = 'WA' OR Region = 'SP';

--====BETWEEN is just ranges====
SELECT *
FROM EmployeeTerritories
WHERE TerritoryID BETWEEN 06800 AND 09999;

--====Wildcards Task====
--==Task 1==
SELECT ProductName, ProductID
FROM Products
WHERE UnitPrice < 5;

--==Task 2==
SELECT CategoryName
FROM Categories
WHERE CategoryName LIKE '[BS]%'

--==Task 2 alternative==
SELECT CategoryName
FROM Categories
WHERE CategoryName LIKE 'B%' OR CategoryName LIKE 'S%';

--==Task 3==
SELECT COUNT(*) AS "No. of employees with ID 5 or 7"
FROM Orders
WHERE EmployeeID IN (5, 7);

--==Task 4==
SELECT CategoryName, Description
FROM Categories
WHERE CategoryName LIKE '[A-P]%';

--====Concatenation====
SELECT CompanyName AS "Company Name", City + ', ' + Country AS "City"
FROM Customers;

--==Employee Details==
SELECT FirstName + ' ' + LastName + ': ' + HomePhone AS "Employee Name and Contact Number"
FROM Employees;

--====NULL Theory====
--==Lists all Companies with NULL Regions==
SELECT CompanyName AS "Company Name", City + ', ' + Country AS City
FROM Customers
WHERE Region IS NULL;

--==Lists all Companies without NULL Regions==
SELECT CompanyName AS "Company Name", City + ', ' + Country AS City
FROM Customers
WHERE Region IS NOT NULL;

--==Lists all countries that have a region associated==
SELECT DISTINCT Country
FROM Customers
WHERE Region IS NOT NULL;

--====Arithmetic Operators====
--==Calculating Gross Total
SELECT UnitPrice, Quantity, Discount, UnitPrice * Quantity AS "Gross Total"
FROM [Order Details]; --Note square brackets for table names with spaces

--==Calculating percentage==
SELECT UnitPrice, Quantity, Discount, UnitPrice * Quantity * (1 - Discount) AS "Gross Total with Discount applied"
FROM [Order Details];

--==Ordering by discounted price using the alias column name==
SELECT UnitPrice, Quantity, Discount, UnitPrice * Quantity * (1 - Discount) AS "Gross Total with Discount applied"
FROM [Order Details]
ORDER BY "Gross Total with Discount applied";

--==Still ordering by discounted price but saying order by 4th column instead of specifying it==
SELECT UnitPrice, Quantity, Discount, UnitPrice * Quantity * (1 - Discount) AS "Gross Total with Discount applied"
FROM [Order Details]
ORDER BY 4;

--====String Functions====
--==Selects a portion of string based on parameters ([string], start, length)==
SELECT SUBSTRING ('Alex', 2, 3);

--==Shows the character index for the given string==
SELECT CHARINDEX('ry', 'Harry');

--==Shows first characters going from the start==
SELECT LEFT('Chen', 3);

--==Shows the last characters going from end==
SELECT RIGHT('Christian', 3);

--==Removes spaces==
SELECT LTRIM('               Bruno           ');
SELECT RTRIM('               Bruno           ');
SELECT TRIM('                Bruno           '); --Doesn't work in Visual Studio

--==Replaces all 'i' with 'a'==
SELECT REPLACE('Nish', 'i', 'a');

--==To uppercase and lowercase==
SELECT UPPER('leo');
SELECT LOWER('LEO');

--==Shows the first section of a postcode by locating the space and giving all characters to the left of it
SELECT PostalCode AS 'Post Code',
LEFT(PostalCode, CHARINDEX(' ', PostalCode) - 1) AS 'Post Code Region',
CHARINDEX(' ', PostalCode) AS 'Space Found',
Country
FROM Customers
WHERE Country = 'UK';

--==Filters the list by whether or not it contains the character ' ==
SELECT ProductName
FROM Products
WHERE CHARINDEX('''', ProductName) != 0;

--==Returns current date==
SELECT GETDATE();

--==Uses the system time==
SELECT SYSDATETIME();

--!!Note you can use d/dd for days, M/MM for months and yy/yyyy for years (months has to be capitilised as minutes is lower ==
--==Date add increases the date by specified value==
SELECT DATEADD(dd, 5, ColumnName) AS "Due Date";

--==Adds 5 days to current date==
SELECT DATEADD(dd, 5, GETDATE());

--==DATEDIFF example - earlier date goes first to avoid negative days
SELECT DATEDIFF(dd, '2020-05-06', '2021-05-06') AS "A length of a year";

--==FORMAT function, for example can change yyyy to yy or change the dividing / to a . ==
SELECT FORMAT(OrderDate, 'dd/MM/yyyy')
FROM Orders;

--==Formats a currency 'C' as a UK currency 'en-GB' 18.00 displays as £18.00
SELECT FORMAT(UnitPrice, 'C', 'en-GB')
FROM Products;

--==Calculating somebody's age using days divided by a year which then has mathmatical function FLOOR which always rounds down
--!!Note you can use CAST ([name] AS DATATYPE to use a value as a certain data type - in example it is setting it as a date
SELECT FirstName + ' ' + LastName AS "Name", FLOOR(DATEDIFF(dd, CAST (BirthDate AS DATE), GETDATE()) / 365.25) AS "Age"
FROM Employees;

--====Basic SELECT CASE statement====
SELECT
CASE
WHEN DATEDIFF(dd, OrderDate, GETDATE()) < 10 THEN 'On Time'
ELSE 'Overdue'
END AS 'Status'
FROM Orders;

--==Two levels of SELECT CASE==
SELECT FirstName + ' ' + LastName AS "Name",
CASE
WHEN FLOOR(DATEDIFF(dd, CAST (BirthDate AS DATE), GETDATE()) / 365.25) > 65 THEN 'Retired'
WHEN FLOOR(DATEDIFF(dd, CAST (BirthDate AS DATE), GETDATE()) / 365.25) > 60 THEN 'Retirement due'
ELSE 'More than five years to go'
END AS 'Status'
FROM Employees;

--====Aggregate Functions====
--==All columns selected by SELECT statement must then appear if you use a GROUP BY==
SELECT SupplierID,
	SUM(UnitsOnOrder) AS "Total On Order",
	AVG(UnitsOnOrder) AS "Avg On Order",
	MIN(UnitsOnOrder) AS "Min On Order",
	MAX(UnitsOnOrder) AS "Max On Order"
FROM Products
GROUP BY SupplierID;

--===Aggregate Tasks===
--==Task 1==
SELECT CategoryID,
	AVG(ReorderLevel) AS "Average Reorder Level"
FROM Products
GROUP BY CategoryID;

--==Task 2==
SELECT CategoryID,
	AVG(ReorderLevel) AS "Average Reorder Level"
FROM Products
GROUP BY CategoryID
ORDER BY "Average Reorder Level" DESC; --Could be written as AVG(ReorderLevel) instead of using the alias

--==HAVING statement is used instead of WHERE during aggregates==
SELECT SupplierID,
	SUM(UnitsOnOrder) AS "Total On Order",
		AVG(UnitsOnOrder) AS "Average On Order"
FROM Products
GROUP BY SupplierID
HAVING AVG(UnitsOnOrder) > 10; --Only show rows that have an average value greater than ten

--!!Note that you can use HAVING to completely replace WHERE however you must include the GROUP BY
SELECT SupplierID, ProductName
FROM Products
GROUP BY SupplierID, ProductName
HAVING ProductName LIKE '%ng';

--==Another HAVING example using an INNER JOIN==
SELECT e.EmployeeID, e.FirstName + ' ' + e.LastName AS "Name",
	COUNT(TerritoryID) AS 'Number of territories covered'
FROM EmployeeTerritories et
INNER JOIN Employees e
	ON e.EmployeeID = et.EmployeeID
GROUP BY e.EmployeeID, e.FirstName, e.LastName
HAVING COUNT(TerritoryID) > 5;

--===INNER JOIN Task===
SELECT s.SupplierID, s.CompanyName,
	AVG(p.UnitsOnOrder) AS "Average On Order"
FROM Products p
INNER JOIN Suppliers s
	ON p.SupplierID = s.SupplierID
GROUP BY s.SupplierID, s.CompanyName
HAVING AVG(p.UnitsOnOrder) != 0 --Gets rids of all zero values
ORDER BY "Average On Order" DESC;

--==Two INNER JOINs linking three tables Products, Suppliers and Categories==
SELECT p.ProductName, p.UnitPrice, s.CompanyName AS "Supplier", c.CategoryName AS "Category"
FROM Products p
INNER JOIN Suppliers s 
	ON p.SupplierID = s.SupplierID
INNER JOIN Categories c 
	ON p.CategoryID = c.CategoryID;

--==Another example of joining three tables together==
SELECT o.OrderID, o.OrderDate, o.Freight, e.FirstName + ' ' + e.LastName AS "Employee Name", c.CompanyName AS "Customer Name"
FROM Orders o
INNER JOIN Customers c
	ON o.CustomerID = c.CustomerID
INNER JOIN Employees e
	ON  o.EmployeeID = e.EmployeeID
ORDER BY "Employee Name";

--====Subqueries are nested queries here we are using a WHERE statement to achieve this====
--==Both below statements produce the same results, one uses nested queries and the other using joins==
SELECT CompanyName AS "Customer"
FROM Customers
WHERE CustomerID NOT IN
	(SELECT CustomerID FROM Orders);

SELECT c.CompanyName AS "Customer", o.OrderID
FROM Customers c
LEFT JOIN Orders o
	ON c.CustomerID = o.CustomerID
WHERE o.OrderID IS NULL;

--==SELECT subquery, subquery is executed first
SELECT OrderID, ProductID, UnitPrice, Quantity, Discount,
	(SELECT MAX(UnitPrice)
	FROM [Order Details]) AS "Max Price"
FROM [Order Details];

--==Subquery mixed with an INNER JOIN==
SELECT od.ProductID, sq1.totalamt AS "Total Sold for this Product", UnitPrice, UnitPrice / totalamt * 100 AS "% of Total"
FROM [Order Details] od
INNER JOIN
	(SELECT ProductID, SUM(UnitPrice * Quantity) AS totalamt
	FROM [Order Details]
GROUP BY ProductID) sq1 ON sq1.ProductID = od.ProductID;


SELECT EmployeeID, FirstName FROM Employees;
SELECT SupplierID, CompanyName FROM Suppliers;
--!!Note UNION ALL shows all results produced including duplicates
SELECT e.EmployeeID, e.FirstName + ' ' + e.LastName AS "Employee/Supplier"
FROM Employees e
UNION ALL
	SELECT SupplierID
	FROM Suppliers s;

--==Subquery task==
--=Using nested SELECT=
SELECT od.OrderID, od.ProductID, od.UnitPrice, od.Quantity, od.Discount
FROM [Order Details] od
WHERE od.ProductID IN
	(SELECT p.ProductID
	FROM Products p
	WHERE p.Discontinued = 1);

--=Using INNER JOIN=
SELECT od.OrderID, od.ProductID, od.UnitPrice, od.Quantity, od.Discount
FROM [Order Details] od
INNER JOIN Products p
	ON od.ProductID = p.ProductID
WHERE p.Discontinued = 1;

