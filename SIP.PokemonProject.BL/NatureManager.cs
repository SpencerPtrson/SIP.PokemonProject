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

namespace SIP.PokemonProject.BL
{
    public class NatureManager : GenericManager<tblNature>
    {

        public async Task<List<Nature>> Load()
        {
            List<Nature> natureList = new List<Nature>();
            (await base.Load()).ToList().ForEach(n => natureList.Add(new Nature
            {
                Id = n.Id,
                Name = n.Name,
                StatIncreased = n.StatIncreased,
                StatDecreased = n.StatDecreased,
            }));
            return natureList;
        }

        public async Task<Nature> LoadById(Guid id)
        {
            tblNature tblNature = await base.LoadById(id);
            return new Nature
            {
                Id = tblNature.Id,
                Name = tblNature.Name,
                StatIncreased = tblNature.StatIncreased,
                StatDecreased = tblNature.StatDecreased,
            };
        }

        public async Task<Nature> LoadByNatureName(string natureName)
        {
            try
            {
                Nature returnNature = new Nature();
                using (PokemonEntities dc = new PokemonEntities())
                {
                    tblNature tblNature = dc.tblNatures.Where(t => t.Name ==  natureName).FirstOrDefault();
                    if (tblNature != null)
                    {
                        returnNature.Id = tblNature.Id;
                        returnNature.Name = tblNature.Name;
                        returnNature.StatIncreased = tblNature.StatIncreased;
                        returnNature.StatDecreased = tblNature.StatDecreased;
                    }
                    return returnNature;
                }
            }
            catch (Exception ex) { throw; }
        }

        public async Task<int> Insert(Nature newNature, bool rollback = false)
        {
            try
            {
                tblNature row = new tblNature
                {
                    Name = newNature.Name, 
                    StatIncreased = newNature.StatIncreased,
                    StatDecreased = newNature.StatDecreased,
                };
                int results = await base.Insert(row, rollback);
                newNature.Id = row.Id;
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Update(Nature updatedNature, bool rollback = false)
        {
            try
            {
                tblNature row = await base.LoadById(updatedNature.Id);
                row.Name = updatedNature.Name;
                row.StatIncreased = updatedNature.StatIncreased;
                row.StatDecreased = updatedNature.StatDecreased;
                int results = await base.Update(row, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Delete(Guid id, bool rollback = false)
        {
            try
            {
                // NEED TO DELETE POKEMON SPECIES / INDIVIDUAL POKEMON WITH THE Nature TO BE DELETED
                int results = await base.Delete(id, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }
    }
}
