﻿using FractalBookStore.DTO;
using System;

namespace FractalBookStore
{
    public class OrderItem
    {
        private readonly OrderItemDTO dto;

        public int BookId => dto.BookId;

        public int Count
        {
            get { return dto.Count; }
            set
            {
                ThrowIfInvalidCount(value);

                dto.Count = value;
            }
        }

        public decimal Price
        {
            get => dto.Price;
            set => dto.Price = value;
        }

        internal OrderItem(OrderItemDTO dto)
        {
            this.dto = dto;
        }

        private static void ThrowIfInvalidCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be greater than zero.");
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
                    Order = order,
                };
            }
        }

        public static class Mapper
        {
            public static OrderItem Map(OrderItemDTO dto) => new OrderItem(dto);

            public static OrderItemDTO Map(OrderItem domain) => domain.dto;
        }
    }
}
