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
    public class OrdersApiController : ApiController
    {
        private readonly IUnitOfWork _uow;

        public OrdersApiController()
        {
            var db = new SweetShopDataContext();
            var orders = new OrdersRepository(db);
            var orderDetails = new OrderDetailsRepository(db);
            var customers = new CustomersRepository(db);
            var products = new ProductsRepository(db);
            var uow = new EFUnitOfWork(orders, orderDetails, customers, products, db);

            _uow = uow;
        }

        public IEnumerable<Order> Get()
        {
            return _uow.Orders.GetAll();
        }

        public Order Get(int id)
        {
            return _uow.Orders.Get(id);
        }
        
        public Order Post([FromBody]Order order)
        {
            var savedOrder = _uow.Orders.Create(order);
            _uow.Save();
            return savedOrder;
        }

        public void Put(int id, [FromBody]string value)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
