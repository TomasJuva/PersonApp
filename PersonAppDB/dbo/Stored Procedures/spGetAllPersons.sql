CREATE PROCEDURE [dbo].[spGetAllPersons]
AS
begin
  set nocount on;

	select *
  from [dbo].[Person];
end