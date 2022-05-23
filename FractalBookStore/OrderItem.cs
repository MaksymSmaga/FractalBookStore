

using FractalBookStore.DTO;
using System;
namespace FractalBookStore
{
    public class OrderItem
    {
        private readonly OrderItemDTO _dto;
        public int BookId => _dto.BookId;

        private int count;
        public int Count
        {
            get => _dto.Count;
           
            set
            {
                ThrowIfInvalidCount(value);
                _dto.Count = value;
            }
        }
        public decimal Price 
        {
            get=> _dto.Price;
            set => _dto.Price = value;
        }

        public OrderItem(OrderItemDTO dto)
        {
            ThrowIfInvalidCount(count);

            _dto = dto;
        }

        private static void ThrowIfInvalidCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be greater than zero!");
        }

        public static class DTOFactory
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
                    //Order = order, 
                };
            }
        }
        public static class Mapper
        {
            public static OrderItem Map(OrderItemDTO dto) => new OrderItem(dto);
            public static OrderItemDTO Map(OrderItem domain) => domain._dto;
        }
    }
}
