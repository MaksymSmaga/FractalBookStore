using System;

namespace FractalBookStore.DTO
{
    public class OrderItemDTO
    {
        public int BookId { get; set; }

        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                ThrowIfInvalidCount(value);
                count = value;
            }
        }
        public decimal Price { get; set; }

        private static void ThrowIfInvalidCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be greater than zero!");
        }

    }
}
