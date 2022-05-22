﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FractalBookStore
{
    public class Order
    {
        public int Id { get; set; }

        private readonly List<OrderItem> _items;

        public IReadOnlyCollection<OrderItem> Items
        {
            get { return _items; }
        }

        public int TotalCount => _items.Sum(item => item.Count);

        public decimal TotalPrice => _items.Sum(item => item.Price * item.Count);

        public Order(int id, IEnumerable<OrderItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            Id = id;

            _items = new List<OrderItem>(items);
        }

        public OrderItem GetItem(int bookId)
        {
            int index = _items.FindIndex(item => item.BookId == bookId);
            if (index == -1)
                ThrowBookException("Book is not found.",bookId);
            return _items[index];
        }
        public void AddOrUpdateItem(Book book, int count)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            int index = _items.FindIndex(x => x.BookId == book.Id);

            if (index == -1)
                _items.Add(new OrderItem(book.Id, count, book.Price));
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

        
    }
}