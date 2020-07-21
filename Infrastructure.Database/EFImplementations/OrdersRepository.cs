using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.Database.EFImplementations
{
    public class OrdersRepository : IRepository<Order>
    {
        private readonly SweetShopDataContext _context;

        public OrdersRepository(SweetShopDataContext context)
        {
            _context = context;
        }

        public Order Get(int id)
        {
            return _context.Orders.Find(id);
        }

        public IList<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order Create(Order entity)
        {
            return _context.Orders.Add(entity);
        }

        public Order Edit(Order entity)
        {
            var order = _context.Orders.Find(entity.Id);
            if (order != null)
            {
                order.TotalPrice = entity.TotalPrice;
            }
            return order;
        }
    }
}