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
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Packaging.Signing;

namespace SIP.PokemonProject.BL
{
    public class MoveManager : GenericManager<tblMove>
    {
        public async Task<List<Move>> Load() {
            // NEED TO IMPLEMENT NATURES INTO STAT CALCULATION
            List<Move> MoveList = new List<Move>();
            (await base.Load()).ToList().ForEach(m => MoveList.Add(new Move {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                TypeId = m.TypeId,
                TypeName = m.Type.TypeName,
                Category = m.Category,
                normalPP = m.PP,
                BasePower = m.Power,
                Accuracy = m.Accuracy,
                Priority = m.Priority,
                Target = m.Target,
                CritRate = (float)m.CritRate
            }));
            return MoveList;
        }

        public async Task<Move> LoadById(Guid id) {
            tblMove m = await base.LoadById(id);
            return new Move {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                TypeId = m.TypeId,
                TypeName = m.Type.TypeName,
                Category = m.Category,
                normalPP = m.PP,
                BasePower = m.Power,
                Accuracy = m.Accuracy,
                Priority = m.Priority,
                Target = m.Target,
                CritRate = (float)m.CritRate
            };
        }

        public async Task<Move> LoadByMoveName(string MoveName) {
            try {
                Move returnMove = new Move();
                using (PokemonEntities dc = new PokemonEntities()) {
                    tblMove m = dc.tblMoves.Where(t => t.Name == MoveName).FirstOrDefault();
                    if (m != null) {
                        returnMove.Id = m.Id;
                        returnMove.Name = m.Name;
                        returnMove.Description = m.Description;
                        returnMove.TypeId = m.TypeId;
                        returnMove.TypeName = m.Type.TypeName;
                        returnMove.Category = m.Category;
                        returnMove.normalPP = m.PP;
                        returnMove.BasePower = m.Power;
                        returnMove.Accuracy = m.Accuracy;
                        returnMove.Priority = m.Priority;
                        returnMove.Target = m.Target;
                        returnMove.CritRate = (float)m.CritRate;
                    }
                    return returnMove;
                }
            }
            catch (Exception ex) { throw; }
        }

        public async Task<int> Insert(Move newMove, bool rollback = false) {
            try {
                tblMove row = new tblMove {
                    Name = newMove.Name,
                    Description = newMove.Description,
                    TypeId = newMove.TypeId,
                    Category = newMove.Category,
                    PP = newMove.normalPP,
                    Power = newMove.BasePower,
                    Accuracy = newMove.Accuracy,
                    Priority = newMove.Priority,
                    Target = newMove.Target,
                    CritRate = newMove.CritRate,
                };
                int results = await base.Insert(row, rollback);
                newMove.Id = row.Id;
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Update(Move updatedMove, bool rollback = false) {
            try {
                tblMove row = await base.LoadById(updatedMove.Id);
                row.Name = updatedMove.Name;
                row.Description = updatedMove.Description;
                row.TypeId = updatedMove.TypeId;
                row.Category = updatedMove.Category;
                row.PP = updatedMove.normalPP;
                row.Power = updatedMove.BasePower;
                row.Accuracy = updatedMove.Accuracy;
                row.Priority = updatedMove.Priority;
                row.Target = updatedMove.Target;
                row.CritRate = updatedMove.CritRate;
                int results = await base.Update(row, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Delete(Guid id, bool rollback = false) {
            try {
                // Delete moves from pokemon that have the moves before deleting the move
                int results = await base.Delete(id, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }
    }
}
