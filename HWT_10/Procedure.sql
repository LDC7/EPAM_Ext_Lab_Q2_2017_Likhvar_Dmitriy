USE NORTHWND

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
GO
IF OBJECT_ID('GreatestOrders') IS NOT NULL
DROP PROCEDURE GreatestOrders
GO
CREATE PROCEDURE GreatestOrders
	@Year int,
	@Num int
AS
	SELECT TOP(@Num) nt.Seller, o2.OrderID, nt.Price
	FROM (
		SELECT e.EmployeeID,
			CONCAT(e.FirstName, ' ', e.LastName) 'Seller',
			MAX(od.Quantity * (od.UnitPrice - (od.UnitPrice * od.Discount)))'Price'
		FROM Employees e
		JOIN Orders o ON o.EmployeeID = e.EmployeeID
		JOIN [Order Details] od ON od.OrderID = o.OrderID
		WHERE YEAR(o.OrderDate) = @Year
		GROUP BY e.EmployeeID, CONCAT(e.FirstName, ' ', e.LastName)
	) nt, Orders o2
	JOIN [Order Details] od2 ON od2.OrderID = o2.OrderID
	WHERE o2.EmployeeID = nt.EmployeeID AND (od2.Quantity * (od2.UnitPrice - (od2.UnitPrice * od2.Discount))) = nt.Price
	ORDER BY 'Price' DESC
GO

--13.2
--�������� ���������, ������� ���������� ������ � ������� Orders, �������� ���������� ����� �������� � ����
--(������� ����� OrderDate � ShippedDate). � ����������� ������ ���� ���������� ������, ���� ������� ��������� ����������
--�������� ��� ��� �������������� ������. �������� �� ��������� ��� ������������� ����� 35 ����. ��������
--��������� ShippedOrdersDiff. ��������� ������ ����������� ��������� �������: OrderID, OrderDate, ShippedDate,
--ShippedDelay (�������� � ���� ����� ShippedDate � OrderDate), SpecifiedDelay (���������� � ��������� ��������).
--���������� ������������������ ������������� ���� ���������.
GO
IF OBJECT_ID('ShippedOrdersDiff') IS NOT NULL
DROP PROCEDURE ShippedOrdersDiff
GO
CREATE PROCEDURE ShippedOrdersDiff
	@Days int = 35
AS
	SELECT OrderID, OrderDate, ShippedDate, DAY(ShippedDate - OrderDate) 'ShippedDelay', @Days 'SpecifiedDelay'
	FROM Orders
	WHERE DAY(ShippedDate - OrderDate) > @Days OR ShippedDate IS NULL
GO

--13.3
--�������� ���������, ������� ����������� ���� ����������� ��������� ��������, ��� ����������������, ��� � ����������� ���
--�����������. � �������� �������� ��������� ������� ������������ EmployeeID. ���������� ����������� �����
--����������� � ��������� �� � ������ (������������ �������� PRINT) �������� �������� ����������. ��������, ��� ��������
--���� ����� ����������� ����� ������ ���� ��������. �������� ��������� SubordinationInfo. � �������� ��������� ��� �������
--���� ������ ���� ������������ ������, ����������� � Books Online � ��������������� Microsoft ��� ������� ��������� ����
--�����. ������������������ ������������� ���������.
--//����� ��� ������?
GO
IF OBJECT_ID('SubordinationInfo') IS NOT NULL
DROP PROCEDURE SubordinationInfo
GO
CREATE PROCEDURE SubordinationInfo
	@EmpID int,
	@Tabs int = 0
AS
	DECLARE @Name varchar(50)
	SELECT @Name = CONCAT(LastName, ' ', FirstName)
	FROM Employees
	WHERE @EmpID = EmployeeID
	SET @Name = CONCAT(SPACE(@Tabs * 4), @Name)
	PRINT @Name;
	
	SET @Tabs = @Tabs + 1;
	DECLARE @I int = 0
	WHILE(1 = 1)
		BEGIN
		SELECT @I = MIN(EmployeeID)
		FROM Employees WHERE EmployeeID > @I
		IF @I IS NULL BREAK
		IF EXISTS (
			SELECT ReportsTo FROM Employees
			WHERE ReportsTo = @EmpID AND @I = EmployeeID
			)
		EXEC SubordinationInfo @I, @Tabs
		END
GO

--13.4
--�������� �������, ������� ����������, ���� �� � �������� �����������. ���������� ��� ������ BIT. � �������� ��������
--��������� ������� ������������ EmployeeID. �������� ������� IsBoss. ������������������ ������������� ������� ��� ����
--��������� �� ������� Employees.
GO
IF OBJECT_ID('IsBoss') IS NOT NULL
DROP FUNCTION IsBoss
GO
CREATE FUNCTION IsBoss (
	@EmpID int
	)
RETURNS bit
BEGIN
	DECLARE @Flag bit = 0
	IF EXISTS (
		SELECT EmployeeID
		FROM Employees
		WHERE ReportsTo = @EmpID
		)
	SET @Flag = 1;

	RETURN @Flag
END