using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net6SampleBasic.API.DTOs;
using Net6SampleBasic.API.Entities;
using Net6SampleBasic.API.Services;

namespace Net6SampleBasic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        }
        [HttpGet("{itemId}", Name = "GetItem")]
        public IActionResult GetItem(Guid itemId)
        {
            var item = _itemRepository.GetItem(itemId);
            return Ok(item);
        }

        [HttpGet("inventory/{inventoryId}")]
        public IActionResult GetItems(Guid inventoryId)
        {
            var items = _itemRepository.GetItems(inventoryId);
            return Ok(items);
        }

        [HttpGet("items")]
        public IActionResult GetItems()
        {
            var items = _itemRepository.GetItems();

            var itemsDto = from item in items
                           select new GetItemsDto
                           {
                               Id = item.Id,
                               Category = item.Category,
                               Description = item.Description,
                               AccessionRecord = item.AccessionRecord,
                           };

            return Ok(itemsDto.ToList());
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Item))]
        public IActionResult CreateItem([FromBody]CreateItemDto itemToCreate)
        {
            if (itemToCreate == null)
                return BadRequest(ModelState);

           var inventory = _itemRepository.GetInventory(itemToCreate.InventoryId);

            if (inventory == null)
                ModelState.AddModelError("", "Inventory doesn't exist!");

            var item = new Item
            {
                Id=itemToCreate.Id,
                InventoryId = itemToCreate.InventoryId,
                Category = itemToCreate.Category,
                Description=itemToCreate.Description,
                AccessionRecord=itemToCreate.AccessionRecord,
                Value = itemToCreate.Value
            };

            if (!_itemRepository.CreateItem(item))
            {
                ModelState.AddModelError("", $"Something went wrong saving the item");
                return StatusCode(500, ModelState);
            }
        
            return CreatedAtRoute("GetItem", new { itemId = itemToCreate.Id }, itemToCreate);

        }

        [HttpDelete("{itemId}")]
        public IActionResult DeleteItem(Guid itemId)
        {
            var itemToDelete = _itemRepository.GetItem(itemId);
            if (itemToDelete == null)
                ModelState.AddModelError("", "Item doesn't exist!");

            if (!_itemRepository.DeleteItem(itemToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the item");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
    }
}
