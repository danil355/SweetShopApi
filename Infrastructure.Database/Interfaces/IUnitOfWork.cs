using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Infrastructure.Database.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; set; }
        IRepository<Order> Orders { get; set; }
        IRepository<OrderDetail> OrderDetails { get; set; }
        IRepository<Customer> Customers { get; set; }

        void Save();

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
