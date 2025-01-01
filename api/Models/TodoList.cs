using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class TodoList
    {
        public int Id { get; set; } // Primary Key
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string? Title { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public ICollection<TodoItem>? TodoItem { get; set; } = new List<TodoItem>();
    }
}