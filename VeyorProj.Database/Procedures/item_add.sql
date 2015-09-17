CREATE PROCEDURE [dbo].[item_add]
	@name nvarchar(100),
	@description nvarchar(1000),
	@rating int,
	@price money
AS
	set nocount on

	insert into
		[dbo].[items]
		(
			name,
			description,
			rating,
			price
		)
		values
		(
			@name,
			@description,
			@rating,
			@price
		)
