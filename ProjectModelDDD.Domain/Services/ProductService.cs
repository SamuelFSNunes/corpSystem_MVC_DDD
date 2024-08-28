using ProjectModelDDD.Domain.Entities;
using ProjectModelDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModelDDD.Domain.Services
{
    public class ProductService : ServiceBase<Product>, IProductRepository
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) 
            : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> FindByName(string name)
        {
            return _productRepository.FindByName(name);
        }
    }
}
