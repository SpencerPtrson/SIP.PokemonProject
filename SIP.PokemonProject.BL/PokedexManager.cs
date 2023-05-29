using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIP.PokemonProject.BL;
using SIP.PokemonProject.PL;
using SIP.PokemonProject.BL.Models;
using System.Drawing;
using System.Buffers.Text;

namespace SIP.PokemonProject.BL
{
    public class PokedexManager : GenericManager<tblPokedex>
    {

        // Load a list of pokemon species with data for each of them
        public async Task<List<PokedexData>> Load()
        {
            List<PokedexData> speciesList = new List<PokedexData>();
            (await base.Load()).ToList().ForEach(pd => speciesList.Add(new PokedexData
            {
                SpeciesId = pd.Id,
                PokedexNum = pd.PokedexNum,
                SpeciesName = pd.SpeciesName,
                Type1Id = pd.Type1Id,
                Type2Id = pd.Type2Id,
                BaseHP = pd.BaseHP,
                BaseAttack = pd.BaseAttack,
                BaseDefense = pd.BaseDefense,
                BaseSpecialAttack = pd.BaseSpecialAttack,
                BaseSpecialDefense = pd.BaseSpecialDefense,
                BaseSpeed = pd.BaseSpeed,
                SpritePath = pd.SpriteName
            }));
            return speciesList;
        }

        // Load data about a specific pokemon species
        public async Task<PokedexData> LoadById(Guid id)
        {
            tblPokedex tblPokedex = await base.LoadById(id);
            return new PokedexData
            {
                SpeciesId = tblPokedex.Id,
                PokedexNum = tblPokedex.PokedexNum,
                SpeciesName = tblPokedex.SpeciesName,
                Type1Id= tblPokedex.Type1Id,
                Type2Id = tblPokedex.Type2Id,
                BaseHP = tblPokedex.BaseHP, 
                BaseAttack= tblPokedex.BaseAttack,
                BaseDefense= tblPokedex.BaseDefense,
                BaseSpecialAttack= tblPokedex.BaseSpecialAttack,
                BaseSpecialDefense = tblPokedex.BaseSpecialDefense,
                BaseSpeed= tblPokedex.BaseSpeed,
                SpritePath = tblPokedex.SpriteName
            };
        }

        public async Task<PokedexData> LoadBySpeciesName(string speciesName)
        {
            try
            {
                PokedexData speciesData = new PokedexData();

                using (PokemonEntities dc = new PokemonEntities())
                {
                    tblPokedex tblPokedex = dc.tblPokedices.Where(pd => pd.SpeciesName == speciesName).FirstOrDefault();
                    if (tblPokedex != null)
                    {
                        speciesData.SpeciesId = tblPokedex.Id;
                        speciesData.PokedexNum = tblPokedex.PokedexNum;
                        speciesData.SpeciesName = tblPokedex.SpeciesName;
                        speciesData.Type1Id = tblPokedex.Type1Id;
                        speciesData.Type2Id = tblPokedex.Type2Id;
                        speciesData.BaseHP = tblPokedex.BaseHP;
                        speciesData.BaseAttack = tblPokedex.BaseAttack;
                        speciesData.BaseDefense = tblPokedex.BaseDefense;
                        speciesData.BaseSpecialAttack = tblPokedex.BaseSpecialAttack;
                        speciesData.BaseSpecialDefense = tblPokedex.BaseSpecialDefense;
                        speciesData.BaseSpeed = tblPokedex.BaseSpeed;
                        speciesData.SpritePath = tblPokedex.SpriteName;
                    }
                    return speciesData;
                }
            }
            catch (Exception ex) { throw; }

        }

        // When given a set of species data, insert that data into the pokedex
        public async Task<int> Insert(PokedexData speciesToInsert, bool rollback = false)
        {
            try
            {
                tblPokedex row = new tblPokedex
                {
                    PokedexNum = speciesToInsert.PokedexNum,
                    SpeciesName = speciesToInsert.SpeciesName,
                    Type1Id = speciesToInsert.Type1Id,
                    Type2Id= speciesToInsert.Type2Id,
                    BaseHP= speciesToInsert.BaseHP,
                    BaseAttack = speciesToInsert.BaseAttack,
                    BaseDefense = speciesToInsert.BaseDefense,
                    BaseSpecialAttack = speciesToInsert.BaseSpecialAttack,
                    BaseSpecialDefense = speciesToInsert.BaseSpecialDefense,
                    BaseSpeed = speciesToInsert.BaseSpeed,
                    SpriteName = speciesToInsert.SpritePath
                };
                int results = await base.Insert(row, rollback);
                speciesToInsert.SpeciesId = row.Id;
                return results;
            }
            catch (Exception) { throw; }
        }

        // Update the specifics of a pokemon species
        public async Task<int> Update(PokedexData speciesData, bool rollback = false)
        {
            try
            {
                tblPokedex row = await base.LoadById(speciesData.SpeciesId);
                row.PokedexNum = speciesData.PokedexNum;
                row.SpeciesName = speciesData.SpeciesName;
                row.SpriteName = speciesData.SpritePath;
                row.Type1Id = speciesData.Type1Id;
                row.Type2Id = speciesData.Type2Id;
                row.BaseHP = speciesData.BaseHP;
                row.BaseAttack = speciesData.BaseAttack;
                row.BaseDefense = speciesData.BaseDefense;
                row.BaseSpecialAttack = speciesData.BaseSpecialAttack;
                row.BaseSpecialDefense = speciesData.BaseSpecialDefense;
                row.BaseSpeed = speciesData.BaseSpeed;

                int results = await base.Update(row, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }

        // Delete a pokemon species completely
        public async Task<int> Delete(Guid speciesId, bool rollback = false)
        {
            try
            {
                // Need to Delete Pokemon Instances (and from Pokemon Teams) where this species is

                int results = await base.Delete(speciesId, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }
    }
}
