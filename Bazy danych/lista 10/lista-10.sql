-- zadanie 7
SELECT products.ProductID, products.ProductName, categories.CategoryName, suppliers.Country
FROM products, categories, suppliers
WHERE categories.CategoryName = "Beverages" AND suppliers.Country = "USA"
GROUP BY products.ProductID;

-- zadanie 8
SELECT *
FROM employees
WHERE ReportsTo IS NULL;

