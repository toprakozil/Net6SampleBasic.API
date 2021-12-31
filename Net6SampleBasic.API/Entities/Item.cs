using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net6SampleBasic.API.Entities
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public DateTimeOffset AccessionRecord { get; set; }

        [MaxLength(50)]
        public decimal Value { get; set; }

        [ForeignKey("InventoryId")]
        public Inventory Inventory { get; set; }

        public Guid InventoryId { get; set; }
    }
}
