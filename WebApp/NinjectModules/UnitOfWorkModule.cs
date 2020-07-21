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
    public class UnitOfWorkModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}