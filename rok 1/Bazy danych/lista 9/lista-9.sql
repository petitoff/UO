-- zadanie p
SELECT City, Country, count(City) as liczba
FROM customers
group by City
order by City;

-- zadanie q
SELECT Country, count(Country) as liczba
FROM customers
GROUP BY Country
HAVING liczba > 1;

-- zadanie r
SELECT City, count(City) as liczba, Country
FROM customers
WHERE Country = 'France' OR Country = 'Spain'
GROUP BY City
HAVING liczba > 1;

-- zadanie s
SELECT DISTINCT OrderID, ProductID,  count(OrderID) as liczba
FROM orderdetails
group by (OrderID)
order by liczba desc;

-- zadanie t
SELECT ProductID, count(ProductID) as liczba
FROM orderdetails
group by (ProductID);
