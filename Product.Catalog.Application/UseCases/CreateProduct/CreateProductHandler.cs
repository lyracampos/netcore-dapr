using System;
using System.Threading;
using System.Threading.Tasks;
using Dapr.Client;
using MediatR;

namespace Product.Catalog.Application.UseCases.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly DaprClient _daprClient;

        public CreateProductHandler(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var topicName = nameof(CreateProductCommand);
            await _daprClient.PublishEventAsync<CreateProductCommand>("pubsub", topicName, request);

            Console.WriteLine($"cadastrando produto {request.Name}");
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}