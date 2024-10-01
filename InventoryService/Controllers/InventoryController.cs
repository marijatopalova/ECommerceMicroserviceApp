using InventoryService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        // Sample in-memory inventory items
        private static List<InventoryItem> Inventory =
        [
            new InventoryItem { Id = 1, ProductId = 101, Quantity = 50 },
            new InventoryItem { Id = 2, ProductId = 102, Quantity = 20 },
        ];

        [HttpGet]
        public IActionResult GetInventoryItems()
        {
            return Ok(Inventory);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInventoryItem(int id, [FromBody] InventoryItem updatedItem)
        {
            var item = Inventory.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            item.Quantity = updatedItem.Quantity;
            return Ok(item);
        }
    }
}
