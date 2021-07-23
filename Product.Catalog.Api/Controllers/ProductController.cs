using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.Catalog.Application.Interfaces;
using Product.Catalog.Application.UseCases.CreateProduct.Commands;

namespace Product.Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger, IMediator mediator, IProductRepository productRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _productRepository = productRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productRepository.Get(id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            _logger.LogTrace($"Starting: {nameof(ProductController)} - Post - {DateTime.UtcNow}");

            var product = await _mediator.Send(command);

            return Created($"api/product/{product.Id}", product);
        }
    }
}