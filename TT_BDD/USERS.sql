﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Login] VARCHAR(50) NULL, 
	[Mdp] VARCHAR(50) NULL, 
	[DroitUtilisateur] VARCHAR(50) NULL
)
