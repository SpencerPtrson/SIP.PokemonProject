
using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;

namespace SIP.PokemonProject.BL.Test
{
    public class utType
    {
        [Test]
        public async Task LoadTest()
        {
            var task = await new TypeManager().Load();
            IEnumerable<Models.Type> types = task;
            Assert.AreEqual(19, types.ToList().Count);
        }

        [Test]
        public async Task LoadByTypeNameTest()
        {
            Models.Type type = await new TypeManager().LoadByTypeName("Fire");
            Assert.AreEqual("Fire", type.TypeName);
        }

        [Test]
        public async Task InsertTest()
        {
            int results = await new TypeManager().Insert(new Models.Type
            {
                TypeName = "Test",
                // I don't know how to insert an image into the database at present
            }, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task UpdateTest()
        {
            IEnumerable<Models.Type> types = await new TypeManager().Load();
            Models.Type type = types.FirstOrDefault();
            type.TypeName = "Updated Type";
            int results = await new TypeManager().Update(type, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task DeleteTest()
        {
            Models.Type testType = new Models.Type
            {
                TypeName = "Test"
            };

            await new TypeManager().Insert(testType, false);

            IEnumerable<Models.Type> types = await new TypeManager().Load();
            int results = await new TypeManager().Delete(testType.Id, false);
            Assert.IsTrue(results > 0);
        }
    }
}