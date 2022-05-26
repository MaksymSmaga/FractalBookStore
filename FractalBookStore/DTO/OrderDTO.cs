using System.Collections.Generic;
using System.Linq;

namespace FractalBookStore.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        private readonly List<OrderItem> _items = new List<OrderItem>();


        public IList<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
        public int TotalCount => _items.Sum(item => item.Count);

        public decimal TotalPrice => _items.Sum(item => item.Price * item.Count);

    }
}
