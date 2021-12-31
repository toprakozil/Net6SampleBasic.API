using Net6SampleBasic.API.Entities;

namespace Net6SampleBasic.API.Services
{
    public interface IItemRepository
    {
        Item GetItem(Guid itemId);
        IEnumerable<Item> GetItems(Guid inventoryId);
        IEnumerable<Item> GetItems();

        Inventory GetInventory(Guid inventoryId);
        IEnumerable<Inventory> GetInventories();

        bool CreateItem(Item item);
        bool DeleteItem(Item item);
        bool Save();
    }
}
