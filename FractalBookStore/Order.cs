using FractalBookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FractalBookStore
{
    public class Order
    {
        private readonly OrderDTO dto;

        public int Id => dto.Id;

        public OrderItemCollection Items { get; }

        public int TotalCount => Items.Sum(item => item.Count);
        public decimal TotalPrice => Items.Sum(item => item.Price * item.Count);
        public Order(OrderDTO dto)
        {
            this.dto = dto;
            Items = new OrderItemCollection(dto);
        }


        public static class DtoFactory
        {
            public static OrderDTO Create() => new OrderDTO();
        }
        public static class Mapper
        {
            public static Order Map(OrderDTO dto) => new Order(dto);

            public static OrderDTO Map(Order domain) => domain.dto;
        }

        public void AddOrUpdateItem(Book book, int count)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var item = Items.SingleOrDefault(x => x.BookId == book.Id);

            if (item == null)
            {
                Items.Add(book.Id, book.Price, count);
            }
            else
            {
                Items.Remove(item.BookId);
                Items.Add(book.Id, book.Price, count);
            }
        }

        public void RemoveItem(Book book)
        {
         if (book == null)
             throw new ArgumentNullException(nameof(book));

             var item = Items.SingleOrDefault(x => x.BookId == book.Id);

        if (item == null)
           Items.Remove(item.BookId);
        }

        public OrderItem GetItem(int bookId)  => Items.Get(bookId); 
    }
}
