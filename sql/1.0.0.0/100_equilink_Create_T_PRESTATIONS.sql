-----------------------------------------------------
-- Projet	    : FairyNails
-- Application  : SQL
-- Module       : 
-- Sous-module  : 
-- Description  : Creation de la table T_PRESTATION Fairynail
-- Créé par     : m.naxara@hotmail.com
-- Créé le      : 2019-21-11
-- Modifié par  : 
-- Modifié le   : 
-- Validé par   :
-- Validé le    :
-- Refusé par	: 
-- Refusé le    : 
-----------------------------------------------------

USE Fairynails;
GO

-- Create the T_PRESTATION table.
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'T_PRESTATION')
	BEGIN
		CREATE TABLE [dbo].[T_PRESTATION](
			[Id_prestation] [INT] IDENTITY(1,1) NOT NULL,
			[Nom] [NVARCHAR](50) NOT NULL,
			[Description] [NVARCHAR] (100) NOT NULL,
			[Prix] [MONEY] NOT NULL,
			[Duree] [TIME] NOT NULL,
			CONSTRAINT [PK_T_PRESTATION] PRIMARY KEY CLUSTERED ([Id_prestation] ASC),
		)
	END
GO
