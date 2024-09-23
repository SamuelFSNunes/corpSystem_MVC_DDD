using Ninject.Modules;
using Ninject;
using ProjectModelDDD.MVC.AutoMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Web.Common.WebHost;
using ProjectModelDDD.Application.Services;
using ProjectModelDDD.MVC.Modules;

namespace ProjectModelDDD.MVC
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings(); //Config AutoMapper
        }
        protected override IKernel CreateKernel()
        {
            var modules = new NinjectModule[] { new  ApplicationModule() };
            return new StandardKernel(modules);
        }
    }
}
