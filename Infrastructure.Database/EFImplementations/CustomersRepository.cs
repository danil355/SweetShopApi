using Domain.Model;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.EFImplementations
{
    public class CustomersRepository : IRepository<Customer>
    {
        private readonly SweetShopDataContext _context;

        public CustomersRepository(SweetShopDataContext context)
        {
            _context = context;
        }

        public Customer Get(int id)
        {
            return _context.Customers.Find(id);
        }

        public IList<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer Create(Customer entity)
        {
            var customer = _context.Customers.Add(entity);
            return customer;
        }

        public Customer Edit(Customer entity)
        {
            var customer = _context.Customers.Find(entity.Id);
            if (customer != null)
            {
                customer.Name = entity.Name;
                customer.Phone = entity.Phone;
            }
            return customer;
        }
    }
}
