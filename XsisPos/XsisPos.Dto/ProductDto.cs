﻿namespace XsisPos.Dto
{
    public class ProductDto : BaseDto
    {
        public int Id { get; set; }
        public CategoryDto Category { get; set; } = default!;
        public string Initial { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool Active { get; set; }
    }
}
