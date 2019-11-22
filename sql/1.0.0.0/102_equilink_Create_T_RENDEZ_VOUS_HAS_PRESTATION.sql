-----------------------------------------------------
-- Projet	    : FairyNails
-- Application  : SQL
-- Module       : 
-- Sous-module  : 
-- Description  : Creation de la table T_RENDEZ_VOUS_HAS_PRESTATION Fairynail
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

-- Create the T_RENDEZ_VOUS_HAS_PRESTATION table.
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'T_RENDEZ_VOUS_HAS_PRESTATION')
	BEGIN
		CREATE TABLE [dbo].[T_RENDEZ_VOUS_HAS_PRESTATION](
			[Id_rdv] [INT] NOT NULL,
			[Id_prestation] [INT] NOT NULL,
			CONSTRAINT [PK_T_RENDEZ_VOUS_HAS_PRESTATION] PRIMARY KEY CLUSTERED (Id_rdv, Id_prestation),
		)
	END
GO

-- Define the relationship between T_RENDEZ_VOUS_HAS_PRESTATION and T_RENDEZ_VOUS.
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_RENDEZ_VOUS_HAS_PRESTATION]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_RENDEZ_VOUS]'))

ALTER TABLE [dbo].[T_RENDEZ_VOUS_HAS_PRESTATION] WITH CHECK ADD CONSTRAINT [FK_T_RENDEZ_VOUS_HAS_PRESTATION_T_RENDEZ_VOUS] FOREIGN KEY ([Id_rdv]) REFERENCES [dbo].[T_RENDEZ_VOUS] ([Id_rdv])
GO

-- Define the relationship between T_RENDEZ_VOUS_HAS_PRESTATION and T_PRESTATION.
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_RENDEZ_VOUS_HAS_PRESTATION_T_PRESTATION]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_PRESTATION]'))

ALTER TABLE [dbo].[T_RENDEZ_VOUS_HAS_PRESTATION] WITH CHECK ADD CONSTRAINT [[FK_T_RENDEZ_VOUS_HAS_PRESTATION] FOREIGN KEY ([Id_prestation]) REFERENCES [dbo].[T_PRESTATION] ([Id_prestation])
GO