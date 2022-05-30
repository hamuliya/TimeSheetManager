CREATE TABLE [dbo].[TimeSheet_MaterialDetail]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [TimeSheetId] INT NOT NULL, 
    [MaterialIn] NVARCHAR(100) NULL, 
    [MaterialOut] NVARCHAR(100) NULL, 
    CONSTRAINT [FK_TimeSheet_MaterialDetail_ToTimeSheet] FOREIGN KEY ([TimeSheetId]) REFERENCES [TimeSheet]([Id])
)
