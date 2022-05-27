﻿using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FractalBookStore.Data.EF
{
    class OrderRepository : IOrderRepository
    {
        private readonly DbContextFactory _dBContextFactory;

        public OrderRepository(DbContextFactory dBContextFactory)
        {
            _dBContextFactory = dBContextFactory;
        }

        public Order Create()
        {
            var dbContext = _dBContextFactory.Create(typeof(BookRepository));

            var dto = Order.DtoFactory.Create();
            dbContext.Orders.Add(dto);
            dbContext.SaveChanges();

            return Order.Mapper.Map(dto);
        }

        public Order GetById(int id)
        {
            var dbContext = _dBContextFactory.Create(typeof(BookRepository));

            var dto = dbContext.Orders
                               .Include(order => order.Items)
                               .Single(order => order.Id == id);

            return Order.Mapper.Map(dto);
        }

        public void Update(Order order)
        {
            var dbContext = _dBContextFactory.Create(typeof(BookRepository));
            dbContext.SaveChanges();
        }
    }
}
