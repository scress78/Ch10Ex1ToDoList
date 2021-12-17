using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Category
    {
        public int CategoryId { get; set; }   // PK
        
        public string Name { get; set; }

        public ICollection<ToDo> ToDos { get; set; } // Navigation property
        // what exactly does above do??
        // ok, MUCH better. doesn't do what it needs to yet; but doesn't error out!

        public string CatName => $"{Name}";
    }
}
