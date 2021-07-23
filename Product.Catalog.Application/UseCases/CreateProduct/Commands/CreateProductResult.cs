using System;

namespace Product.Catalog.Application.UseCases.CreateProduct.Commands
{
    public class CreateProductResult
    {
        public CreateProductResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}