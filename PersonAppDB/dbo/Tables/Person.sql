CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [PersonNumber] NVARCHAR(20) NULL, 
    [NoPersonNumber] BIT NOT NULL, 
    [BirthDay] DATETIME2(7) NOT NULL, 
    [Sex] INT NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Nationality] INT NOT NULL, 
    [Gdpr] BIT NOT NULL
)



