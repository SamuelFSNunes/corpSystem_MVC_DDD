using Ninject.Modules;
using ProjectModelDDD.Application.Interface;
using ProjectModelDDD.Application.Services;
using ProjectModelDDD.Domain.Interfaces.Repositories;
using ProjectModelDDD.Domain.Interfaces.Services;
using ProjectModelDDD.Domain.Services;
using ProjectModelDDD.Infra.Data.Repositories;
using AutoMapper;
using ProjectModelDDD.MVC.AutoMapper;

namespace ProjectModelDDD.MVC.Modules
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            // Registrar o AutoMapper
            var config = AutoMapperConfig.RegisterMappings();
            Bind<IMapper>().ToConstant(config).InSingletonScope();

            //Application
            Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            Bind<IClientAppService>().To<ClientAppService>();
            Bind<IProductAppService>().To<ProductAppService>();

            //Services
            Bind(typeof(IServiceBase<>)).To(typeof(IServiceBase<>));
            Bind<IClientService>().To<ClientService>();
            Bind<IProductService>().To<ProductService>();

            //Infra
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind<IClientRepository>().To<ClientRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
        }
    }
}