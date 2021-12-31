namespace Net6SampleBasic.API.DTOs
{
    public class GetItemsDto
    {
        public Guid Id { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public DateTimeOffset AccessionRecord { get; set; }
    }
}
