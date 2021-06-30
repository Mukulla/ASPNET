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
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {

        private IHddMetricsRepository repository;
        public HddMetricsController(IHddMetricsRepository repository)
        {
            this.repository = repository;
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            repository.Create(new HddMetric
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
            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new HddMetricDto
                {
                    Time = metric.Time,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }


        [HttpGet("left/from/{fromTime}/to/{toTime}")]
        public IActionResult GetLeftSpace([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            return Ok();
        }
    }
}
