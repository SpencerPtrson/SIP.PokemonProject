CREATE TABLE [dbo].[tblPokedex]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [PokedexNum] INT NOT NULL, 
    [SpeciesName] VARCHAR(50) NOT NULL, 
    [Type1Id] UNIQUEIDENTIFIER NOT NULL, 
    [Type2Id] UNIQUEIDENTIFIER NOT NULL, 
    [BaseHP] INT NOT NULL,
    [BaseAttack] INT NOT NULL,
    [BaseDefense] INT NOT NULL,
    [BaseSpecialAttack] INT NOT NULL,
    [BaseSpecialDefense] INT NOT NULL, 
    [BaseSpeed] INT NOT NULL, 
    [SpriteName] VARCHAR(50) NOT NULL, 
    [FlavorText] VARCHAR(400) NOT NULL,
)
