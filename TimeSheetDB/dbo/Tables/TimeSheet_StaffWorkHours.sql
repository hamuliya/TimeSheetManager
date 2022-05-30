CREATE TABLE [dbo].[TimeSheet_StaffWorkHours]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
	[TimeSheetId] INT NOT NULL,
	[StaffId] int NOT NULL, 
    [TotalHours] FLOAT NULL, 
    [LabourHours] FLOAT NULL, 
    CONSTRAINT [FK_TimeSheet_StaffWorkHours_ToTimeSheet] FOREIGN KEY ([TimeSheetId]) REFERENCES [TimeSheet]([Id])
)
