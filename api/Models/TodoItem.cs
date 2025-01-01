using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class TodoItem
    {

        [Key]        
        public int Id { get; set; } // Primary Key
        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateOnly? DueDate { get; set; }
        public int TodoListId { get; set; } // Foreign Key

        // Navigation Properties
        public TodoList? TodoList { get; set; }
    }
}