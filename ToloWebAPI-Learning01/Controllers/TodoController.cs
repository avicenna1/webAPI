using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToloWebAPI_Learning01.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToloWebAPI_Learning01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public TodoController(ITodoRepository todoItems)
        {
            TodoItems = todoItems;
        }
        public ITodoRepository TodoItems { get; set; }

        [HttpGet]
        public IEnumerable<ToDoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        [HttpGet("{id}",Name ="GetTodo")]
        public IActionResult GetByID(string id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        [HttpPost]
        public IActionResult Create([FromBody] ToDoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            TodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key, item });
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] ToDoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }
            TodoItems.Update(item);
            return new NoContentResult();
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] ToDoItem item , string id)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var todo = TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            item.Key = todo.Key;
            TodoItems.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (string id)
        {
            var todo = TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            TodoItems.Remove(id);
            return new NoContentResult();
        }
    }
}
