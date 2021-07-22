using System;
using System.Threading;
using System.Threading.Tasks;
using Dapr.Client;
using MediatR;
using Product.Catalog.Application.UseCases.CreateProduct.Events;

namespace Product.Catalog.Application.UseCases.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly DaprClient _daprClient;

        public CreateProductHandler(DaprClient daprClient) => _daprClient = daprClient;
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _daprClient.SaveStateAsync("mongo", request.Id.ToString(), request);

            var topicName = nameof(ProductCreatedEvent);
            await _daprClient.PublishEventAsync<ProductCreatedEvent>("pubsub", topicName, new ProductCreatedEvent(request.Id, request.Name));

            Console.WriteLine($"cadastrando produto {request.Name}");
            return new CreateProductResult(request.Id);
        }
    }
}