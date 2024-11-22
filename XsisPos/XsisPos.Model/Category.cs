﻿using System.ComponentModel.DataAnnotations.Schema;

namespace XsisPos.Model
{
    [Table("Categories")]
    public class Category : BaseSchema
    {
        public int Id { get; set; }
        public string Initial { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool Active { get; set; }
    }
}