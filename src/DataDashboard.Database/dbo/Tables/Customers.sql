﻿CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NULL, 
    [State] NVARCHAR(50) NULL
)
