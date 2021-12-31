using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net6SampleBasic.API.DTOs;
using Net6SampleBasic.API.Entities;
using Net6SampleBasic.API.Services;

namespace Net6SampleBasic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class InventoryController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public InventoryController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        }

        [HttpGet("{inventoryId}")]
        public IActionResult GetInventory(Guid inventoryId)
        {
            var inventory = _itemRepository.GetInventory(inventoryId);
            return Ok(inventory);
        }

        [HttpGet]
        public IActionResult GetInventories()
        {
            var inventories = _itemRepository.GetInventories();

            var inventoriesDto = from inventory in inventories
                                 select new GetInventoriesDto
                                 {
                                     Id = inventory.Id,
                                     Name = inventory.Name,
                                     LocationTag = inventory.LocationTag,
                                 };
            return Ok(inventoriesDto.ToList());
        }




    }
}
