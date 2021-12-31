using System.ComponentModel.DataAnnotations;

namespace Net6SampleBasic.API.Entities
{
    public class Inventory
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string LocationTag { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
