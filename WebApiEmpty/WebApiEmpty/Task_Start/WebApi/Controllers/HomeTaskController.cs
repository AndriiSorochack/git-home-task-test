using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto;

namespace WebApi.Controllers
{
    public class HomeTaskController : Controller
    {
        private readonly HomeTaskService _taskServices;

        public HomeTaskController(HomeTaskService taskServices)
        {
            _taskServices = taskServices;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<HomeTaskDto>> Get()
        {
            return Ok(_taskServices.GetAllHomeTasks().Select(task => HomeTaskDto.FromModel(task)));
        }

        [HttpGet("{id}")]
        public ActionResult<HomeTaskDto> Get(int id)
        {
            var homeTask = _taskServices.GetHomeTaskById(id);

            if(homeTask == null)
            {
                return NotFound();
            }

            return Ok(HomeTaskDto.FromModel(homeTask));
        }

        public ActionResult CreateHomeTask([FromBody] HomeTaskDto value)
        {
            var updateResult = _taskServices.CreateHomeTask(value.ToModel());
            if (updateResult.HasErrors)
            {
                return BadRequest(updateResult.Errors);
            }
            return Accepted(updateResult);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] HomeTaskDto value)
        {
            var updateResult = _taskServices.UpdateHomeTask(value.ToModel());
            if (updateResult.HasErrors)
            {
                return BadRequest(updateResult.Errors);
            }
            return Accepted();
        }

        // DELETE api/Course/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _taskServices.DeleteHomeTask(id);
            return Accepted();
        }
    }
}
