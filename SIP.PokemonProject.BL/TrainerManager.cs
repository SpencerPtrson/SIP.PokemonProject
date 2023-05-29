using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SIP.PokemonProject.BL;
using SIP.PokemonProject.BL.Models;
using SIP.PokemonProject.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIP.PokemonProject.BL
{
    public class TrainerManager : GenericManager<tblTrainer>
    {
        public async Task<List<Trainer>> Load()
        {
            List<Trainer> trainers = new();
            (await base.Load())
                .ToList()
                .ForEach(t => trainers.Add(new Trainer
                {
                    Id = t.Id,
                    Name = t.Name,
                    Money = t.Money,
                    Team = (List<Pokemon>)t.tblPokemonTeams.Where(m => m.TrainerId == t.Id)
                }));
            return trainers;
        }

        public async Task<Trainer> LoadById(Guid id)
        {
            tblTrainer tblTrainer = await base.LoadById(id);
            return new Trainer
            {
                Id = tblTrainer.Id,
                Name = tblTrainer.Name,
                Money = tblTrainer.Money,
                Team = (List<Pokemon>)tblTrainer.tblPokemonTeams.Where(m => m.TrainerId == tblTrainer.Id)
            };
        }

        public async Task<int> Insert(Trainer trainer, bool rollback = false)
        {
            try
            {
                tblTrainer row = new tblTrainer
                {
                    Name = trainer.Name,
                    Money = trainer.Money,                    
                };
                int results = await base.Insert(row, rollback);
                // INSERT INTO tblPokemonTeam for each pokemon in trainer.Team

                trainer.Id = row.Id;
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Insert(string name, int money, List<Pokemon> team, bool rollback = false)
        {
            try
            {
                tblTrainer row = new tblTrainer { Name = name, Money = money };
                // INSERT INTO tblPokemonTeam for each pokemon in trainer.Team

                int results = await this.Insert(row, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Delete(Guid id, bool rollback = false)
        {
            try
            {
                // Make sure to delete from tblPokemonTeam before deleting trainer
                int results = await base.Delete(id, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Update(Trainer trainer, bool rollback = false)
        {
            try
            {
                tblTrainer row = await base.LoadById(trainer.Id);
                row.Name = trainer.Name;
                row.Money = trainer.Money;

                // UPDATE TRAINER TEAM


                int results = await base.Update(row, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }
    }
}
