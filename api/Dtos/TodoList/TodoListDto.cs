using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TodoItem;

namespace api.Dtos.TodoList
{
    public class TodoListDto
    {
        public int Id { get; set; } 
        public string? Title { get; set; }

        public List<TodoItemDto>? Items { get; set; }
    }
}