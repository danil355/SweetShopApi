using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Domain.Model;
using Infrastructure.Database.EFImplementations;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFramework;

namespace WebApp.Controllers
{
    public class ProductsApiController : ApiController
    {
        private readonly IUnitOfWork _uow;

        public ProductsApiController()
        {
            var db = new SweetShopDataContext();
            var orders = new OrdersRepository(db);
            var orderDetails = new OrderDetailsRepository(db);
            var products = new ProductsRepository(db);
            var uow = new EFUnitOfWork(products, orders, orderDetails, db);

            _uow = uow;
        }

        public IEnumerable<Product> Get()
        {
            return _uow.Products.GetAll();
        }

        public Product Get(int id)
        {
            return _uow.Products.Get(id);
        }

        public Product Post([FromBody]Product product)
        {
            var savedProduct = _uow.Products.Create(product);
            _uow.Save();
            return savedProduct;
        }

        public void Put(int id, [FromBody]string value)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
