
using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;

namespace SIP.PokemonProject.BL.Test
{
    public class utPokedex
    {
        [Test]
        public async Task LoadTest()
        {
            var task = await new PokedexManager().Load();
            IEnumerable<PokedexData> pokedexList = task;
            Assert.AreEqual(4, pokedexList.ToList().Count);
        }

        [Test]
        public async Task LoadByIdTest()
        {
            var task = await new PokedexManager().Load();
            IEnumerable<PokedexData> pokedexList = task;

            PokedexData speciesData = await new PokedexManager().LoadById(pokedexList.FirstOrDefault().SpeciesId);
            Assert.AreEqual(pokedexList.FirstOrDefault().SpeciesId, speciesData.SpeciesId);
        }

        [Test]
        public async Task LoadBySpeciesNameTest()
        {
            PokedexData speciesData = await new PokedexManager().LoadBySpeciesName("Bulbasaur");
            Assert.AreEqual(speciesData.SpeciesName, "Bulbasaur");
        }

        [Test]
        public async Task InsertTest()
        {
            Models.Type type1 = await new TypeManager().LoadByTypeName("Fire");
            Models.Type type2 = await new TypeManager().LoadByTypeName("Water");

            int results = await new PokedexManager().Insert(new PokedexData
            {
                SpeciesId = Guid.NewGuid(),
                PokedexNum = -1,
                SpeciesName = "Test Species",
                Type1Id = type1.Id,
                Type2Id = type2.Id,
                BaseHP = 110,
                BaseAttack = 1,
                BaseDefense = 1,
                BaseSpecialAttack = 1,
                BaseSpecialDefense = 1,
                BaseSpeed = 1,
                SpritePath = "Test Sprite",
                FlavorText = "Test"
            }, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task UpdateTest()
        {
            var task = await new PokedexManager().Load();
            IEnumerable<PokedexData> pokedexList = task;
            PokedexData pokemonSpecies = pokedexList.FirstOrDefault(pd => pd.SpeciesName == "Bulbasaur");
            pokemonSpecies.SpeciesName = "Test Name";
            int results = await new PokedexManager().Update(pokemonSpecies, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task DeleteTest()
        {
            Models.Type type1 = await new TypeManager().LoadByTypeName("Fire");
            Models.Type type2 = await new TypeManager().LoadByTypeName("Water");

            await new PokedexManager().Insert(new PokedexData
            {
                SpeciesId = Guid.NewGuid(),
                PokedexNum = -1,
                SpeciesName = "Test Species",
                Type1Id = type1.Id,
                Type2Id = type2.Id,
                BaseHP = 110,
                BaseAttack = 1,
                BaseDefense = 1,
                BaseSpecialAttack = 1,
                BaseSpecialDefense = 1,
                BaseSpeed = 1,
                SpritePath = "Test Sprite",
                FlavorText = "Test"
            }, false);

            var task = await new PokedexManager().Load();
            IEnumerable<PokedexData> pokedexList = task;

            PokedexData speciesData = pokedexList.FirstOrDefault(pd => pd.SpeciesName == "Test Species");
            int results = await new PokedexManager().Delete(speciesData.SpeciesId, false);
            Assert.IsTrue(results > 0);
        }
    }
}