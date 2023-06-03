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
    public class TypeManager : GenericManager<tblType>
    {

        public async Task<List<Models.Type>> Load()
        {
            // NEED TO IMPLEMENT NATURES INTO STAT CALCULATION
            List<Models.Type> typeList = new List<Models.Type>();
            (await base.Load()).ToList().ForEach(t => typeList.Add(new Models.Type
            {
                Id = t.Id,
                TypeName = t.TypeName,
                TypeIcon = t.TypeIcon
            }));
            return typeList;
        }

        public async Task<Models.Type> LoadById(Guid id)
        {
            tblType tblType = await base.LoadById(id);
            return new Models.Type
            {
                Id = tblType.Id,
                TypeName = tblType.TypeName,
                TypeIcon = tblType.TypeIcon
            };
        }

        public async Task<Models.Type> LoadByTypeName(string typeName)
        {
            try
            {
                Models.Type returnType = new Models.Type();
                using (PokemonEntities dc = new PokemonEntities())
                {
                    tblType tblType = dc.tblTypes.Where(t => t.TypeName ==  typeName).FirstOrDefault();
                    if (tblType != null)
                    {
                        returnType.Id = tblType.Id;
                        returnType.TypeName = tblType.TypeName;
                        returnType.TypeIcon = tblType.TypeIcon;
                    }
                    return returnType;
                }
            }
            catch (Exception ex) { throw; }

        }

        public async Task<int> Insert(Models.Type newType, bool rollback = false)
        {
            try
            {
                tblType row = new tblType
                {
                    TypeName = newType.TypeName, 
                    TypeIcon = newType.TypeIcon,
                };
                int results = await base.Insert(row, rollback);
                newType.Id = row.Id;
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Update(Models.Type updatedType, bool rollback = false)
        {
            try
            {
                tblType row = await base.LoadById(updatedType.Id);
                row.TypeName = updatedType.TypeName;
                if (updatedType.TypeIcon != null) { row.TypeIcon = updatedType.TypeIcon; }
                int results = await base.Update(row, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Delete(Guid id, bool rollback = false)
        {
            try
            {
                // NEED TO DELETE POKEMON SPECIES / INDIVIDUAL POKEMON WITH THE TYPE TO BE DELETED

                int results = await base.Delete(id, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }

        public void ManageTypeEffectiveness(Models.Type attackingType, Models.Type defendingType1, Models.Type defendingType2) {

        }
    }
}
