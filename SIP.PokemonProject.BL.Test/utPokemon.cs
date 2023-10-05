
using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;

namespace SIP.PokemonProject.BL.Test
{
    public class utPokemon
    {
        [Test]
        public async Task LoadTest()
        {
            var task = await new PokemonManager().Load();
            IEnumerable<Pokemon> pokemon = task;
            Assert.AreEqual(3, pokemon.ToList().Count);
        }

        //[Test]
        //public async Task LoadByTrainerId()
        //{
        //    Pokemon Pokemon = await new PokemonManager().LoadByPokemonName("Overgrow");
        //    Assert.AreEqual("Overgrow", Pokemon.Name);
        //}

        [Test]
        public async Task LoadByIdTest()
        {
            List<Pokemon> pokemonList = await new PokemonManager().Load();
            Pokemon loadedPokemon = await new PokemonManager().LoadById(pokemonList[0].Id);
            Assert.AreEqual(pokemonList[0].SpeciesId, loadedPokemon.SpeciesId);
        }


        [Test]
        public async Task InsertTest()
        {
            List<PokedexData> pokedex = await new PokedexManager().Load();
            List<Models.Type> types = await new TypeManager().Load();
            List<Models.Nature> natures = await new NatureManager().Load();
            // List<Models.Ability> abilities = await new AbilityManager().Load();
            // Need to load from SpeciesAbilities, not all abilities

            int results = await new PokemonManager().Insert(new Pokemon
            {
                SpeciesId = pokedex[0].SpeciesId,
                NatureId = natures[0].Id,
                AbilityId = abilities[0].Id,
                Type1 = types[0].Id,
                Type2 = types[1].Id,
                Level = 1,
                IsShiny = false,
                Nickname = "Test Nickname",
                MajorStatusId = null,
                HPEV = 0,
                HPIV = 0,
                AttackEV = 0,
                AttackIV = 0,
                DefenseEV = 0,
                DefenseIV = 0,
                SpecialAttackEV = 0,
                SpecialAttackIV = 0,
                SpecialDefenseEV = 0,
                SpecialDefenseIV = 0,
                SpeedEV = 0,
                SpeedIV = 0
            }, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task UpdateTest()
        {
            IEnumerable<Pokemon> pokemonList = await new PokemonManager().Load();
            Pokemon Pokemon = pokemonList.FirstOrDefault();
            Pokemon.Nickname = "Updated Nickname";

            int results = await new PokemonManager().Update(Pokemon, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task DeleteTest()
        {
            IEnumerable<Pokemon> pokemonList = await new PokemonManager().Load();
            Pokemon Pokemon = pokemonList.FirstOrDefault();
            int results = await new PokemonManager().Delete(Pokemon.Id, true);
            Assert.IsTrue(results > 0);
        }

    }
}