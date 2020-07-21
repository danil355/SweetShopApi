using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using WebApp.NinjectModules;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var modules = new INinjectModule[]
            {
                new RepositoryModule(), 
                new MapperModule(), 
                new UnitOfWorkModule(),
                new DataContextModule()
            };

            var kernel = new StandardKernel(modules); // регистрация в ядре (kernel) всех модулей
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel)); // добавление решения для зависимостей в asp.net mvc
        }
    }
}
