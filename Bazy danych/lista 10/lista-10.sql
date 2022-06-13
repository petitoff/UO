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

SELECT *
FROM employees;