namespace InBoxOutBoxExample.Domain.Write.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }

    }
}
