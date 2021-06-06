using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class First : ControllerBase
    {
        private readonly IValuesHolder holder;
        public First(IValuesHolder _holder)
        {
            holder = _holder;
        }
        [HttpPost("create")]
        public IActionResult Create([FromQuery] string input)
        {
            holder.Add(input);
            return Ok();
        }
        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(holder.Get());
        }
        [HttpPut("update")]
        public IActionResult Update([FromQuery] string stringsToUpdate, [FromQuery] string newValue)
        {
            for (int i = 0; i < holder.Values.Count; i++)
            {
                if (holder.Values[i] == stringsToUpdate)
                    holder.Values[i] = newValue;
            }
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string stringsToDelete)
        {
            holder.Values = holder.Values.Where(w => w != stringsToDelete).ToList();
            return Ok();
        }
    }
}
