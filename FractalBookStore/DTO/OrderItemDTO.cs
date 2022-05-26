using System;

namespace FractalBookStore.DTO
{
    public class OrderItemDTO
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public OrderDTO Order { get; set; }
    }
}
