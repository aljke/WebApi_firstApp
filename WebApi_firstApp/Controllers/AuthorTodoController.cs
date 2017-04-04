using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi_firstApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_firstApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthorTodoController : Controller
    {
        private readonly IAuthorTodoRepository _authorTodoRepository;

        public AuthorTodoController(IAuthorTodoRepository authorTodoRepository)
        {
            _authorTodoRepository = authorTodoRepository;
        }

        [HttpGet]
        public IEnumerable<AuthorTodo> GetAll()
        {
            return _authorTodoRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public AuthorTodo GetById(long id)
        {
            return _authorTodoRepository.Find(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AuthorTodo item)
        {
            if (item == null)
                return BadRequest();

            _authorTodoRepository.Add(item);
            return CreatedAtRoute("GetAuthor", new { id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] AuthorTodo item)
        {
            if ((item == null) || (id != item.Id))
                return BadRequest();
            var author = _authorTodoRepository.Find(id);

            if (author == null)
                return NotFound();
            author.Name = item.Name;
            author.Todoes = item.Todoes;
            _authorTodoRepository.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var author = _authorTodoRepository.Find(id);

            if (author == null)
                return NotFound();
            _authorTodoRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
