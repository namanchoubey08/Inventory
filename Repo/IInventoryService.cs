using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Repo
{
    public interface IInventoryService
    {
        List<InventoryModel> GetInventorys();
        InventoryModel GetInventorysById(int Id);
        int SaveInventory(InventoryModel inventory);
        int DeleteInventory(int Id);
    }
}
