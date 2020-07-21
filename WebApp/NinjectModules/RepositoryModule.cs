using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Model;
using Infrastructure.Database.EFImplementations;
using Infrastructure.Database.Interfaces;
using Ninject.Modules;

namespace WebApp.NinjectModules
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Product>>().To<ProductsRepository>();
            Bind<IRepository<Order>>().To<OrdersRepository>();
            Bind<IRepository<OrderDetail>>().To<OrderDetailsRepository>();
        }
    }
}