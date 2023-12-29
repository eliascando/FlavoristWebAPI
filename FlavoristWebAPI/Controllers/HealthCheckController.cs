using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FlavoristWebAPI.Controllers
{
    [ApiController]
    [Route("api/health")]
    [AllowAnonymous]
    public class HealthCheckController : ControllerBase
    {
        private readonly HealthCheckService _healthCheckService;

        public HealthCheckController(HealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        [HttpGet]
        public async Task<ActionResult<Object>> Get()
        {
            var report = await _healthCheckService.CheckHealthAsync();
            var result = new
            {
                status = report.Status.ToString(),
                checks = report.Entries.Select(e => new
                {
                    name = e.Key,
                    status = e.Value.Status.ToString(),
                    exception = e.Value.Exception != null ? e.Value.Exception.Message : "none",
                    duration = e.Value.Duration.ToString()
                })
            };

            return report.Status == HealthStatus.Healthy ? Ok(result) : StatusCode(503, result);
        }
    }
}
