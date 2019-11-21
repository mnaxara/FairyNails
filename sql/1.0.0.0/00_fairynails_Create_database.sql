-----------------------------------------------------
-- Projet	    : FairyNails
-- Application  : SQL
-- Module       : 
-- Sous-module  : 
-- Description  : Creation de la base de donnée Fairynails
-- Créé par     : m.naxara@hotmail.com
-- Créé le      : 2019-05-20
-- Modifié par  : 
-- Modifié le   : 
-- Validé par   :
-- Validé le    :
-- Refusé par	: 
-- Refusé le    : 
-----------------------------------------------------

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

USE [master];
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'Fairynails')
	DROP DATABASE Fairynails;
GO

-- Create the School database.
CREATE DATABASE Fairynails;
GO

-- Specify a simple recovery model 
-- to keep the log growth to a minimum.
ALTER DATABASE Fairynails SET RECOVERY SIMPLE;
GO

USE Fairynails;
GO