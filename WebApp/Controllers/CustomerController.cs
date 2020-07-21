using AutoMapper;
using Domain.Model;
using Infrastructure.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Customer;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CustomerController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            IList<Customer> customers = _uow.Customers.GetAll();
            var viewModel = _mapper.Map<IList<CustomerViewModel>>(customers);

            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateCustomerViewModel createCustomerViewModel)
        {
            // mapping from CreateCustomerViewModel into Customer
            // save

            if (ModelState.IsValid)
            {
                var Customer = _mapper.Map<Customer>(createCustomerViewModel);
                _uow.Customers.Create(Customer);
                _uow.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var Customer = _uow.Customers.Get((int)id);

            if (Customer == null)
                return HttpNotFound("Customer not found!");

            var editCustomerViewModel = _mapper.Map<EditCustomerViewModel>(Customer);

            return View(editCustomerViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditCustomerViewModel editCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                var Customer = _mapper.Map<Customer>(editCustomerViewModel);
                Customer = _uow.Customers.Edit(Customer);
                _uow.Save();

                return RedirectToAction("Index");

            }

            return View();
        }



        
    }
}