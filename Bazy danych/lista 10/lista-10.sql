-- zadanie 5
SELECT s.SupplierID, s.ContactName, p.ProductID, p.ProductName
FROM products AS p INNER JOIN suppliers as s ON p.SupplierID = s.SupplierID
WHERE s.Country = 'USA' AND p.UnitPrice > 20;

-- zadanie 7
SELECT products.ProductID, products.ProductName, categories.CategoryName, suppliers.Country
FROM products, categories, suppliers
WHERE categories.CategoryName = "Beverages" AND suppliers.Country = "USA"
GROUP BY products.ProductID;

-- zadanie 8
SELECT *
FROM employees
WHERE ReportsTo IS NULL;

-- zadanie 9
SELECT e1.EmployeeID, e1.LastName, e1.FirstName, e2.EmployeeID as KierownikID, e2.LastName, e2.FirstName
FROM employees as e1 INNER JOIN employees as e2 ON e1.ReportsTo = e2.EmployeeID;

-- zadanie 10
SELECT e1.EmployeeID, e1.LastName, e1.FirstName, e2.*
FROM employees as e1 LEFT OUTER JOIN employees as e2 ON e1.ReportsTo = e2.EmployeeID;

-- zadanie 11
SELECT c.*, o.*
FROM customers as c INNER JOIN orders AS o ON c.CustomerID = o.CustomerID
WHERE c.Country = 'France';

-- zadanie 12
SELECT c.CustomerID, COUNT(o.OrderID) as liczbaZamowien, c.ContactName
FROM customers as c INNER JOIN orders AS o ON c.CustomerID = o.CustomerID
WHERE c.Country = 'France'
GROUP BY c.CustomerID
HAVING liczbaZamowien > 1;

-- zadanie 13
SELECT c.CustomerID, Count(o.OrderID)
FROM orders as o RIGHT OUTER JOIN customers as c on c.CustomerID = o.CustomerID
WHERE c.Country = 'France'
GROUP BY c.CustomerID;

-- zadanie 14
SELECT *
FROM employees
WHERE City = (SELECT City FROM employees WHERE LastName = 'King' AND FirstName = 'Robert');

-- zadanie 15
SELECT *
FROM orders
WHERE CustomerID IN (SELECT CustomerID FROM customers WHERE Country = 'France' group by CustomerID)
GROUP BY OrderID;

-- zadanie 16
SELECT EmployeeID, LastName, FirstName
FROM employees
WHERE EmployeeID NOT IN(SELECT ReportsTo FROM employees WHERE ReportsTo IS NOT null);

-- zadanie 17
SELECT suppliers.SupplierID, suppliers.ContactName
FROM suppliers Inner JOIN (SELECT SupplierID FROM products INNER JOIN orderdetails on products.ProductID = orderdetails.ProductID where orderdetails.OrderID > 11000) as t2 on suppliers.SupplierID = t2.SupplierID;

-- zadanie 18
SELECT *
FROM (SELECT City, count(City) as liczba FROM employees GROUP BY City) AS t1 INNER JOIN (SELECT City, count(City) as liczba FROM employees GROUP BY City) AS t2 ON t1.liczba = t2.liczba
WHERE t1.City != t2.City;

-- zaadanie 19
SELECT categories.CategoryID, categories.CategoryName, t1.cena, t1.ProductID
FROM (SELECT CategoryID, MAX(UnitPrice) as cena, ProductID FROM products GROUP BY CategoryID) as t1 INNER JOIN categories ON t1.CategoryID = categories.CategoryID;

-- zadanie 20
SELECT t1.OrderID, t1.CenaMax, t2.CenaMin
FROM (SELECT OrderID, max(UnitPrice) as CenaMax FROM orderdetails group by OrderID) as t1 INNER JOIN (SELECT OrderID, min(UnitPrice) as CenaMin FROM orderdetails group by OrderID) as t2 on t1. OrderID = t2.OrderID;
