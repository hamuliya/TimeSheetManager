
	CREATE TABLE [dbo].[User]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(256) NOT NULL, 
    [Cellphone] NVARCHAR(50) NULL,
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [IsActive] BIT NOT NULL DEFAULT 1
   
)

