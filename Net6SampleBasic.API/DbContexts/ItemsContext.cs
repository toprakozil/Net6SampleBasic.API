using Microsoft.EntityFrameworkCore;
using Net6SampleBasic.API.Entities;

namespace Net6SampleBasic.API.DbContexts
{
    public class ItemsContext : DbContext
    {
        public ItemsContext(DbContextOptions<ItemsContext> options) : base(options) { }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeding with dummy data
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    Id = Guid.Parse("5ab77607-42e8-4a25-b47a-db8983a652e8"),
                    Name = "locationA",
                    LocationTag = "34-A",
                },
                new Inventory
                {
                    Id = Guid.Parse("ca2abc8e-1bdc-4887-8f97-215fe050f22f"),
                    Name = "locationB",
                    LocationTag = "18-H",
                },
                new Inventory
                {
                    Id = Guid.Parse("d097a599-4619-4473-ae86-d353c3069597"),
                    Name = "locationB",
                    LocationTag = "1-B",
                });

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = Guid.Parse("6978cc16-5f5a-4020-bb79-4cc4dcc36b72"),
                    InventoryId = Guid.Parse("5ab77607-42e8-4a25-b47a-db8983a652e8"),
                    Category = "Mechanic",
                    Description = "Fancy Machine",
                    AccessionRecord = DateTimeOffset.Now.AddYears(-2),
                    Value = 10
                },
                new Item
                {
                    Id = Guid.Parse("4fa3169e-0779-45cc-9139-dc4ee92cbd5f"),
                    InventoryId = Guid.Parse("5ab77607-42e8-4a25-b47a-db8983a652e8"),
                    Category = "Mechanic",
                    Description = "Ordinary Machine",
                    AccessionRecord = DateTimeOffset.Now.AddYears(-5),
                    Value = 10
                },

                new Item
                {
                    Id = Guid.Parse("3675f42d-9bbb-488f-bd36-c7e6411c87d5"),
                    InventoryId = Guid.Parse("ca2abc8e-1bdc-4887-8f97-215fe050f22f"),
                    Category = "Electronic",
                    Description = "ComputerA",
                    AccessionRecord = DateTimeOffset.Now.AddYears(-6),
                    Value = 10
                }, 
                new Item
                {
                    Id = Guid.Parse("ea3a236e-fda4-4e3f-ae1d-3bd3a535a177"),
                    InventoryId = Guid.Parse("ca2abc8e-1bdc-4887-8f97-215fe050f22f"),
                    Category = "Electronic",
                    Description = "ComputerB",
                    AccessionRecord = DateTimeOffset.Now.AddYears(-1),
                    Value = 10
                }, 

                new Item
                {
                    Id = Guid.Parse("270ed53a-053b-442a-9302-716959d0a51a"),
                    InventoryId = Guid.Parse("d097a599-4619-4473-ae86-d353c3069597"),
                    Category = "Office Supplies",
                    Description = "Desk",
                    AccessionRecord = DateTimeOffset.Now.AddYears(-5),
                    Value = 10
                }, 
                new Item
                {
                    Id = Guid.Parse("b1ee8f72-0cc0-4cd9-bcc6-11183cf24da8"),
                    InventoryId = Guid.Parse("d097a599-4619-4473-ae86-d353c3069597"),
                    Category = "Office Supplies",
                    Description = "Chair",
                    AccessionRecord = DateTimeOffset.Now.AddYears(-5),
                    Value = 10
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}
