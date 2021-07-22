using System;

namespace Product.Catalog.Application.UseCases.CreateProduct.Events
{
    public class ProductCreatedEvent
    {
        public ProductCreatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}