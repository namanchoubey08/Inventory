using Inventory.Models;
using Inventory.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Controllers
{
    public class InventoryController : ControllerBase
    {
        IInventoryService _Service;
        public InventoryController(IInventoryService service)
        {
            _Service = service;
        }

        [HttpGet]
        [Route("GetInventorysAPI")]
        public IActionResult GetInventorys()
        {
            try
            {
                var lstInventorys = _Service.GetInventorys();
                if (lstInventorys == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(lstInventorys);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetInventorysByIdAPI")]
        public IActionResult GetInventorysById(int Id)
        {
            try
            {
                var employees = _Service.GetInventorysById(Id);
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("SaveInventorysAPI")]
        public IActionResult SaveInventorys(InventoryModel employeeModel)
        {
            try
            {
                var model = _Service.SaveInventory(employeeModel);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeleteInventorysAPI")]
        public IActionResult DeleteInventorys(int Id)
        {
            try
            {
                var model = _Service.DeleteInventory(Id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
