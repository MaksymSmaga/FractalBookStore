using FractalBookStore.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractalBookStore
{
    public class OrderItemCollection : IReadOnlyCollection<OrderItem>
    {
        private readonly OrderDTO orderDto;
        private readonly List<OrderItem> items;

        public OrderItemCollection(OrderDTO orderDto)
        {
            this.orderDto = orderDto ?? throw new ArgumentNullException(nameof(orderDto));

            items = orderDto.Items
                            .Select(OrderItem.Mapper.Map)
                            .ToList();
        }

        public int Count => items.Count;

        public IEnumerator<OrderItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (items as IEnumerable).GetEnumerator();
        }

        public OrderItem Get(int bookId)
        {
            if (TryGet(bookId, out OrderItem orderItem))
                return orderItem;

            throw new InvalidOperationException("Book not found.");
        }

        public bool TryGet(int bookId, out OrderItem orderItem)
        {
            var index = items.FindIndex(item => item.BookId == bookId);
            if (index == -1)
            {
                orderItem = null;
                return false;
            }

            orderItem = items[index];
            return true;
        }

        public OrderItem Add(int bookId, decimal price, int count)
        {
            if (TryGet(bookId, out _))
                throw new InvalidOperationException("Book already exists.");

            var orderItemDto = OrderItem.DTOFactory.Create(orderDto, bookId, price, count);
            orderDto.Items.Add(orderItemDto);

            OrderItem orderItem = OrderItem.Mapper.Map(orderItemDto);
            items.Add(orderItem);

            return orderItem;
        }

        public void Remove(int bookId)
        {
            var index = items.FindIndex(item => item.BookId == bookId);
            if (index == -1)
                throw new InvalidOperationException("Can't find book to remove from order.");

            orderDto.Items.RemoveAt(index);
            items.RemoveAt(index);
        }
    }
}
