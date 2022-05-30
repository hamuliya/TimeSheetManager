CREATE PROCEDURE [dbo].[spAllPlants]
AS
begin
    set nocount on;
	SELECT Id, PlantName from dbo.Plant order by PlantName;
end

