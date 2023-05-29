/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r .\DefaultData\Abilities.sql
:r .\DefaultData\Items.sql
:r .\DefaultData\Types.sql
:r .\DefaultData\Pokedex.sql
:r .\DefaultData\Moves.sql
:r .\DefaultData\SpeciesAbilities.sql
:r .\DefaultData\Natures.sql
:r .\DefaultData\Pokemon.sql
:r .\DefaultData\Trainers.sql
:r .\DefaultData\PokemonTeams.sql