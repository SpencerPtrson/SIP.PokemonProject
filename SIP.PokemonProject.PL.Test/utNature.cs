using Microsoft.EntityFrameworkCore.Storage;

namespace SIP.PokemonProject.PL.Test
{
    public class utNature
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
            Assert.That(dc.tblNatures.Count(), Is.EqualTo(25));
        }

        [Test]
        public void InsertTest() {
            tblNature newNature = new tblNature();
            newNature.Id = Guid.NewGuid();
            newNature.Name = "Test";
            newNature.StatIncreased = "Attack";
            newNature.StatDecreased = "Defense";
            dc.tblNatures.Add(newNature);
            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest() {
            InsertTest();
            tblNature existingRow = dc.tblNatures.FirstOrDefault(t => t.Name == "Test");
            if (existingRow != null) {
                existingRow.Name = "UpdateTest";
                dc.SaveChanges();
            }
            tblNature row = dc.tblNatures.FirstOrDefault(t => t.Name == "UpdateTest");
            Assert.That(row.Name, Is.EqualTo(existingRow.Name));
        }

        [Test]
        public void DeleteTest() {
            InsertTest();
            tblNature row = dc.tblNatures.FirstOrDefault(t => t.Name == "Test");
            if (row != null) {
                dc.tblNatures.Remove(row);
                dc.SaveChanges();
            }
            tblNature deletedRow = dc.tblNatures.FirstOrDefault(t => t.Name == "Test");
            Assert.That(deletedRow, Is.Null);
        }
    }
}