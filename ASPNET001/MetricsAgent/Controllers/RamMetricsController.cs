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
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private IRamMetricsRepository repository;
        public RamMetricsController(IRamMetricsRepository repository)
        {
            this.repository = repository;
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] RamMetricCreateRequest request)
        {
            repository.Create(new RamMetric
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
            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new RamMetricDto
                {
                    Time = metric.Time,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }



        [HttpGet("available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetAvailableSpace([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            return Ok();
        }
    }
}
