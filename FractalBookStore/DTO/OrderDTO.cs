using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FractalBookStore.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        private readonly List<OrderItem> _items = new List<OrderItem>();

        public IList<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
        public int TotalCount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice{get; set;}
    }
}
