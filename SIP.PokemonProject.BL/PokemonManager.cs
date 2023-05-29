//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.EntityFrameworkCore.Storage;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using SIP.PokemonProject.BL;
//using SIP.PokemonProject.PL;
//using SIP.PokemonProject.BL.Models;
//using System.Drawing;

//namespace SIP.PokemonProject.BL
//{
//    public class PokemonManager : GenericManager<tblPokemon>
//    {

//        public async Task<List<Pokemon>> Load()
//        {
//            // NEED TO IMPLEMENT NATURES INTO STAT CALCULATION
//            List<Pokemon> pokemonList = new List<Pokemon>();
//            (await base.Load()).ToList().ForEach(p => pokemonList.Add(new Pokemon
//            {
//                Id = p.Id,
//                SpeciesId = p.SpeciesId,
//                Type1 = p.Type1Id,
//                Type2 = p.Type2Id,
//                NatureId = p.NatureId,
//                AbilityId = p.AbilityId,
//                ItemId = (Guid)p.ItemId,
//                IsShiny = p.IsShiny,
//                Nickname = p.Nickname,
//                MajorStatus = p.Status,
//                Level = p.Level,

//                MaxHP = (int)(Math.Floor(0.01d * (2 * p.Species.BaseHP + p.HPIVs + Math.Floor(0.25d * p.HPEVs)) * p.Level) + p.Level + 10),
//                HPEV = p.HPEVs,
//                HPIV = p.HPIVs,
//                Attack = (int)(Math.Floor(0.01d * (2 * p.Species.BaseAttack + p.AttackIVs + Math.Floor(0.25d * p.AttackEVs)) * p.Level) + 5),
//                AttackEV = p.AttackEVs,
//                AttackIV = p.AttackIVs,
//                Defense = (int)(Math.Floor(0.01d * (2 * p.Species.BaseDefense + p.DefenseIVs + Math.Floor(0.25d * p.DefenseEVs)) * p.Level) + 5),
//                DefenseEV = p.DefenseEVs,
//                DefenseIV = p.DefenseEVs,
//                SpecialAttack = (int)(Math.Floor(0.01d * (2 * p.Species.BaseSpecialAttack + p.SpecialAttackIVs + Math.Floor(0.25d * p.SpecialAttackEVs)) * p.Level) + 5),
//                SpecialAttackEV = p.SpecialAttackEVs,
//                SpecialAttackIV = p.SpecialAttackIVs,
//                SpecialDefense = (int)(Math.Floor(0.01d * (2 * p.Species.BaseSpecialDefense + p.SpecialDefenseIVs + Math.Floor(0.25d * p.SpecialDefenseEVs)) * p.Level) + 5),
//                SpecialDefenseEV = p.SpecialDefenseEVs,
//                SpecialDefenseIV = p.SpecialDefenseIVs,
//                Speed = (int)(Math.Floor(0.01d * (2 * p.Species.BaseSpeed + p.SpeedIVs + Math.Floor(0.25d * p.SpeedEVs)) * p.Level) + 5),
//                SpeedEV = p.SpeedEVs,
//                SpeedIV = p.SpeedIVs,
//            }));
//            return pokemonList;
//        }

//        public async Task<Pokemon> LoadById(Guid id)
//        {
//            tblPokemon tblPokemon = await base.LoadById(id);
//            return new Pokemon
//            {
//                Id = tblPokemon.Id,
//                SpeciesId = tblPokemon.SpeciesId,
//                Type1 = tblPokemon.Type1Id,
//                Type2 = tblPokemon.Type2Id,
//                NatureId = tblPokemon.NatureId,
//                AbilityId = tblPokemon.AbilityId,
//                ItemId = (Guid)tblPokemon.ItemId,
//                IsShiny = tblPokemon.IsShiny,
//                Nickname = tblPokemon.Nickname,
//                MajorStatus = tblPokemon.Status,
//                Level = tblPokemon.Level,

