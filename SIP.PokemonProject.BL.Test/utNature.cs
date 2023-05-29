
using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;

namespace SIP.PokemonProject.BL.Test
{
    public class utNature
    {
        [Test]
        public async Task LoadTest()
        {
            var task = await new NatureManager().Load();
            IEnumerable<Nature> Natures = task;
            Assert.AreEqual(25, Natures.ToList().Count);
        }

        [Test]
        public async Task LoadByNatureNameTest()
        {
            Nature nature = await new NatureManager().LoadByNatureName("Adamant");
            Assert.AreEqual("Adamant", nature.Name);
        }

        [Test]
        public async Task InsertTest()
        {
            int results = await new NatureManager().Insert(new Nature
            {
                Name = "Test",
                StatIncreased = "Test",
                StatDecreased = "Test",
            }, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task UpdateTest()
        {
            IEnumerable<Nature> natures = await new NatureManager().Load();
            Nature nature = natures.FirstOrDefault();
            nature.Name = "Updated Nature";
            nature.StatIncreased = "Test";
            nature.StatDecreased = "Test";

            int results = await new NatureManager().Update(nature, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task DeleteTest()
        {
            IEnumerable<Nature> natures = await new NatureManager().Load();
            Nature nature = natures.FirstOrDefault();
            int results = await new NatureManager().Delete(nature.Id, true);
            Assert.IsTrue(results > 0);
        }
    }
}