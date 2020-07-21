using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Database.EFImplementations;
using Infrastructure.Database.Interfaces;

namespace WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _uow;

        public OrdersController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ActionResult Index()
        {
            var model = _uow.Orders.GetAll();
            return View(model);
        }
    }
}