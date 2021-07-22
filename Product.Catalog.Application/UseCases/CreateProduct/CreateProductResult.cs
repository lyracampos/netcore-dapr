using System;

namespace Product.Catalog.Application.UseCases.CreateProduct
{
    public class CreateProductResult
    {
        public CreateProductResult(Guid id) => Id = id;

        public Guid Id { get; private set; }
    }
}