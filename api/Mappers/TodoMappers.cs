using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TodoItem;
using api.Dtos.TodoList;
using api.Models;

namespace api.Mappers
{
    public static class TodoMappers
    {
        public static TodoListDto TodoListDto(this TodoList todoListModel)
        {
            return new TodoListDto
            {
                Id = todoListModel.Id,
                Title = todoListModel.Title,
                Items = todoListModel.TodoItem?.Select(item => new TodoItemDto
                {
                    Description = item.Description,
                    IsCompleted = item.IsCompleted,
                    DueDate = item.DueDate,
                    TodoListId = item.TodoListId
                }).ToList()
            };
        }

        public static TodoList TodoListFromCreateDto(this CreateTodoListRequestDto dto)
        {
            return new TodoList
            {
                Title = dto.Title,
                TodoItem = dto.Items?.Select(item => new TodoItem
                {
                    Description = item.Description,
                    IsCompleted = item.IsCompleted,
                    DueDate = item.DueDate
                }).ToList()
            };
        }

        public static TodoList TodoListFromUpdateDto(this UpdateTodoListRequestDto todoListDto)
        {
            return new TodoList
            {
                Title = todoListDto.Title
            };
        }
    }
}