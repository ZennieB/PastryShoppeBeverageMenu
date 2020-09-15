CREATE TABLE [dbo].[Beverages]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DrinkId] INT NOT NULL, 
    [Name] NCHAR(50) NOT NULL, 
    [Cost] SMALLMONEY NOT NULL, 
    [Size] NCHAR(10) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [SpecialDrink] BIT NULL
)
