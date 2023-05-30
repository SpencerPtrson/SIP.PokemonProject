
using NUnit.Framework.Interfaces;
using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;

namespace SIP.PokemonProject.BL.Test
{
    public class utItem
    {
        [Test]
        public async Task LoadTest()
        {
            var task = await new ItemManager().Load();
            IEnumerable<Item> items = task;
            Assert.AreEqual(3, items.ToList().Count);
        }

        [Test]
        public async Task LoadByIdTest()
        {
            List<Item> items = await new ItemManager().Load();
            Item loadedItem = await new ItemManager().LoadById(items[0].Id);
            Assert.AreEqual(items[0].Name, loadedItem.Name);
        }

        [Test]
        public async Task LoadByItemNameTest()
        {
            Item item = await new ItemManager().LoadByItemName("Leftovers");
            Assert.AreEqual("Leftovers", item.Name);
        }

        [Test]
        public async Task InsertTest()
        {
            int results = await new ItemManager().Insert(new Item
            {
                Name = "Test",
                Description = "Test",
            }, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task UpdateTest()
        {
            IEnumerable<Item> items = await new ItemManager().Load();
            Item item = items.FirstOrDefault();
            item.Name = "Updated Item";
            item.Description = "Test";

            int results = await new ItemManager().Update(item, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task DeleteTest()
        {
            IEnumerable<Item> items = await new ItemManager().Load();
            Item item = items.FirstOrDefault();
            int results = await new ItemManager().Delete(item.Id, true);
            Assert.IsTrue(results > 0);
        }
    }
}