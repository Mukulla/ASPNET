using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MetricsAgent.Models;
using MetricsAgent.DAL;
using MetricsAgent.Requests;
using MetricsAgent.Responses;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase
    {
        private INetworkMetricsRepository repository;
        public NetworkMetricsController(INetworkMetricsRepository repository)
        {
            this.repository = repository;
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] NetworkMetricCreateRequest request)
        {
            repository.Create(new NetworkMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();
            var response = new AllNetworkMetricsResponse()
            {
                Metrics = new List<NetworkMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new NetworkMetricDto
                {
                    Time = metric.Time,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }



        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetNetworkBandwidth([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            return Ok();
        }
    }
}
