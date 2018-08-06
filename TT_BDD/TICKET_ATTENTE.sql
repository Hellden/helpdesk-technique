CREATE TABLE [dbo].[Ticket_Attente]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Nom] NCHAR(20) NULL, 
	[Prenom] NCHAR(20) NULL, 
	[Sujet] TEXT NULL, 
	[Message] TEXT NULL, 
	[DateDebut] DATETIME NULL, 
	[Suivie] TEXT NULL, 
	[Validation] INT NULL, 
	[Commentaire] TEXT NULL, 
	[DateFinTicket] DATETIME NULL
)
