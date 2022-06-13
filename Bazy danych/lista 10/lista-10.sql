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