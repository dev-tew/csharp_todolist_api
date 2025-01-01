using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TodoItem;

namespace api.Dtos.TodoList
{
    public class CreateTodoListRequestDto
    {
           public string? Title { get; set; }

           public List<CreateTodoItemRequestDto>? Items { get; set; }
    }
}