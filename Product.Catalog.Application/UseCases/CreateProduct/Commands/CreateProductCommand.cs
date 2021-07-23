using System;
using MediatR;

namespace Product.Catalog.Application.UseCases.CreateProduct.Commands
{
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }

        public Domain.Entities.Product MapToEntity() 
            => new Domain.Entities.Product(Guid.NewGuid(), Name, Brand, Category);
    }
}