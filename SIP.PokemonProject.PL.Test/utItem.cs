using Microsoft.EntityFrameworkCore.Storage;

namespace SIP.PokemonProject.PL.Test
{
    public class utItem
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
            Assert.That(dc.tblItems.Count(), Is.EqualTo(3));
        }

        [Test]
        public void InsertTest() {
            tblItem newItem = new tblItem();
            newItem.Id = Guid.NewGuid();
            newItem.Name = "Test";
            newItem.Description = "Description Test";
            dc.tblItems.Add(newItem);
            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest() {
            InsertTest();
            tblItem existingRow = dc.tblItems.FirstOrDefault(t => t.Name == "Test");
            if (existingRow != null) {
                existingRow.Name = "UpdateTest";
                dc.SaveChanges();
            }
            tblItem row = dc.tblItems.FirstOrDefault(t => t.Name == "UpdateTest");
            Assert.That(row.Name, Is.EqualTo(existingRow.Name));
        }

        [Test]
        public void DeleteTest() {
            InsertTest();
            tblItem row = dc.tblItems.FirstOrDefault(t => t.Name == "Test");
            if (row != null) {
                dc.tblItems.Remove(row);
                dc.SaveChanges();
            }
            tblItem deletedRow = dc.tblItems.FirstOrDefault(t => t.Name == "Test");
            Assert.That(deletedRow, Is.Null);
        }
    }
}