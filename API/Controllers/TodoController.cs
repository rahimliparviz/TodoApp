using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodosController(ITodoRepository repository)
        {
            _repository = repository;
        }
        
  
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TodoDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetTodos()
        {
            var categories = await _repository.GetTodos();
            return Ok(categories);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TodoDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TodoDto>> GetTodoById(int id)
        {
            var product = await _repository.GetTodo(id);
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateTodo([FromBody] TodoFromUserDto todo)
        {
            return Ok(await  _repository.CreateTodo(todo));
          
        }
        
       
        
       
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TodoDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateTodo(int id,[FromBody] TodoFromUserDto todo)
        {
            return Ok(await _repository.UpdateTodo(id,todo));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TodoDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            return Ok(await _repository.DeleteTodo(id));
        }
    }
}