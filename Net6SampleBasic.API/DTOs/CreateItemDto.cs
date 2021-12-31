namespace Net6SampleBasic.API.DTOs
{
    public class CreateItemDto
    {
        public Guid Id { get; set; }
        public Guid InventoryId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTimeOffset AccessionRecord { get; set; }
        public decimal Value { get; set; }
    }
}
