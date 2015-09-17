CREATE PROCEDURE [dbo].[item_get]
	@rowid int
AS
	set nocount on

	select
		ia.*
	from
		[dbo].[items_all] ia
	where
		ia.rowid = @rowid
