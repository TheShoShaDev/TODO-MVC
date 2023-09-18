CREATE TABLE [dbo].TodoListItems 
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[AddDate] DateTiME NOT NULL,
	[Title]	NVARCHAR(200) NOT NULL,
	[IsDone] bit NOT NULL	default 0
)
