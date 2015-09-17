CREATE TABLE [dbo].[items]
(
	[rowid] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[name] nvarchar(100) not null,
	[description] nvarchar(1000) null,
	[rating] int not null default(0),
	[price] money not null default(0)
)
