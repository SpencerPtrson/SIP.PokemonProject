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
        float SuperEffective = 2;
        float NotVeryEffective = 0.5f;
        float Immune = 0;

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

        public float ManageTypeEffectiveness(Models.Type attackingType, Models.Type defendingType) {
            switch (defendingType.TypeName) {
                // Type Effectiveness is listed by defending Type
                case "Normal":
                    if (attackingType.TypeName == "Fighting") return SuperEffective;
                    if (attackingType.TypeName == "Ghost") return Immune;
                    break;
                case "Fire":
                    // Types not very effective against Fire
                    if (attackingType.TypeName == "Fire") return NotVeryEffective;
                    if (attackingType.TypeName == "Grass") return NotVeryEffective;
                    if (attackingType.TypeName == "Ice") return NotVeryEffective;
                    if (attackingType.TypeName == "Bug") return NotVeryEffective;
                    if (attackingType.TypeName == "Steel") return NotVeryEffective;
                    if (attackingType.TypeName == "Fairy") return NotVeryEffective;
                    // Types SuperEffective against Fire
                    if (attackingType.TypeName == "Water") return SuperEffective;
                    if (attackingType.TypeName == "Ground") return SuperEffective;
                    if (attackingType.TypeName == "Rock") return SuperEffective;
                    break;
                case "Water":
                    // Types not very effective against Water
                    if (attackingType.TypeName == "Fire") return NotVeryEffective;
                    if (attackingType.TypeName == "Water") return NotVeryEffective;
                    if (attackingType.TypeName == "Ice") return NotVeryEffective;
                    if (attackingType.TypeName == "Steel") return NotVeryEffective;
                    // Types SuperEffective against Water
                    if (attackingType.TypeName == "Electric") return SuperEffective;
                    if (attackingType.TypeName == "Grass") return SuperEffective;
                    break;
                case "Electric":
                    // Types not very effective against Electric
                    if (attackingType.TypeName == "Electric") return NotVeryEffective;
                    if (attackingType.TypeName == "Flying") return NotVeryEffective;
                    if (attackingType.TypeName == "Steel") return NotVeryEffective;
                    // Types SuperEffective against Electric
                    if (attackingType.TypeName == "Ground") return SuperEffective;
                    break;
                case "Grass":
                    // Types not very effective against Grass
                    if (attackingType.TypeName == "Water") return NotVeryEffective;
                    if (attackingType.TypeName == "Electric") return NotVeryEffective;
                    if (attackingType.TypeName == "Grass") return NotVeryEffective;
                    if (attackingType.TypeName == "Ground") return NotVeryEffective;
                    // Types SuperEffective against Grass
                    if (attackingType.TypeName == "Fire") return SuperEffective;
                    if (attackingType.TypeName == "Ice") return SuperEffective;
                    if (attackingType.TypeName == "Poison") return SuperEffective;
                    if (attackingType.TypeName == "Flying") return SuperEffective;
                    if (attackingType.TypeName == "Bug") return SuperEffective;
                    break;
                case "Ice":
                    // Types not very effective against Ice
                    if (attackingType.TypeName == "Ice") return NotVeryEffective;
                    // Types SuperEffective against Ice
                    if (attackingType.TypeName == "Fire") return SuperEffective;
                    if (attackingType.TypeName == "Fighting") return SuperEffective;
                    if (attackingType.TypeName == "Rock") return SuperEffective;
                    if (attackingType.TypeName == "Steel") return SuperEffective;
                    break;
                case "Fighting":
                    // Types not very effective against Fighting
                    if (attackingType.TypeName == "Bug") return NotVeryEffective;
                    if (attackingType.TypeName == "Rock") return NotVeryEffective;
                    if (attackingType.TypeName == "Dark") return NotVeryEffective;
                    // Types SuperEffective against Fighting
                    if (attackingType.TypeName == "Flying") return SuperEffective;
                    if (attackingType.TypeName == "Psychic") return SuperEffective;
                    if (attackingType.TypeName == "Fairy") return SuperEffective;
                    break;
                case "Poison":
                    // Types not very effective against Poison
                    if (attackingType.TypeName == "Grass") return NotVeryEffective;
                    if (attackingType.TypeName == "Fighting") return NotVeryEffective;
                    if (attackingType.TypeName == "Poison") return NotVeryEffective;
                    if (attackingType.TypeName == "Bug") return NotVeryEffective;
                    if (attackingType.TypeName == "Fairy") return NotVeryEffective;
                    // Types SuperEffective against Poison
                    if (attackingType.TypeName == "Ground") return SuperEffective;
                    if (attackingType.TypeName == "Psychic") return SuperEffective;
                    break;
                case "Ground":
                    // Types not very effective against Ground
                    if (attackingType.TypeName == "Electric") return Immune;
                    if (attackingType.TypeName == "Poison") return NotVeryEffective;
                    if (attackingType.TypeName == "Rock") return NotVeryEffective;
                    // Types SuperEffective against Ground
                    if (attackingType.TypeName == "Water") return SuperEffective;
                    if (attackingType.TypeName == "Grass") return SuperEffective;
                    if (attackingType.TypeName == "Ice") return SuperEffective;
                    break;
                case "Flying":
                    // Types not very effective against Flying
                    if (attackingType.TypeName == "Ground") return Immune;
                    if (attackingType.TypeName == "Grass") return NotVeryEffective;
                    if (attackingType.TypeName == "Fighting") return NotVeryEffective;
                    if (attackingType.TypeName == "Bug") return NotVeryEffective;
                    // Types SuperEffective against Flying
                    if (attackingType.TypeName == "Electric") return SuperEffective;
                    if (attackingType.TypeName == "Ice") return SuperEffective;
                    if (attackingType.TypeName == "Rock") return SuperEffective;
                    break;
                case "Psychic":
                    // Types not very effective against Psychic
                    if (attackingType.TypeName == "Fighting") return NotVeryEffective;
                    if (attackingType.TypeName == "Psychic") return NotVeryEffective;
                    // Types SuperEffective against Psychic
                    if (attackingType.TypeName == "Bug") return SuperEffective;
                    if (attackingType.TypeName == "Ghost") return SuperEffective;
                    if (attackingType.TypeName == "Dark") return SuperEffective;
                    break;
                case "Bug":
                    // Types not very effective against Bug
                    if (attackingType.TypeName == "Grass") return NotVeryEffective;
                    if (attackingType.TypeName == "Fighting") return NotVeryEffective;
                    if (attackingType.TypeName == "Ground") return NotVeryEffective;
                    // Types SuperEffective against Bug
                    if (attackingType.TypeName == "Fire") return SuperEffective;
                    if (attackingType.TypeName == "Flying") return SuperEffective;
                    if (attackingType.TypeName == "Rock") return SuperEffective;
                    break;
                case "Rock":
                    // Types not very effective against Rock
                    if (attackingType.TypeName == "Normal") return NotVeryEffective;
                    if (attackingType.TypeName == "Fire") return NotVeryEffective;
                    if (attackingType.TypeName == "Poison") return NotVeryEffective;
                    if (attackingType.TypeName == "Flying") return NotVeryEffective;
                    // Types SuperEffective against Rock
                    if (attackingType.TypeName == "Water") return SuperEffective;
                    if (attackingType.TypeName == "Grass") return SuperEffective;
                    if (attackingType.TypeName == "Fighting") return SuperEffective;
                    if (attackingType.TypeName == "Ground") return SuperEffective;
                    if (attackingType.TypeName == "Steel") return SuperEffective;
                    break;
                case "Ghost":
                    // Types not very effective against Ghost
                    if (attackingType.TypeName == "Normal") return Immune;
                    if (attackingType.TypeName == "Fighting") return Immune;
                    if (attackingType.TypeName == "Poison") return NotVeryEffective;
                    if (attackingType.TypeName == "Bug") return NotVeryEffective;
                    // Types SuperEffective against Ghost
                    if (attackingType.TypeName == "Ghost") return SuperEffective;
                    if (attackingType.TypeName == "Dark") return SuperEffective;
                    break;
                case "Dragon":
                    // Types not very effective against Dragon
                    if (attackingType.TypeName == "Fire") return NotVeryEffective;
                    if (attackingType.TypeName == "Water") return NotVeryEffective;
                    if (attackingType.TypeName == "Electric") return NotVeryEffective;
                    if (attackingType.TypeName == "Grass") return NotVeryEffective;
                    // Types SuperEffective against Dragon
                    if (attackingType.TypeName == "Ice") return SuperEffective;
                    if (attackingType.TypeName == "Dragon") return SuperEffective;
                    if (attackingType.TypeName == "Fairy") return SuperEffective;
                    break;
                case "Dark":
                    // Types not very effective against Dark
                    if (attackingType.TypeName == "Psychic") return Immune;
                    if (attackingType.TypeName == "Ghost") return NotVeryEffective;
                    if (attackingType.TypeName == "Dark") return NotVeryEffective;
                    // Types SuperEffective against Dark
                    if (attackingType.TypeName == "Fighting") return SuperEffective;
                    if (attackingType.TypeName == "Bug") return SuperEffective;
                    if (attackingType.TypeName == "Fairy") return SuperEffective;
                    break;
                case "Steel":
                    // Types not very effective against Steel
                    if (attackingType.TypeName == "Poison") return Immune;
                    if (attackingType.TypeName == "Normal") return NotVeryEffective;
                    if (attackingType.TypeName == "Grass") return NotVeryEffective;
                    if (attackingType.TypeName == "Ice") return NotVeryEffective;
                    if (attackingType.TypeName == "Flying") return NotVeryEffective;
                    if (attackingType.TypeName == "Psychic") return NotVeryEffective;
                    if (attackingType.TypeName == "Bug") return NotVeryEffective;
                    if (attackingType.TypeName == "Rock") return NotVeryEffective;
                    if (attackingType.TypeName == "Dragon") return NotVeryEffective;
                    if (attackingType.TypeName == "Steel") return NotVeryEffective;
                    if (attackingType.TypeName == "Fairy") return NotVeryEffective;
                    // Types SuperEffective against Steel
                    if (attackingType.TypeName == "Fire") return SuperEffective;
                    if (attackingType.TypeName == "Fighting") return SuperEffective;
                    if (attackingType.TypeName == "Ground") return SuperEffective;
                    break;
                case "Fairy":
                    // Types not very effective against Fairy
                    if (attackingType.TypeName == "Dragon") return Immune;
                    if (attackingType.TypeName == "Fighting") return NotVeryEffective;
                    if (attackingType.TypeName == "Bug") return NotVeryEffective;
                    if (attackingType.TypeName == "Dark") return NotVeryEffective;
                    // Types SuperEffective against Fairy
                    if (attackingType.TypeName == "Poison") return SuperEffective;
                    if (attackingType.TypeName == "Steel") return SuperEffective;
                    break;
                default:
                    return 1;
            }
            return 0;
        }
    }
}
