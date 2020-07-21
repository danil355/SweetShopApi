using Domain.Model;
using Infrastructure.Database.EFImplementations;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class CustomerApiController : ApiController
    {
        private readonly IUnitOfWork _uow;

        public CustomerApiController()
        {
            var db = new SweetShopDataContext();
            var orders = new OrdersRepository(db);
            var orderDetails = new OrderDetailsRepository(db);
            var customers = new CustomersRepository(db);
            var products = new ProductsRepository(db);
            var uow = new EFUnitOfWork(orders, orderDetails, customers, products, db);

            _uow = uow;
        }

        public IEnumerable<Customer> Get()
        {
            return _uow.Customers.GetAll();
        }

        public Customer Get(int id)
        {
            return _uow.Customers.Get(id);
        }

        public Customer Post([FromBody]Customer Customer)
        {
            var savedCustomer = _uow.Customers.Create(Customer);
            _uow.Save();
            return savedCustomer;
        }

        public void Put(int id, [FromBody]string value)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
