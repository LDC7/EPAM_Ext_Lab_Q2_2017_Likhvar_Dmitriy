USE NORTHWND

--1.1
--������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (������� ShippedDate) ������������
--� ������� ���������� � ShipVia >= 2. ������ �������� ���� ������ ���� ������ ��� ����� ������������ ����������,
--�������� ����������� ������ �Writing International Transact-SQL Statements� � Books Online ������ �Accessing and
--Changing Relational Data Overview�. ���� ����� ������������ ����� ��� ���� �������. 
--������ ������ ����������� ������ ������� OrderID, ShippedDate
--� ShipVia. �������� ������ ���� �� ������ ������ � NULL-�� � ������� ShippedDate.
SELECT OrderID, ShippedDate, ShipVia
FROM Orders
WHERE ShippedDate >= CONVERT(DATETIME, '19980506', 101)
	AND ShipVia >= 2
--��������� null � ����� - unknown

--1.2
--�������� ������, ������� ������� ������ �������������� ������ �� ������� Orders.
--� ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL ������ �Not Shipped�
-- � ������������ ��������� ������� CAS�. ������ ������ ����������� ������ ������� OrderID � ShippedDate.
SELECT OrderID,
	CASE WHEN ShippedDate IS NULL THEN 'Not Shipped' END AS ShippedDate
FROM Orders
WHERE ShippedDate IS NULL

--1.3
--������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (ShippedDate) �� ������� ��� ����
--��� ������� ��� �� ����������. � ������� ������ ������������� ������ ������� OrderID (������������� � Order Number)
--� ShippedDate (������������� � Shipped Date). � ����������� ������� ����������� ��� ������� ShippedDate ������
--�������� NULL ������ �Not Shipped�, ��� ��������� �������� ����������� ���� � ������� �� ���������.
SELECT OrderID 'Order Number',
	CASE WHEN ShippedDate IS NULL THEN 'Not Shipped' END AS 'Shipped Date'
FROM Orders
WHERE ShippedDate > CONVERT(DATETIME, '19980506', 101)
	OR ShippedDate IS NULL

--2.1
--������� �� ������� Customers ���� ����������, ����������� � USA � Canada. ������ ������� � ������ ������� ��������� IN.
--����������� ������� � ������ ������������ � ��������� ������ � ����������� �������.
--����������� ���������� ������� �� ����� ���������� � �� ����� ����������.
SELECT CompanyName, Country
FROM Customers C
WHERE Country IN ( 'USA', 'Canada')
ORDER BY CompanyName, C.Address

--2.2
--������� �� ������� Customers ���� ����������, �� ����������� � USA � Canada.
--������ ������� � ������� ��������� IN. ����������� ������� � ������ ������������ � ��������� ������ � ����������� �������.
--����������� ���������� ������� �� ����� ����������.
SELECT CompanyName, Country
FROM Customers
WHERE Country NOT IN ( 'USA', 'Canada')
ORDER BY CompanyName

--2.3
--������� �� ������� Customers ��� ������, � ������� ��������� ���������. 
--������ ������ ���� ��������� ������ ���� ��� � ������ ������������ �� ��������. 
--�� ������������ ����������� GROUP BY. ����������� ������ ���� ������� � ����������� �������.
SELECT DISTINCT Country
FROM Customers
ORDER BY Country DESC

--3.1
--������� ��� ������ (OrderID) �� ������� Order Details (������ �� ������ �����������),
--��� ����������� �������� � ����������� �� 3 �� 10 ������������ � ��� ������� Quantity � ������� Order Details.
--������������ �������� BETWEEN. ������ ������ ����������� ������ ������� OrderID.
SELECT DISTINCT OrderID
FROM [Order Details]
WHERE Quantity BETWEEN 3 AND 10

