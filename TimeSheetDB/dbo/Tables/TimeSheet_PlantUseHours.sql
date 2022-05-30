CREATE TABLE [dbo].[TimeSheet_PlantUseHours]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [TimeSheetId] INT NOT NULL,
    [PlantId] int not null,
    [Description] NVARCHAR(50) NULL, 
    [UseHours] FLOAT NULL, 
    CONSTRAINT [FK_TimeSheet_PlantUseHours_ToTimeSheet] FOREIGN KEY ([TimeSheetId]) REFERENCES [TimeSheet]([Id])
)
