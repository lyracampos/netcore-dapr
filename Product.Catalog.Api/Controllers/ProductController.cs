using System;
using System.Threading.Tasks;
using Dapr.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.Catalog.Api.Models;
using Product.Catalog.Application.UseCases.CreateProduct;

namespace Product.Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IMediator mediator;
        private readonly DaprClient daprClient;

        public ProductController(ILogger<ProductController> logger, IMediator mediator, DaprClient daprClient)
        {
            this.logger = logger;
            this.mediator = mediator;
            this.daprClient = daprClient;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await daprClient.GetStateAsync<CreateProductCommand>("mongo", id.ToString());
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            logger.LogTrace($"Starting: {nameof(ProductController)} - Post - {DateTime.UtcNow}");

            var result = await mediator.Send(command);

            return Created("", result);
        }
    }
}