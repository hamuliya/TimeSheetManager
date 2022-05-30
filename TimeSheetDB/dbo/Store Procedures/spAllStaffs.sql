CREATE PROCEDURE [dbo].[spAllStaffs]
	
AS
begin
    set nocount on;
	SELECT Id, FirstName,LastName,EmailAddress,Cellphone from dbo.[Staff] where IsActive=1 order by FirstName;
end;



