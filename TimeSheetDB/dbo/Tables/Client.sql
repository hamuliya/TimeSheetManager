CREATE TABLE [dbo].[Client]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [ClientName] NVARCHAR(50) NOT NULL, 
    [Cellphone] NVARCHAR(50) NULL, 
    [Address] NVARCHAR(100) NULL
)
