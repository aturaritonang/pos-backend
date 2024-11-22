﻿using System.ComponentModel.DataAnnotations.Schema;

namespace XsisPos.Model
{
    [Table("Variants")]
    public class Variant : BaseSchema
    {
        public int Id { get; set; }
        public int ProductId { get; set; } = default!;
        public string Initial { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Stock { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool Active { get; set; }
    }
}