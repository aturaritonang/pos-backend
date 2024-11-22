namespace XsisPos.Dto
{
    public class VariantDto
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; } = default!;
        public string Initial { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Stock { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool Active { get; set; }
    }
}
