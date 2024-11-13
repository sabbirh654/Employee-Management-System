CREATE DATABASE EMS;

--Designation Table
CREATE TABLE Designation(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE(),
	UpdatedAt DATETIME DEFAULT GETDATE()
);

-- Department Table
CREATE TABLE Department(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE(),
	UpdatedAt DATETIME DEFAULT GETDATE()

);

--Employee Table
CREATE TABLE Employee(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
	Email NVARCHAR(100) NOT NULL,
	Phone NVARCHAR(15),
	Address NVARCHAR(255),
	DOB DATE,
	DesignationId INT NOT NULL,
	DepartmentId INT NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE(),
	UpdatedAt DATETIME DEFAULT GETDATE(),
	CONSTRAINT FK_Employee_Designation FOREIGN KEY(DesignationId) REFERENCES Designation(Id),
	CONSTRAINT FK_Employee_Department FOREIGN KEY(DepartmentId) REFERENCES Department(Id),
);

CREATE PROCEDURE AddNewDepartment
	@Name NVARCHAR(100)

AS
BEGIN
    INSERT INTO Department(Name)
	VALUES(@Name);
END;

CREATE PROCEDURE GetAllDepartments
AS
BEGIN
	SELECT Id, Name FROM Department;
END;

CREATE PROCEDURE GetDepartmentById
	@Id INT
AS
BEGIN
	SELECT Id, Name FROM Department
	WHERE Id = @Id;
END;

CREATE PROCEDURE UpdateDepartment
	@Id INT,
	@Name NVARCHAR(100)
AS
BEGIN
	UPDATE Department
	SET Name = @Name
	WHERE Id = @Id;
END;

CREATE PROCEDURE DeleteDepartment
	@Id INT
AS
BEGIN
	UPDATE Department
	SET IsDeleted = 1
	WHERE Id = @Id;
END;

--Designation--

CREATE PROCEDURE AddNewDesignation
	@Name NVARCHAR(100)
AS
BEGIN
    INSERT INTO Designation(Name)
	VALUES(@Name);
END;

CREATE PROCEDURE GetAllDesignations
AS
BEGIN
	SELECT Id, Name FROM Designation
	WHERE IsDeleted = 0;
END;

CREATE PROCEDURE GetDesignationById
	@Id INT
AS
BEGIN
	SELECT Id, Name FROM Designation
	WHERE Id = @Id;
END;

CREATE PROCEDURE UpdateDesignation
	@Id INT,
	@Name NVARCHAR(100)
AS
BEGIN
	UPDATE Designation
	SET Name = @Name
	WHERE Id = @Id;
END;

CREATE PROCEDURE DeleteDesignation
	@Id INT
AS
BEGIN
	UPDATE Designation
	SET IsDeleted = 1
	WHERE Id = @Id;
END;

-- Employee --
CREATE PROCEDURE AddNewEmployee
	@Name NVARCHAR(100),
	@Email NVARCHAR(100),
	@Phone NVARCHAR(15),
	@Address NVARCHAR(255),
	@DOB DATE,
	@DesignationId INT,
	@DepartmentId INT
AS
BEGIN
	INSERT INTO Employee(Name, Email, Phone, Address, DOB, DepartmentId, DesignationId)
	VALUES(@Name, @Email, @Phone, @Address, @DOB, @DepartmentId, @DesignationId);
END;

CREATE PROCEDURE GetAllEmployees
AS
BEGIN
	SELECT e.Id, e.Name, e.Email, e.Phone, e.Address, e.DOB,
		   d.Id AS DepartmentId, dg.Id AS DesignationId,
		   d.Name AS Department, dg.Name AS Designation
	FROM Employee e
	JOIN Department d
	ON d.Id = e.DepartmentId
	JOIN Designation dg
	ON dg.Id = e.DesignationId
	WHERE e.IsDeleted = 0;
END;

CREATE PROCEDURE DeleteEmployee
	@Id INT
AS
BEGIN
	UPDATE Employee
	SET IsDeleted = 1
	WHERE Id = @Id;
END;

CREATE PROCEDURE UpdateEmployee
	@Id INT,
	@Name NVARCHAR(100),
	@Email NVARCHAR(100),
	@Phone NVARCHAR(15),
	@DOB DATE
AS
BEGIN
	UPDATE Employee
	SET Name = @Name,
		Email = @Email,
		Phone = @Phone,
		DOB = @DOB
	WHERE Id = @Id;
END;