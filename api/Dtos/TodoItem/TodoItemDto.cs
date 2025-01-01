using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TodoList;

namespace api.Dtos.TodoItem
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateOnly? DueDate { get; set; }
        public int TodoListId { get; set; }
    }
}