--3.2
--������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� ����� �� ��������� b � g.
--������������ �������� BETWEEN. ���������, ��� � ���������� ������� �������� Germany. ������ ������ �����������
--������ ������� CustomerID � Country � ������������ �� Country.
SELECT CustomerID, Country
FROM Customers
WHERE LEFT(Country, 1) BETWEEN 'B' AND 'G'
ORDER BY Country

--3.3
--������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� ����� �� ��������� b � g,
--�� ��������� �������� BETWEEN. � ������� ����� �Execution Plan� ���������� ����� ������ ���������������� 3.2 ��� 3.3
--� ��� ����� ���� ������ � ������ ���������� ���������� Execution Plan-a ��� ���� ���� ��������, ���������� ����������
--Execution Plan ���� ������ � ������ � ���� ����������� � �� �� ����������� ���� ����� �� ������ � �� ������ ���������
--���� ��������� ���������. ������ ������ ����������� ������ ������� CustomerID � Country � ������������ �� Country.
SELECT CustomerID, Country
FROM Customers
WHERE LEFT(Country, 1) >= 'B' AND LEFT(Country, 1) <= 'G'
ORDER BY Country
--������ 1:
--��������� ������� (�� ��������� � ������): 50%
--SELECT ���������: 0%
--���������� ���������: 71%
--Clustered Index Scan ���������: 29%
--������� 2:
--����������
-- ��������� ��������� �� �������������� ��������� ���������

--4.1
--� ������� Products ����� ��� �������� (������� ProductName), ��� ����������� ��������� 'chocolade'.
--��������, ��� � ��������� 'chocolade' ����� ���� �������� ���� ����� 'c' � �������� - ����� ��� ��������,
--������� ������������� ����� �������. ���������: ���������� ������� ������ ����������� 2 ������.
SELECT ProductName
FROM Products
WHERE ProductName LIKE '%cho_olade%'

--5.1
--����� ����� ����� ���� ������� �� ������� Order Details � ������ ���������� ����������� ������� � ������ �� ���. ���������
--��������� �� ����� � ��������� � ����� 1 ��� ���� ������ money. ������ (������� Discount) ���������� ������� �� ��������� ���
--������� ������. ��� ����������� �������������� ���� �� ��������� ������� ���� ������� ������ �� ��������� � �������
--UnitPrice ����. ����������� ������� ������ ���� ���� ������ � ����� �������� � ��������� ������� 'Totals'.
SELECT CONVERT(money, ROUND(SUM(UnitPrice - (UnitPrice * Discount)), 2), 1) 'Totals'
FROM [Order Details]

--5.2
--�� ������� Orders ����� ���������� �������, ������� ��� �� ���� ���������� (�.�. � ������� ShippedDate ��� �������� ����
--��������). ������������ ��� ���� ������� ������ �������� COUNT. �� ������������ ����������� WHERE � GROUP.
SELECT COUNT(ShippedDate)
FROM Orders

--5.3
--�� ������� Orders ����� ���������� ��������� ����������� (CustomerID), ��������� ������.
--������������ ������� COUNT � �� ������������ ����������� WHERE � GROUP.
SELECT COUNT(DISTINCT(CustomerID))
FROM Orders

--6.1
--�� ������� Orders ����� ���������� ������� � ������������ �� �����. � ����������� ������� ���� ����������� ��� ������� c
--���������� Year � Total. �������� ����������� ������, ������� ��������� ���������� ���� �������.
SELECT YEAR(OrderDate) 'Year', COUNT(OrderDate) 'Total'
FROM Orders
GROUP BY YEAR(OrderDate)
SELECT COUNT(OrderDate)
FROM Orders

