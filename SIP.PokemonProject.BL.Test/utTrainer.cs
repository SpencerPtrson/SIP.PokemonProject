
using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;

namespace SIP.PokemonProject.BL.Test
{
    public class utTrainer
    {
        [Test]
        public async Task LoadTest() {
            var task = await new TrainerManager().Load();
            IEnumerable<Trainer> TrainerList = task;
            Assert.AreEqual(3, TrainerList.ToList().Count);
        }

        [Test]
        public async Task LoadByIdTest() {
            var task = await new TrainerManager().Load();
            IEnumerable<Trainer> TrainerList = task;

            Trainer trainerData = await new TrainerManager().LoadById(TrainerList.FirstOrDefault().Id);
            Assert.AreEqual(TrainerList.FirstOrDefault().Id, trainerData.Id);
        }

        [Test]
        public async Task LoadBySpeciesNameTest()
        {
            Trainer trainerData = await new TrainerManager().LoadByTrainerName("Red");
            Assert.AreEqual(trainerData.Name, "Red");
        }

        [Test]
        public async Task InsertTest()
        {
            int results = await new TrainerManager().Insert(new Trainer {
                Name = "Test",
                Money = 0,
            }, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task UpdateTest() {
            var task = await new TrainerManager().Load();
            IEnumerable<Trainer> TrainerList = task;
            Trainer pokemonSpecies = TrainerList.FirstOrDefault(pd => pd.Name == "Red");
            pokemonSpecies.Name = "Test Name";
            int results = await new TrainerManager().Update(pokemonSpecies, true);
            Assert.IsTrue(results > 0);
        }

        //[Test]
        //public async Task DeleteTest() {
        //    Models.Type type1 = await new TypeManager().LoadByTypeName("Fire");
        //    Models.Type type2 = await new TypeManager().LoadByTypeName("Water");

        //    await new TrainerManager().Insert(new Trainer {
        //        SpeciesId = Guid.NewGuid(),
        //        TrainerNum = -1,
        //        SpeciesName = "Test Species",
        //        Type1Id = type1.Id,
        //        Type2Id = type2.Id,
        //        BaseHP = 110,
        //        BaseAttack = 1,
        //        BaseDefense = 1,
        //        BaseSpecialAttack = 1,
        //        BaseSpecialDefense = 1,
        //        BaseSpeed = 1,
        //        SpritePath = "Test Sprite",
        //        FlavorText = "Test"
        //    }, false);

        //    var task = await new TrainerManager().Load();
        //    IEnumerable<Trainer> TrainerList = task;

        //    Trainer trainerData = TrainerList.FirstOrDefault(pd => pd.SpeciesName == "Test Species");
        //    int results = await new TrainerManager().Delete(trainerData.SpeciesId, false);
        //    Assert.IsTrue(results > 0);
        //}
    }
}