using System.ComponentModel.DataAnnotations;

// Adapted from Ch16Bookstore > Models > ViewModels > RegisterViewModel
// Testing basic login information, can be added to later
namespace ToDoList.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        //[DataType(DataType.Password)]
        //[Compare("ConfirmPassword")]
        public string Password { get; set; }
    }
}
