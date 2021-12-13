using System.ComponentModel.DataAnnotations;

// Adapted from Ch16Bookstore > Models > ViewModels > LoginViewModel
// Testing basic login information, can be added to later
namespace ToDoList.Models
{
    public class LoginViewModel
    { 
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(255)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
