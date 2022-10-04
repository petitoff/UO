SELECT Country, COUNT(*) as LiczbaKrajow
FROM Suppliers
WHERE Country='Germany'
GROUP BY Country;