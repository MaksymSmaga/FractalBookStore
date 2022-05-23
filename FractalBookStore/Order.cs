using FractalBookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FractalBookStore
{   // MementoPattern.
    // To hide Class Object,
    // but to know all properities save it into DB.

    // DTOPattern - Data Transfer Object.
    // - simple model of Class Object.
    public class Order
    {
        private readonly OrderDTO _dto;

        private readonly List<OrderItem> _items;
        public int Id => _dto.Id;

        public IReadOnlyCollection<OrderItem> Items
        {
            get { return _items; }
        }

        public int TotalCount => _items.Sum(item => item.Count);

        public decimal TotalPrice => _items.Sum(item => item.Price * item.Count);

        public Order(OrderDTO dto)
        {
            _dto = dto;
        }

        public OrderItem GetItem(int bookId)
        {
            int index = _items.FindIndex(item => item.BookId == bookId);
            if (index == -1)
                ThrowBookException("Book is not found.", bookId);
            return _items[index];
        }
        public void AddOrUpdateItem(Book book, int count)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            int index = _items.FindIndex(x => x.BookId == book.Id);

            if (index == -1)
                _items.Add(new OrderItem(new OrderItemDTO()));
            else
                _items[index].Count += count;
        }

        public void RemoveItem(int bookId)
        {
            int index = _items.FindIndex(item => item.BookId == bookId);

            if (index == -1)
                ThrowBookException("Order doesn`t have a spec book.", bookId);

            _items.RemoveAt(index);
        }

        private void ThrowBookException(string message, int bookId)
        {
            var exception = new InvalidOperationException(message);
            exception.Data["BookId"] = bookId;

            throw exception;
        }


        public static class DTOFactory
        {
            public static OrderDTO Create() => new OrderDTO();
        }
        public static class Mapper
        {
            public static Order Map(OrderDTO dto) => new Order(dto);
            public static OrderDTO Map(Order domain) => domain._dto;
        }
    }
}