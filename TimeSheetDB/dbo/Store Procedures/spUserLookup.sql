CREATE PROCEDURE [dbo].[spUserLookup]
	@Id NVarchar(128)
AS
begin
   set nocount on;
   SELECT FirstName,LastName,EmailAddress,Cellphone,CreateDate from dbo.[User] where Id=@Id;
end;
