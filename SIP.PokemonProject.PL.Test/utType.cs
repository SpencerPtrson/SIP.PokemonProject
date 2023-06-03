using Microsoft.EntityFrameworkCore.Storage;

namespace SIP.PokemonProject.PL.Test
{
    public class utType
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
            Assert.That(dc.tblTypes.Count(), Is.EqualTo(19));
        }

        [Test]
        public void InsertTest() {
            tblType newType = new tblType();
            newType.Id = Guid.NewGuid();
            newType.TypeName = "Test";
            dc.tblTypes.Add(newType);
            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest() {
            InsertTest();
            tblType existingRow = dc.tblTypes.FirstOrDefault(t => t.TypeName == "Test");
            if (existingRow != null) {
                existingRow.TypeName = "UpdateTest";
                dc.SaveChanges();
            }
            tblType row = dc.tblTypes.FirstOrDefault(t => t.TypeName == "UpdateTest");
            Assert.That(row.TypeName, Is.EqualTo(existingRow.TypeName));
        }

        [Test]
        public void DeleteTest() {
            InsertTest();
            tblType row = dc.tblTypes.FirstOrDefault(t => t.TypeName == "Test");
            if (row != null) {
                dc.tblTypes.Remove(row);
                dc.SaveChanges();
            }
            tblType deletedRow = dc.tblTypes.FirstOrDefault(t => t.TypeName == "Test");
            Assert.That(deletedRow, Is.Null);
        }
    }
}