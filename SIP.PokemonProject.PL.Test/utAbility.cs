using Microsoft.EntityFrameworkCore.Storage;

namespace SIP.PokemonProject.PL.Test
{
    public class utAbility
    {
        protected PokemonEntities dc;
        protected IDbContextTransaction transaction;

        [SetUp]
        public void Setup() {
            dc = new PokemonEntities();
            transaction = dc.Database.BeginTransaction();
        }

        [TearDown]
        public void TearDown() {
            transaction.Rollback();
            transaction = null;
        }

        [Test]
        public void LoadTest() {
            Assert.That(dc.tblAbilities.Count(), Is.EqualTo(3));
        }

        [Test]
        public void InsertTest() {
            tblAbility newAbility = new tblAbility();
            newAbility.Id = Guid.NewGuid();
            newAbility.Name = "Test";
            newAbility.Description = "Description Test";
            dc.tblAbilities.Add(newAbility);
            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest() {
            InsertTest();
            tblAbility existingRow = dc.tblAbilities.FirstOrDefault(t => t.Name == "Test");
            if (existingRow != null) {
                existingRow.Name = "UpdateTest";
                dc.SaveChanges();
            }
            tblAbility row = dc.tblAbilities.FirstOrDefault(t => t.Name == "UpdateTest");
            Assert.That(row.Name, Is.EqualTo(existingRow.Name));
        }

        [Test]
        public void DeleteTest() {
            InsertTest();
            tblAbility row = dc.tblAbilities.FirstOrDefault(t => t.Name == "Test");
            if (row != null) {
                dc.tblAbilities.Remove(row);
                dc.SaveChanges();
            }
            tblAbility deletedRow = dc.tblAbilities.FirstOrDefault(t => t.Name == "Test");
            Assert.That(deletedRow, Is.Null);
        }
    }
}