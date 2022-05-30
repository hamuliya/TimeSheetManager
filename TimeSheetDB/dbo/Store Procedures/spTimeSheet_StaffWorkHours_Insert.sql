CREATE PROCEDURE [dbo].[spTimeSheet_StaffWorkHours_Insert]
	@Id int,
	@TimeSheetId int,
	@StaffId int,
	@TotalHours Float,
	@LabourHours Float
AS
begin
	set nocount on;
	Insert into dbo.TimeSheet_StaffWorkHours(TimeSheetId,StaffId,TotalHours,LabourHours) 
	values (@TimeSheetId,@StaffId,@TotalHours,@LabourHours)	
end