--6.2
--�� ������� Orders ����� ���������� �������, c�������� ������ ���������. ����� ��� ���������� �������� � ��� ����� ������ �
--������� Orders, ��� � ������� EmployeeID ������ �������� ��� ������� ��������. � ����������� ������� ���� �����������
--������� � ������ �������� (������ ������������� ��� ���������� ������������� LastName & FirstName. ��� ������
--LastName & FirstName ������ ���� �������� ��������� �������� � ������� ��������� �������. ����� �������� ������ ������
--������������ ����������� �� EmployeeID.) � ��������� ������� �Seller� � ������� c ����������� ������� ����������� � ���������
--'Amount'. ���������� ������� ������ ���� ����������� �� �������� ���������� �������.
SELECT COUNT(EmployeeID) 'Amount', (
	SELECT CONCAT(e.LastName, e.FirstName)
	FROM Employees e
	WHERE e.EmployeeID = o.EmployeeID
	) 'Seller'
FROM Orders o
GROUP BY o.EmployeeID
ORDER BY 'Amount'

--6.3
--�� ������� Orders ����� ���������� �������, c�������� ������ ��������� � ��� ������� ����������. ���������� ���������� ���
--������ ��� ������� ��������� � 1998 ����. � ����������� ������� ���� ����������� ������� � ������ �������� (�������� �������
--�Seller�), ������� � ������ ���������� (�������� ������� �Customer�) � ������� c ����������� ������� ����������� �
--��������� 'Amount'. � ������� ���������� ������������ ����������� �������� ����� T-SQL ��� ������ � ����������
--GROUP (���� �� �������� ������� �������� ������ �ALL� � ����������� �������). ����������� ������ ���� ������� ��
--ID �������� � ����������. ���������� ������� ������ ���� ����������� �� ��������, ���������� � �� �������� ����������
--������. � ����������� ������ ���� ������� ���������� �� ��������. �.�. � ������������� ������ ������ ��������������
--������������� � ���������� � �������� �������� ��� ������� ���������� ��������� �������
SELECT
	CASE WHEN GROUPING(CONCAT(LastName, ' ', FirstName)) = 1 THEN 'ALL'
		ELSE CONCAT(LastName, ' ', FirstName)
	END 'Seller',
	CASE WHEN GROUPING(c.CompanyName) = 1 THEN 'ALL'
		ELSE c.CompanyName
	END 'Customer',
	COUNT(o.EmployeeID) 'Amount'
FROM Orders o
JOIN Customers c ON c.CustomerID = o.CustomerID
JOIN Employees e ON e.EmployeeID = o.EmployeeID
WHERE YEAR(OrderDate) = 1998
GROUP BY CUBE(CONCAT(LastName, ' ', FirstName), c.CompanyName)
ORDER BY 'Seller', 'Customer', 'Amount'

--6.4
--����� ����������� � ���������, ������� ����� � ����� ������. ���� � ������ ����� ������ ���� ��� ��������� ��������� ���
--������ ���� ��� ��������� �����������, �� ���������� � ����� ���������� � ��������� �� ������ �������� � ��������������
--�����. �� ������������ ����������� JOIN. � ����������� ������� ���������� ������� ��������� ��������� ��� �����������
--�������: �Person�, �Type� (����� ���� �������� ������ �Customer� ��� �Seller� � ��������� �� ���� ������), �City�. �������������
--���������� ������� �� ������� �City� � �� �Person�.

SELECT DISTINCT c.CompanyName 'Person', 'Customer' 'Type', c.City 'City'
FROM Customers c
WHERE c.City IN (
	SELECT DISTINCT City
	FROM Employees
	)
UNION
SELECT DISTINCT CONCAT(e.LastName, ' ', e.FirstName) 'Person', 'Seller' 'Type', e.City 'City'
FROM Employees e
WHERE e.City IN (
	SELECT DISTINCT City
	FROM Customers
	)
ORDER BY 'City', 'Person'

--6.5
--����� ���� �����������, ������� ����� � ����� ������. � ������� ������������ ���������� ������� Customers c ����� -
--��������������. ��������� ������� CustomerID � City. ������ �� ������ ����������� ����������� ������. ��� �������� ��������
--������, ������� ����������� ������, ������� ����������� ����� ������ ���� � ������� Customers. ��� �������� ���������
--������������ �������.
SELECT DISTINCT c1.CustomerID, c2.City
FROM Customers c1
JOIN Customers c2 ON c1.City = c2.City
WHERE c1.CustomerID != c2.CustomerID
--��������
SELECT c.City,  COUNT(c.City)
FROM Customers c
GROUP BY c.City
HAVING COUNT(c.City) > 1

