
using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;

namespace SIP.PokemonProject.BL.Test
{
    public class utAbility
    {
        [Test]
        public async Task LoadTest()
        {
            var task = await new AbilityManager().Load();
            IEnumerable<Ability> abilities = task;
            Assert.AreEqual(3, abilities.ToList().Count);
        }

        [Test]
        public async Task LoadByIdTest()
        {
            List<Ability> abilities = await new AbilityManager().Load();
            Ability loadedAbility = await new AbilityManager().LoadById(abilities[0].Id);
            Assert.AreEqual(abilities[0].Name, loadedAbility.Name);
        }

        [Test]
        public async Task LoadByAbilityNameTest()
        {
            Ability ability = await new AbilityManager().LoadByAbilityName("Overgrow");
            Assert.AreEqual("Overgrow", ability.Name);
        }

        [Test]
        public async Task InsertTest()
        {
            int results = await new AbilityManager().Insert(new Ability
            {
                Name = "Test",
                Description = "Test",
            }, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task UpdateTest()
        {
            IEnumerable<Ability> abilities = await new AbilityManager().Load();
            Ability ability = abilities.FirstOrDefault();
            ability.Name = "Updated Ability";
            ability.Description = "Test";

            int results = await new AbilityManager().Update(ability, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task DeleteTest()
        {
            IEnumerable<Ability> abilities = await new AbilityManager().Load();
            Ability ability = abilities.FirstOrDefault();
            int results = await new AbilityManager().Delete(ability.Id, true);
            Assert.IsTrue(results > 0);
        }
    }
}