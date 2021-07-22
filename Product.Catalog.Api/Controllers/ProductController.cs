using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.Catalog.Application.UseCases.CreateProduct;

namespace Product.Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
         private readonly ILogger logger;
        private readonly IMediator mediator;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
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