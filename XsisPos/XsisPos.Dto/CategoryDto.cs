﻿namespace XsisPos.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Initial { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool Active { get; set; }
    }
}
