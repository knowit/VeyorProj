CREATE PROCEDURE [dbo].[item_update]
	@rowid int,
	@name nvarchar(100),
	@description nvarchar(1000),
	@rating int,
	@price money
AS
	set nocount on

	update
		[dbo].[items]
	set
		name = @name,
		description = @description,
		rating = @rating
	where
		rowid = @rowid

