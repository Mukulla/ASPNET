using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly ILogger<AgentsController> _logger;

        public AgentsController()
        {
        }

        public AgentsController(ILogger<AgentsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsController");
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] IAgentInfo agentInfo)
        {
            _logger.LogInformation(agentInfo.ToString());
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId )
        {
            _logger.LogInformation(agentId.ToString());
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation(agentId.ToString());
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation(fromTime.ToString());
            return Ok();
        }
    }
}
