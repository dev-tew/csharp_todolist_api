using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TodoItem
{
    public class CreateTodoItemRequestDto
    {
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateOnly? DueDate { get; set; }
    }
}