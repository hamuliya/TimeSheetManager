CREATE TABLE [dbo].[TimeSheet]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [ClientName] NVARCHAR(50) NULL, 
    [BeginDate] DATETIME2 NULL, 
    [CompleteDate] DATETIME2 NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    --1,Created
    --2,Completed
    [Status] INT NULL, 
    [CreateDate] DATETIME2 NULL DEFAULT getutcdate(), 
    [JobNo] NCHAR(50) NULL
)
