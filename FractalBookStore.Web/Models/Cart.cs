using System.Collections.Generic;

namespace FractalBookStore.Web.Models
{
    public class Cart
    {
        public IDictionary<int, int> Items { get; set; } = new Dictionary<int, int>();
        public decimal Amount { get; set; }
    }
}
