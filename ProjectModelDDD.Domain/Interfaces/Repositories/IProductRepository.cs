
using ProjectModelDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjectModelDDD.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> FindByName(string name);
    }
}
