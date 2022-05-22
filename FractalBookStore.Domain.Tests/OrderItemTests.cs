using System;
using Xunit;

namespace FractalBookStore.Domain.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = -1;
                new OrderItem(1, count, 0m);
            });
        }

        [Fact]
        public void OrderItem_WithPozitiveCount_SetsCount()
        {
            var orderItem = new OrderItem(1, 2, 3m);

            Assert.Equal(1, orderItem.BookId);
            Assert.Equal(2, orderItem.Count);
            Assert.Equal(3, orderItem.Price);
        }

        [Fact]
        public void Count_WithNegativeValute_ThrowsArgumentOfRangeException()
        {
            var orderItem = new OrderItem(1, 5, 0m);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderItem.Count = -1;
            });

        }

        [Fact]
        public void Count_WithZeroValute_ThrowsArgumentOfRangeException()
        {
            var orderItem = new OrderItem(1, 5, 0m);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderItem.Count = 0;
            });
        }
        [Fact]
        public void Count_WithPositiveValute_SetValue()
        {
            var orderItem = new OrderItem(1, 5, 0m);

            orderItem.Count = 10;

            Assert.Equal(10, orderItem.Count);
        }
    }
}

