using System;

namespace Product.Catalog.Api.Models
{
    public class ProductModel
    {
        public ProductModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}