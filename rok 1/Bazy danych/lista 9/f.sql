SELECT CustomerID, CustomerName, Address ||' '|| City ||' '|| PostalCode ||' '|| Country as FullAddress 
FROM Customers 
ORDER BY FullAddress;