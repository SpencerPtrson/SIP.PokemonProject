/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

DROP TABLE IF EXISTS dbo.tblSpeciesAbility
DROP TABLE IF EXISTS dbo.tblPokemonTeam
DROP TABLE IF EXISTS dbo.tblPokemon
DROP TABLE IF EXISTS dbo.tblPokedex
DROP TABLE IF EXISTS dbo.tblAbility
DROP TABLE IF EXISTS dbo.tblTrainer
DROP TABLE IF EXISTS dbo.tblNature
DROP TABLE IF EXISTS dbo.tblMove
DROP TABLE IF EXISTS dbo.tblAddedAffects
DROP TABLE IF EXISTS dbo.tblType
DROP TABLE IF EXISTS dbo.tblItem
