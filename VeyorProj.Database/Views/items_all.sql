CREATE VIEW [dbo].[items_all]
AS 

	SELECT 
		i.rowid,
		i.name,
		i.description,
		i.rating,
		i.price
	FROM 
		[dbo].[items] i

