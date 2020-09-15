CREATE TABLE dbo.Roles
(
	[posId] INT NOT NULL PRIMARY KEY,
	[Id] Int FOREIGN KEY References [Employee](Id),
	[RoleId] INT Foreign key references [RoleID](Id),
	[RoleName] varchar NOT NULL


)
