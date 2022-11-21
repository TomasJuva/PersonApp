CREATE PROCEDURE [dbo].[spInsertPerson]
  @FirstName nvarchar(50),
  @LastName nvarchar(50),
  @PersonNumber nvarchar(20),
  @NoPersonNumber bit,
  @BirthDay DateTime2(7),
  @Sex int,
  @Email nvarchar(50),
  @Nationality int,
  @Gdpr bit
as
begin
	set nocount on;

	insert into dbo.[Person](FirstName, LastName, PersonNumber, NoPersonNumber, BirthDay, Sex, Email, Nationality, Gdpr)
	values (@FirstName, @LastName, @PersonNumber, @NoPersonNumber, @BirthDay, @Sex, @Email, @Nationality, @Gdpr);
end