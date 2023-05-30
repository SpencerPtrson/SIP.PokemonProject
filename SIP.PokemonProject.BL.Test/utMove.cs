
using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;

namespace SIP.PokemonProject.BL.Test
{
    public class utMove
    {
        [Test]
        public async Task LoadTest()
        {
            var task = await new MoveManager().Load();
            IEnumerable<Move> moves = task;
            Assert.AreEqual(2, moves.ToList().Count);
        }

        [Test]
        public async Task LoadByIdTest()
        {
            List<Move> moves = await new MoveManager().Load();
            Move loadedMove = await new MoveManager().LoadById(moves[0].Id);
            Assert.AreEqual(moves[0].Name, loadedMove.Name);
        }

        [Test]
        public async Task LoadByMoveNameTest()
        {
            Move Move = await new MoveManager().LoadByMoveName("Tackle");
            Assert.AreEqual("Tackle", Move.Name);
        }

        [Test]
        public async Task InsertTest()
        {
            List<Models.Type> types = await new TypeManager().Load();
            int results = await new MoveManager().Insert(new Move
            {
                Name = "Test",
                Description = "Test",
                TypeId = types[0].Id,
                Category = "Test",
                normalPP = 10,
                BasePower = 100,
                Accuracy = 100,
                Priority = 0,
                Target = "Single",
                CritRate = 12,
            }, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task UpdateTest()
        {
            IEnumerable<Move> moves = await new MoveManager().Load();
            Move Move = moves.FirstOrDefault();
            Move.Name = "Updated Move";
            Move.Description = "Test";

            int results = await new MoveManager().Update(Move, true);
            Assert.IsTrue(results > 0);
        }

        [Test]
        public async Task DeleteTest()
        {
            IEnumerable<Move> moves = await new MoveManager().Load();
            Move Move = moves.FirstOrDefault();
            int results = await new MoveManager().Delete(Move.Id, true);
            Assert.IsTrue(results > 0);
        }
    }
}