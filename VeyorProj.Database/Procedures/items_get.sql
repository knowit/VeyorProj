CREATE PROCEDURE [dbo].[items_get]
AS
	set nocount on

	select
		ia.*
	from
		[dbo].[items_all] ia
	order by
		ia.name