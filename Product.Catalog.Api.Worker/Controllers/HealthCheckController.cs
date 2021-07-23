using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Product.Catalog.Api.Worker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
         private readonly ILogger _logger;

         public HealthCheckController(ILogger<HealthCheckController> logger)
         {
             _logger = logger;
         }

         [HttpGet]
         public string HealthCheck()
         {
             _logger.LogTrace($"starting healthcheck: {nameof(HealthCheckController)} : {DateTime.UtcNow}");
             return "api is working...";
         }
    }
}