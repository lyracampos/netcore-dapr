using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Catalog.Application.Interfaces
{
    public interface IProductRepository : IDisposable
    {
         Task AddAsync(Domain.Entities.Product product);
         Task UpdateAsync(Domain.Entities.Product product);
         Task<Domain.Entities.Product> Get(Guid id);
         Task<IEnumerable<Domain.Entities.Product>> List();
    }
}