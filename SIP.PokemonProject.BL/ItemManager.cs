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
    public class ItemManager : GenericManager<tblItem>
    {

        public async Task<List<Item>> Load()
        {
            List<Item> items = new List<Item>();
            (await base.Load()).ToList().ForEach(n => items.Add(new Item
            {
                Id = n.Id,
                Name = n.Name,
                Description = n.Description,
            }));
            return items;
        }

        public async Task<Item> LoadById(Guid id)
        {
            tblItem tblItem = await base.LoadById(id);
            return new Item
            {
                Id = tblItem.Id,
                Name = tblItem.Name,
                Description = tblItem.Description,
            };
        }

        public async Task<Item> LoadByItemName(string ItemName)
        {
            try
            {
                Item returnItem = new Item();
                using (PokemonEntities dc = new PokemonEntities())
                {
                    tblItem tblItem = dc.tblItems.Where(t => t.Name ==  ItemName).FirstOrDefault();
                    if (tblItem != null)
                    {
                        returnItem.Id = tblItem.Id;
                        returnItem.Name = tblItem.Name;
                        returnItem.Description = tblItem.Description;
                    }
                    return returnItem;
                }
            }
            catch (Exception ex) { throw; }
        }

        public async Task<int> Insert(Item newItem, bool rollback = false)
        {
            try
            {
                tblItem row = new tblItem
                {
                    Name = newItem.Name, 
                    Description = newItem.Description,
                };
                int results = await base.Insert(row, rollback);
                newItem.Id = row.Id;
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Update(Item updatedItem, bool rollback = false)
        {
            try
            {
                tblItem row = await base.LoadById(updatedItem.Id);
                row.Name = updatedItem.Name;
                row.Description = updatedItem.Description;
                int results = await base.Update(row, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Delete(Guid id, bool rollback = false)
        {
            try
            {
                // NEED TO DELETE POKEMON SPECIES / INDIVIDUAL POKEMON WITH THE Item TO BE DELETED
                int results = await base.Delete(id, rollback);
                return results;
            }
            catch (Exception) { throw; }
        }
    }
}
