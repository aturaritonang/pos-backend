﻿namespace XsisPos.Dto
{
    public class OrderHeaderDto
    {
        public int Id { get; set; }
        public string Reference { get; set; } = default!;
        public decimal Amount { get; set; }
        public List<OrderDetailDto> Details { get; set; } = default!;
        public DateTime DateTime { get; set; }
    }

    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public int VariantId { get; set; }
        public OrderHeaderDto Header { get; set; } = default!;
        public VariantDto Variant { get; set; } = default!;
    }
}