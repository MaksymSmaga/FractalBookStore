using FractalBookStore.DTO;
using System;

namespace FractalBookStore.DTOFactory
{
    public static class OrderItemDTOFactory
    {
        public static OrderItemDTO Create(OrderDTO order, int bookId, decimal price, int count)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            ThrowIfInvalidCount(count);

            return new OrderItemDTO
            {
                BookId = bookId,
                Price = price,
                Count = count,
                Order = order,
            };
        }
        internal static void ThrowIfInvalidCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be greater than zero.");
        }

    }
}
