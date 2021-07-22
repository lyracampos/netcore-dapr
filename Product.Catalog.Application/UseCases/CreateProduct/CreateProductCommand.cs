using System;
using MediatR;

namespace Product.Catalog.Application.UseCases.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        public CreateProductCommand() => Id = Guid.NewGuid();
        
        public Guid Id { get; private set; }
        public string Name { get; set; }
    }
}