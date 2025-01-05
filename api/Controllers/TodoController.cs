using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.TodoList;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/todolist")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TodoController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all TodoLists", Description = "Retrieves all TodoLists from the database.")]
        public IActionResult GetAll()
        {
            var lists = _context.TodoLists?
                .Include(list => list.TodoItem) // Include associated TodoItems
                .ToList()
                .Select(list => list.TodoListDto());

            return Ok(lists);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var list = _context.TodoLists?
                .Include(list => list.TodoItem) // Include associated items
                .FirstOrDefault(list => list.Id == id);

            if(list == null)
            {
                return NotFound();
            }

            return Ok(list.TodoListDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTodoListRequestDto requestDto)
        {
            var listModel = requestDto.TodoListFromCreateDto();

            _context.TodoLists?.Add(listModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = listModel.Id}, listModel.TodoListDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateTodoListRequestDto requestDto)
        {
            var listModel = _context.TodoLists?.FirstOrDefault(x => x.Id == id);
            
            if (listModel == null)
            {
                return NotFound();
            }

            listModel.Title = requestDto.Title;

            _context.SaveChanges();

            return Ok(listModel.TodoListDto());
        }
    }
}