//                MaxHP = (int)(Math.Floor(0.01d * (2 * tblPokemon.Species.BaseHP + tblPokemon.HPIVs + Math.Floor(0.25d * tblPokemon.HPEVs)) * tblPokemon.Level) + tblPokemon.Level + 10),
//                HPEV = tblPokemon.HPEVs,
//                HPIV = tblPokemon.HPIVs,
//                Attack = (int)(Math.Floor(0.01d * (2 * tblPokemon.Species.BaseAttack + tblPokemon.AttackIVs + Math.Floor(0.25d * tblPokemon.AttackEVs)) * tblPokemon.Level) + 5),
//                AttackEV = tblPokemon.AttackEVs,
//                AttackIV = tblPokemon.AttackIVs,
//                Defense = (int)(Math.Floor(0.01d * (2 * tblPokemon.Species.BaseDefense + tblPokemon.DefenseIVs + Math.Floor(0.25d * tblPokemon.DefenseEVs)) * tblPokemon.Level) + 5),
//                DefenseEV = tblPokemon.DefenseEVs,
//                DefenseIV = tblPokemon.DefenseEVs,
//                SpecialAttack = (int)(Math.Floor(0.01d * (2 * tblPokemon.Species.BaseSpecialAttack + tblPokemon.SpecialAttackIVs + Math.Floor(0.25d * tblPokemon.SpecialAttackEVs)) * tblPokemon.Level) + 5),
//                SpecialAttackEV = tblPokemon.SpecialAttackEVs,
//                SpecialAttackIV = tblPokemon.SpecialAttackIVs,
//                SpecialDefense = (int)(Math.Floor(0.01d * (2 * tblPokemon.Species.BaseSpecialDefense + tblPokemon.SpecialDefenseIVs + Math.Floor(0.25d * tblPokemon.SpecialDefenseEVs)) * tblPokemon.Level) + 5),
//                SpecialDefenseEV = tblPokemon.SpecialDefenseEVs,
//                SpecialDefenseIV = tblPokemon.SpecialDefenseIVs,
//                Speed = (int)(Math.Floor(0.01d * (2 * tblPokemon.Species.BaseSpeed + tblPokemon.SpeedIVs + Math.Floor(0.25d * tblPokemon.SpeedEVs)) * tblPokemon.Level) + 5),
//                SpeedEV = tblPokemon.SpeedEVs,
//                SpeedIV = tblPokemon.SpeedIVs,
//            };
//        }

//        public async Task<int> Insert(Pokemon pokemon, bool rollback = false)
//        {
//            try
//            {
//                tblPokemon row = new tblPokemon
//                {
//                    SpeciesId = pokemon.SpeciesId,
//                    NatureId = pokemon.NatureId,
//                    AbilityId = pokemon.AbilityId,
//                    ItemId = pokemon.ItemId,
//                    Type1Id = pokemon.Type1,
//                    Type2Id = pokemon.Type2,
//                    Level = pokemon.Level,
//                    IsShiny = pokemon.IsShiny,
//                    Nickname = pokemon.Nickname,
//                    Status = pokemon.MajorStatus,

//                    HPEVs = pokemon.HPEV,
//                    HPIVs = pokemon.HPIV,
//                    AttackEVs = pokemon.AttackEV,
//                    AttackIVs = pokemon.AttackIV,
//                    DefenseEVs = pokemon.DefenseEV,
//                    DefenseIVs = pokemon.DefenseIV,
//                    SpecialAttackEVs = pokemon.SpecialAttackEV,
//                    SpecialAttackIVs = pokemon.SpecialAttackIV,
//                    SpecialDefenseEVs = pokemon.SpecialDefenseEV,
//                    SpecialDefenseIVs = pokemon.SpecialDefenseIV,
//                    SpeedEVs = pokemon.SpeedEV,
//                    SpeedIVs = pokemon.SpeedIV,
//                };
//                int results = await base.Insert(row, rollback);
//                pokemon.Id = row.Id;
//                return results;
//            }
//            catch (Exception) { throw; }
//        }

//        public async Task<int> Delete(Guid id, bool rollback = false)
//        {
//            try
//            {
//                // DELETE FROM PokemonTeam where this pokemon is
//                int results = await base.Delete(id, rollback);
//                return results;
//            }
//            catch (Exception) { throw; }
//        }

//        public async Task<int> Update(Pokemon pokemon, bool rollback = false)
//        {
//            try
//            {
//                tblPokemon row = await base.LoadById(pokemon.Id);
//                row.SpeciesId = pokemon.SpeciesId;
//                row.NatureId = pokemon.NatureId;
//                row.AbilityId = pokemon.AbilityId;
//                if(pokemon.ItemId != null) row.ItemId = pokemon.ItemId;
//                if (pokemon.Nickname != null) row.Nickname = pokemon.Nickname;
//                row.Level = pokemon.Level;
//                row.IsShiny = pokemon.IsShiny;
//                if (pokemon.MajorStatus != null) row.Status = pokemon.MajorStatus;
//                row.HPEVs = pokemon.HPEV;
//                row.HPIVs = pokemon.HPIV;
//                row.AttackEVs = pokemon.AttackEV;
//                row.AttackIVs = pokemon.AttackIV;
//                row.DefenseEVs = pokemon.DefenseEV;
//                row.DefenseIVs = pokemon.DefenseIV;
//                row.SpecialAttackEVs = pokemon.SpecialAttackEV;
//                row.SpecialAttackIVs = pokemon.SpecialAttackIV;
//                row.SpecialDefenseEVs = pokemon.SpecialDefenseEV;
//                row.SpecialDefenseIVs = pokemon.SpecialDefenseIV;
//                row.SpeedEVs = pokemon.SpeedEV;
//                row.SpeedIVs = pokemon.SpeedIV;

//                int results = await base.Update(row, rollback);
//                return results;
//            }
//            catch (Exception) { throw; }
//        }
//    }
//}