--6.6
--�� ������� Employees ����� ��� ������� �������� ��� ������������, �.�. ���� �� ������ �������. ��������� ������� �
--������� 'User Name' (LastName) � 'Boss'. � �������� ������ ���� ��������� ����� �� ������� LastName. ��������� �� ���
--�������� � ���� �������?
SELECT e1.LastName 'User Name', e2.LastName 'Boss'
FROM Employees e1
JOIN Employees e2 ON e1.ReportsTo = e2.EmployeeID
--���. � ����-�� ��� �����.

--7.1
--���������� ���������, ������� ����������� ������ 'Western' (������� Region). ���������� ������� ������ ����������� ���
--����: 'LastName' �������� � �������� ������������� ���������� ('TerritoryDescription' �� ������� Territories). ������ ������
--������������ JOIN � ����������� FROM. ��� ����������� ������ ����� ��������� Employees � Territories ���� ������������
--����������� ��������� ��� ���� Northwind.
SELECT e.LastName, t.TerritoryDescription
FROM Employees e
JOIN EmployeeTerritories et ON et.EmployeeID = e.EmployeeID
JOIN Territories t ON et.TerritoryID = t.TerritoryID
JOIN Region r ON r.RegionID = t.RegionID
WHERE r.RegionDescription = 'Western'

--8.1
--��������� � ����������� ������� ����� ���� ���������� �� ������� Customers � ��������� ���������� �� ������� �� �������
--Orders. ������� �� ��������, ��� � ��������� ���������� ��� �������, �� ��� ����� ������ ���� �������� � �����������
--�������. ����������� ���������� ������� �� ����������� ���������� �������.
SELECT c.CompanyName, COUNT(o.OrderID) 'Orders'
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CompanyName
ORDER BY 'Orders'

--9.1
--��������� ���� ����������� ������� CompanyName � ������� Suppliers, � ������� ��� ���� �� ������ �������� �� ������
--(UnitsInStock � ������� Products ����� 0). ������������ ��������� SELECT ��� ����� ������� � ��������������
--��������� IN. ����� �� ������������ ������ ��������� IN �������� '=' ?
SELECT s.CompanyName
FROM Suppliers s
WHERE s.SupplierID IN (
	SELECT p.SupplierID
	FROM Products p
	WHERE p.UnitsInStock = 0
	)
--������. ��������� ������ ������ ������ ������ ��������.

--10.1
--��������� ���� ���������, ������� ����� ����� 150 �������. ������������ ��������� ��������������� SELECT.
SELECT e.LastName
FROM Employees e
WHERE 150 < (
	SELECT COUNT(o.EmployeeID)
	FROM Orders o
	WHERE e.EmployeeID = o.EmployeeID
	)

--11.1
--��������� ���� ���������� (������� Customers), ������� �� ����� �� ������ ������ (��������� �� ������� Orders).
--������������ ��������������� SELECT � �������� EXISTS.
SELECT c.CompanyName
FROM Customers c
WHERE NOT EXISTS (
	SELECT o.CustomerID
	FROM Orders o
	WHERE c.CustomerID = o.CustomerID
	)

--12.1
--��� ������������ ����������� ��������� Employees ��������� �� ������� Employees ������ ������ ��� ���� ��������, � �������
--���������� ������� Employees (������� LastName ) �� ���� �������. ���������� ������ ������ ���� ������������ �� �����������.
SELECT DISTINCT(LEFT(LastName, 1)) 'ABC'
FROM Employees
ORDER BY 'ABC'

