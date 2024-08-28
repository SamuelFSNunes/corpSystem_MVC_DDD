using ProjectModelDDD.Application.Interface;
using ProjectModelDDD.Domain.Entities;
using ProjectModelDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModelDDD.Application.Services
{
    public class ProductAppService : AppServiceBase<Product>, IProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IProductService productService) 
            : base(productService)
        {
            _productService = productService;
        }

        public IEnumerable<Product> GetByName(string name)
        {
            return _productService.GetByName(name);
        }
    }
}
