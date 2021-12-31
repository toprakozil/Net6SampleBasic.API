using Net6SampleBasic.API.DbContexts;
using Net6SampleBasic.API.Entities;

namespace Net6SampleBasic.API.Services
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemsContext _context;
        public ItemRepository(ItemsContext context)
        {
            _context = context;
        }

        public IEnumerable<Inventory> GetInventories()
        {
            return _context.Inventories.ToList();
        }

        public Inventory GetInventory(Guid inventoryId)
        {
            return _context.Inventories.Where(x => x.Id == inventoryId).FirstOrDefault();
        }



        public Item GetItem(Guid itemId)
        {
            return _context.Items.Where(x => x.Id == itemId).FirstOrDefault();
        }

        public IEnumerable<Item> GetItems(Guid inventoryId)
        {
           return _context.Items.Where(x => x.InventoryId == inventoryId).ToList();
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items.ToList();
        }



        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool DeleteItem(Item item)
        {
            _context.Remove(item);
            return Save();
        }
        public bool CreateItem(Item item)
        {
            _context.AddAsync(item);
            return Save();
        }
    }
}
