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
    public class AbilityManager : GenericManager<tblAbility>
    {

        public async Task<List<Ability>> Load()
        {
            List<Ability> AbilityList = new List<Ability>();
            (await base.Load()).ToList().ForEach(n => AbilityList.Add(new Ability
            {
                Id = n.Id,
                Name = n.Name,
                Description = n.Description,
            }));
            return AbilityList;
        }

        public async Task<Ability> LoadById(Guid id)
        {
            tblAbility tblAbility = await base.LoadById(id);
            return new Ability
            {
                Id = tblAbility.Id,
                Name = tblAbility.Name,
                Description = tblAbility.Description,
            };
        }

        public async Task<Ability> LoadByAbilityName(string AbilityName)
        {
            try
            {
                Ability returnAbility = new Ability();
                using (PokemonEntities dc = new PokemonEntities())
                {
                    tblAbility tblAbility = dc.tblAbilities.Where(t => t.Name ==  AbilityName).FirstOrDefault();
                    if (tblAbility != null)
                    {
                        returnAbility.Id = tblAbility.Id;
                        returnAbility.Name = tblAbility.Name;
                        returnAbility.Description = tblAbility.Description;
                    }
                    return returnAbility;
                }
            }
            catch (Exception ex) { throw; }
        }

        public async Task<int> Insert(Ability newAbility, bool rollback = false)
        {
            try
            {
                tblAbility row = new tblAbility
                {
                    Name = newAbility.Name, 
                    Description = newAbility.Description,
                };
                int results = await base.Insert(row, rollback);
                newAbility.Id = row.Id;
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Update(Ability updatedAbility, bool rollback = false)
        {
            try
            {
                tblAbility row = await base.LoadById(updatedAbility.Id);
                row.Name = updatedAbility.Name;
                row.Description = updatedAbility.Description;
                int results = await base.Update(row, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Delete(Guid id, bool rollback = false)
        {
            try
            {
                // NEED TO DELETE POKEMON SPECIES / INDIVIDUAL POKEMON WITH THE Ability TO BE DELETED
                int results = await base.Delete(id, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }
    }
}
