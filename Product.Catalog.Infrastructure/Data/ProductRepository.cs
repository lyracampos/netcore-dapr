using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapr.Client;
using Product.Catalog.Application.Interfaces;

namespace Product.Catalog.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DaprClient _sideCar;

        private readonly string storeName = "mongodb";

        public ProductRepository(DaprClient sideCar) => 
            _sideCar = sideCar;

        public async Task AddAsync(Domain.Entities.Product product) => 
            await _sideCar.SaveStateAsync(storeName, product.Id.ToString(), product);

        public async Task<Domain.Entities.Product> Get(Guid id) =>
            await _sideCar.GetStateAsync<Domain.Entities.Product>(storeName, id.ToString());

        public async Task<Domain.Entities.Product> Get(string document) =>
            await _sideCar.GetStateAsync <Domain.Entities.Product>(storeName, document);

        public async Task UpdateAsync(Domain.Entities.Product product) =>
            await _sideCar.SaveStateAsync(storeName, product.Id.ToString(), product);

        public Task<IEnumerable<Domain.Entities.Product>> List()
        {
            throw new NotImplementedException();
        }

        private bool disposedValue = false;

        public void Dispose() => Dispose(true);

        public void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }
    }
}