--13.1
--�������� ���������, ������� ���������� ����� ������� ����� ��� ������� �� ��������� �� ������������ ���. � ����������� ��
--����� ���� ��������� ������� ������ ��������, ������ ���� ������ ���� � ����� �������. � ����������� ������� ������ ����
--�������� ��������� �������: ������� � ������ � �������� �������� (FirstName � LastName � ������: Nancy Davolio), �����
--������ � ��� ���������. � ������� ���� ��������� Discount ��� ������� �������. ��������� ���������� ���, �� ������� ����
--������� �����, � ���������� ������������ �������. ���������� ������� ������ ���� ����������� �� �������� ����� ������.
--��������� ������ ���� ����������� � �������������� ��������� SELECT � ��� ������������� ��������. �������� �������
--�������������� GreatestOrders. ���������� ������������������ ������������� ���� ��������. ����� ������ ������������
--������� �������� � ������� Query.sql ���� �������� ��������� �������������� ����������� ������ ��� ������������
--������������ ������ ��������� GreatestOrders. ����������� ������ ������ �������� � ������� ��� ��������� � ������������
--������ �������� ���� ��� ������������� �������� ��� ���� ��� ������� �� ������������ ��������� ��� � ����������� ���������
--�������: ��� ��������, ����� ������, ����� ������. ����������� ������ �� ������ ��������� ������, ���������� � ���������, - ��
--������ ��������� ������ ��, ��� ������� � ����������� �� ����. ��� ������� �� ������ �������� ������ ����
--�������� � ����� Query.sql � ��. ��������� ���� � ������� ����������� � �����������.
EXEC dbo.GreatestOrders 1998, 10
--�������� �� ����� (id = 1)
SELECT e.FirstName, e.LastName, o.OrderID, (od.Quantity * (od.UnitPrice - (od.UnitPrice * od.Discount))) 'Price'
FROM Employees e
JOIN Orders o ON o.EmployeeID = e.EmployeeID
JOIN [Order Details] od ON od.OrderID = o.OrderID
WHERE e.EmployeeID = 1 AND YEAR(o.OrderDate) = 1998
ORDER BY 'Price' DESC

--13.2
--�������� ���������, ������� ���������� ������ � ������� Orders, �������� ���������� ����� �������� � ����
--(������� ����� OrderDate � ShippedDate). � ����������� ������ ���� ���������� ������, ���� ������� ��������� ����������
--�������� ��� ��� �������������� ������. �������� �� ��������� ��� ������������� ����� 35 ����. ��������
--��������� ShippedOrdersDiff. ��������� ������ ����������� ��������� �������: OrderID, OrderDate, ShippedDate,
--ShippedDelay (�������� � ���� ����� ShippedDate � OrderDate), SpecifiedDelay (���������� � ��������� ��������).
--���������� ������������������ ������������� ���� ���������.
EXEC dbo.ShippedOrdersDiff 20

--13.3
--�������� ���������, ������� ����������� ���� ����������� ��������� ��������, ��� ����������������, ��� � ����������� ���
--�����������. � �������� �������� ��������� ������� ������������ EmployeeID. ���������� ����������� �����
--����������� � ��������� �� � ������ (������������ �������� PRINT) �������� �������� ����������. ��������, ��� ��������
--���� ����� ����������� ����� ������ ���� ��������. �������� ��������� SubordinationInfo. � �������� ��������� ��� �������
--���� ������ ���� ������������ ������, ����������� � Books Online � ��������������� Microsoft ��� ������� ��������� ����
--�����. ������������������ ������������� ���������.
EXEC dbo.SubordinationInfo 2

--13.4
--�������� �������, ������� ����������, ���� �� � �������� �����������. ���������� ��� ������ BIT. � �������� ��������
--��������� ������� ������������ EmployeeID. �������� ������� IsBoss. ������������������ ������������� ������� ��� ����
--��������� �� ������� Employees.
SELECT CONCAT(LastName, ' ', FirstName), dbo.IsBoss(EmployeeID) 'Boss'
FROM Employees