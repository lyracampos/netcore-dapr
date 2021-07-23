using System;
using System.Threading;
using System.Threading.Tasks;
using Dapr.Client;
using MediatR;
using Product.Catalog.Application.Interfaces;
using Product.Catalog.Application.UseCases.CreateProduct.Events;

namespace Product.Catalog.Application.UseCases.CreateProduct.Commands
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly DaprClient _daprClient;
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository, DaprClient daprClient)
        {
            _productRepository = productRepository;
            _daprClient = daprClient;
        } 
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.MapToEntity();
            await _productRepository.AddAsync(product);

            var topicName = nameof(ProductCreatedEvent);
            await _daprClient.PublishEventAsync<ProductCreatedEvent>("rabbitmq", topicName, new ProductCreatedEvent(product.Id, product.Name, product.Brand, product.Category));

            Console.WriteLine($"cadastrando produto {request.Name}");
            return new CreateProductResult(product.Id, product.Name);
        }
    }
}