--5.1 
----total price of all orders
SELECT SUM(Price) FROM Orders
----products sold per order
SELECT AVG(oi.Quantity)
FROM Orders o
INNER JOIN OrderItems oi ON o.id=oi.Order_Id
---- largest in terms of unit price?
Sorry, dont understand the question

--5.2 Optimize
1. REMOVE 'price' FROM Orders TABLE AS it can be calculated BY OrderITems TABLE
 