using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Repo
{
    public class InventoryService : IInventoryService
    {
        public InventoryContext _context;
        public InventoryService(InventoryContext context)
        {
            _context = context;
        }

        public List<InventoryModel> GetInventorys()
        {
            try
            {
                List<InventoryModel> Inventorys = _context.Inventorys.ToList();
                if (Inventorys.Count() > 0)
                {
                    return Inventorys;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public InventoryModel GetInventorysById(int Id)
        {
            try
            {
                InventoryModel Inventorys = _context.Inventorys.FirstOrDefault(x => x.Id == Id);
                if (Inventorys != null)
                {
                    return Inventorys;
                }
                else
                { return null; }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int DeleteInventory(int Id)
        {
            int saveInventory = 0;
            try
            {
                var existInventorys = _context.Inventorys.FirstOrDefault(x => x.Id == Id);
                if (existInventorys != null)
                {
                    _context.Remove(existInventorys);
                }
                saveInventory = _context.SaveChanges();
                return saveInventory;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SaveInventory(InventoryModel Inventory)
        {
            int saveInventory = 0;
            try
            {
                var existInventorys = _context.Inventorys.FirstOrDefault(x => x.Id == Inventory.Id);
                if (existInventorys != null)
                {
                    _context.Update(existInventorys);
                }
                else
                {
                    _context.Add(Inventory);
                }
                saveInventory = _context.SaveChanges();
                return saveInventory;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
