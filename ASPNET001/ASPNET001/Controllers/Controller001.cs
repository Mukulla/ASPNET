using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET001.Controllers
{
    [Route("api/crud")]
    [ApiController]
    public class Controller001 : ControllerBase
    {
        private readonly IValuesHolder holder;
        public Controller001(IValuesHolder _holder)
        {
            holder = _holder;
        }
        [HttpPost("create")]
        public IActionResult Create([FromQuery] string newTemp)
        {/*
            DateTime date1 = new DateTime();
            date1.Minute 
            //date1 = DateTime.Now.ToString("f");*/

            holder.Add(newTemp, DateTime.Now);
            return Ok();
        }
        /*
        [HttpGet("read")]
        public IActionResult Read()
        {
            //return Ok(holder.Get(min, max));
            return Ok(DateTime.Now.ToString("f"));
            //return Ok(holder.Get());
        }*/
        
        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime min, [FromQuery] DateTime max)
        {
            return Ok(holder.Get(min, max));
            //return Ok(DateTime.Now.ToString("f"));
            //return Ok(holder.Get());
        }
        [HttpPut("update")]
        public IActionResult Update([FromQuery] string newData, [FromQuery] DateTime dateToFind)
        {
            holder.Set(newData, dateToFind);
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime dateThatDelete)
        {
            holder.Delete(dateThatDelete);
            return Ok();
        }
    }
}
