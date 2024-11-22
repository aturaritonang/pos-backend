using System.ComponentModel.DataAnnotations.Schema;

namespace XsisPos.Model
{
    [Table("Products")]
    public class Product : BaseSchema
    {
        public int Id { get; set; }
        public int CategoryId { get; set; } = default!;
        public string Initial { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool Active { get; set; }
    }
}
