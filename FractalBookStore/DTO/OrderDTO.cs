using System.Collections.Generic;
using System.Linq;

namespace FractalBookStore.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        private readonly List<OrderItem> _items;

        public IReadOnlyCollection<OrderItem> Items
        {
            get { return _items; }
        }

        public int TotalCount => _items.Sum(item => item.Count);

        public decimal TotalPrice => _items.Sum(item => item.Price * item.Count);

    }
}
