using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Domain.Model;
using Infrastructure.Database.EFImplementations;
using Infrastructure.Database.Interfaces;
using WebApp.Models;
using WebApp.Models.Product;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            IList<Product> products = _uow.Products.GetAll();
            var viewModel = _mapper.Map<IList<ProductViewModel>>(products);

            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateProductViewModel createProductViewModel)
        {
            // mapping from CreateProductViewModel into Product
            // save

            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(createProductViewModel);
                _uow.Products.Create(product);
                _uow.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = _uow.Products.Get((int)id);

            if (product == null)
                return HttpNotFound("Product not found!");

            var editProductViewModel = _mapper.Map<EditProductViewModel>(product);

            return View(editProductViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel editProductViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(editProductViewModel);
                product = _uow.Products.Edit(product);
                _uow.Save();

                return RedirectToAction("Index");

            }

            return View();
        }
        
        public ActionResult Buy(int? id)
        {
            if (id == null || id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = _uow.Products.Get((int)id);

            if (product == null)
                return HttpNotFound("Product not found!");

            var buyProductViewModel = _mapper.Map<BuyProductViewModel>(product);

            return View(buyProductViewModel);
        }

        // not pure CRUD (Create Read Update Delete)
        [HttpPost]
        public ActionResult Buy(BuyProductViewModel buyProductViewModel)
        {
            if (ModelState.IsValid)
            {
                _uow.BeginTransaction();
                try
                {
                    var totalPrice = buyProductViewModel.Price * buyProductViewModel.Quantity;

                    Order order = new Order {CustomerId = 1};
                    if (totalPrice != null) order.TotalPrice = (decimal) totalPrice;

                    var createdOrder = _uow.Orders.Create(order);
                    _uow.Save();
                    
                    OrderDetail detail = new OrderDetail();
                    detail.OrderId = createdOrder.Id + 150;
                    detail.ProductId = (int)buyProductViewModel.Id;
                    detail.Quantity = (int) buyProductViewModel.Quantity;

                    _uow.OrderDetails.Create(detail);
                    _uow.Save();

                    _uow.Commit();
                }
                catch (Exception e)
                {
                    _uow.Rollback();
                    ModelState.AddModelError(string.Empty, "");
                    return View(buyProductViewModel);
                }

                return RedirectToAction("Index");

            }

            return View(buyProductViewModel);
        }

        
    }
}
