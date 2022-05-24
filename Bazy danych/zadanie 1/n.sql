SELECT Country, COUNT(*) as LiczbaKrajow
FROM Customers
GROUP BY Country;