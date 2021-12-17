using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a note name.")]
        public string NoteName { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a due date.")]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }   // Foreign key property
        public Category Category { get; set; } // Navigation property??

        [Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; }
        public Status Status { get; set; }

        [Required(ErrorMessage = "Please enter in the note contents.")]
        public string NoteContents { get; set; }
        public bool Overdue => 
            StatusId == "open" && DueDate < DateTime.Today;
    }
}
