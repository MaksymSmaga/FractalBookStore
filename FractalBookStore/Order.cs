using FractalBookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FractalBookStore
{
    public class Order
    {
        internal readonly OrderDTO dto;

        public int Id => dto.Id;
        public int TotalCount => Items.Sum(item => item.Count);
        public decimal TotalPrice => Items.Sum(item => item.Price * item.Count);
        public OrderItemCollection Items { get;}

        public Order(OrderDTO dto)
        {
            this.dto = dto;
            Items = new OrderItemCollection(dto);
        }

        public void AddOrUpdateItem(Book book, int count)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var index = Items.ToList().FindIndex(x => x.BookId == book.Id);

            if (index == -1)
            {
                Items.Add(book.Id, book.Price, count);
            }
            else
            {
                Items.ToArray()[index].Count += count;
            }
        }

        public void RemoveItem(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var item = Items.SingleOrDefault(x => x.BookId == book.Id);

            if (item != null)
                Items.Remove(item.BookId);
        }

        public OrderItem GetItem(int bookId) => Items.Get(bookId);
    }
}
