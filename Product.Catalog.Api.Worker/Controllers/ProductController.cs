using System.Threading.Tasks;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.Catalog.Application.UseCases.CreateProduct.Events;

namespace Product.Catalog.Api.Worker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [Topic("rabbitmq", "ProductCreatedEvent")]
        [HttpPost]
        [Route("ProductCreatedEvent")]
        public async Task<IActionResult> ProcessProduct([FromBody]ProductCreatedEvent product)
        {
            //Process order placeholder

            _logger.LogInformation($"Order with id {product.Name} processed!");
            return Ok();
        }
    }
}