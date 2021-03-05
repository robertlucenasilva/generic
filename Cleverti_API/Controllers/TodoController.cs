using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clevert.Domain;
using Cleverti_API.Atributes;
using Cleverti_API.Service.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cleverti_API.Controllers
{
    [ApiKey]
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {        
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]        
        public async Task<ActionResult<TodoVO>> GetById(Guid id)
        {
            var item = await _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoVO>>> Get()
        {
            var items = await _service.Get();
            return Ok(items);
        }

        [HttpPut]
        public async Task<ActionResult> Update(TodoVO obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Update(obj).Result;
            if (item != null)
            {
                return CreatedAtAction("Get", new { id = item }, item);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody]TodoVO obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item =  _service.Insert(obj).Result;
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var existingItem = _service.GetById(id).Result;
            if (existingItem == null)
            {
                return NotFound();
            }
            await _service.Delete(id);
            return Ok();            
        }
    }
}









