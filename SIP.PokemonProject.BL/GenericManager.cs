using SIP.PokemonProject.PL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SIP.PokemonProject.BL
{
    public abstract class GenericManager<T> where T : class, IEntity
    {
        public async Task<IList<T>> Load()
        {
            try
            {
                var rows = new PokemonEntities()
                    .Set<T>()
                    .ToListAsync<T>()
                    .ConfigureAwait(false);
                return await rows;
            }
            catch (Exception) { throw; }
        }

        public async Task<T> LoadById(Guid id)
        {
            try
            {
                var row = new PokemonEntities().Set<T>().Where(g => g.Id == id).FirstOrDefault();
                return row;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Insert(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (PokemonEntities dc = new PokemonEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    entity.Id = Guid.NewGuid();

                    dc.Set<T>().Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) dbContextTransaction.Rollback();
                }
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Update(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (PokemonEntities dc = new PokemonEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();
                    dc.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    results = dc.SaveChanges();
                    if (rollback) dbContextTransaction.Rollback();
                }
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (PokemonEntities dc = new PokemonEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    T row = dc.Set<T>().FirstOrDefault(s => s.Id == id);

                    if (row != null)
                    {
                        dc.Set<T>().Remove(row);
                        results = dc.SaveChanges();

                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else throw new Exception("Row does not exist.");
                }
                return results;
            }
            catch (Exception) { throw; }
        }
    }
}
