using System;

namespace Product.Catalog.Application.UseCases.CreateProduct.Events
{
    public class ProductCreatedEvent
    {
        public ProductCreatedEvent(Guid id, string name, string brand, string category)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Category = category;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Brand { get; }
        public string Category { get; }
    }
}