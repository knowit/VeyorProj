CREATE PROCEDURE [dbo].[item_delete]
	@rowid int
AS
	set nocount on

	delete from
		[dbo].[items]
	where
		rowid = @rowid
