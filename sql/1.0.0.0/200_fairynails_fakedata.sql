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

USE [Fairynails]
GO

INSERT INTO [dbo].[T_PRESTATION]
           ([Nom]
           ,[Description]
           ,[Prix]
           ,[Duree])
     VALUES
           ('Manucure'
           ,'Manucure des mains \o/'
           ,20.00
           ,'01:00:00')
GO

INSERT INTO [dbo].[T_PRESTATION]
           ([Nom]
           ,[Description]
           ,[Prix]
           ,[Duree])
     VALUES
           ('Pedicure'
           ,'Pedicure des pieds \o/'
           ,30.00
           ,'01:00:00')
GO
