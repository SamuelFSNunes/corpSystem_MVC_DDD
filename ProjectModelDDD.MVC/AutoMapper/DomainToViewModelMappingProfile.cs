using AutoMapper;
using ProjectModelDDD.Domain.Entities;
using ProjectModelDDD.MVC.ViewModels;

namespace ProjectModelDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
