using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace SIP.PokemonProject.PL.Test
{
    public class utPokedex
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
            Assert.That(dc.tblPokedices.Count(), Is.EqualTo(4));
        }

        [Test]
        public void InsertTest() {
            tblPokedex newPokedex = new tblPokedex();
            newPokedex.Id = Guid.NewGuid();
            newPokedex.PokedexNum = dc.tblPokedices.Count() + 1;
            newPokedex.SpeciesName = "Test Species";
            newPokedex.SpriteName = "Test Sprite Name";
            newPokedex.FlavorText = "Test FlavorText";
            newPokedex.Type1Id = dc.tblTypes.FirstOrDefault().Id;
            newPokedex.Type2Id = dc.tblTypes.FirstOrDefault().Id;

            newPokedex.BaseHP = -1;
            newPokedex.BaseAttack = -1;
            newPokedex.BaseDefense = -1;
            newPokedex.BaseSpecialAttack = -1;
            newPokedex.BaseSpecialDefense = -1;
            newPokedex.BaseSpeed = -1;
            dc.tblPokedices.Add(newPokedex);
            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();
            tblPokedex existingRow = dc.tblPokedices.FirstOrDefault(t => t.SpeciesName == "Test Species");
            if (existingRow != null)
            {
                existingRow.SpeciesName = "UpdateTest";
                dc.SaveChanges();
            }
            tblPokedex row = dc.tblPokedices.FirstOrDefault(t => t.SpeciesName == "UpdateTest");
            Assert.That(row.SpeciesName, Is.EqualTo(existingRow.SpeciesName));
        }

        [Test]
        public void DeleteTest()
        {
            InsertTest();
            tblPokedex row = dc.tblPokedices.FirstOrDefault(t => t.SpeciesName == "Test");
            if (row != null)
            {
                dc.tblPokedices.Remove(row);
                dc.SaveChanges();
            }
            tblPokedex deletedRow = dc.tblPokedices.FirstOrDefault(t => t.SpeciesName == "Test");
            Assert.That(deletedRow, Is.Null);
        }
    }
}