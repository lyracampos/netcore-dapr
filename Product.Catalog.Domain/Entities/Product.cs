using System;
namespace Product.Catalog.Domain.Entities
{
    public class Product
    {
        public Product(Guid id, string name, string brand, string category)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Name = name;
            Brand = brand;
            Category = category;
        }
        
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public string Category { get; private set; }
    }
}