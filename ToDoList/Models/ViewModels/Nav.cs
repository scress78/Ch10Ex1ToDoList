// from Ch16/Models/ViewModels/Nav.cs
// I believe makes it so URLs can actually work, ie makes it possible for Login button to route to Account/Login

// if below is uncommented there is an error from the HomeController, ToDo is a namespace but used as a Model
// not sure why yet, just commenting out for now.

namespace ToDoList.Models
{
    public static class Nav
    {
        public static string Active(string value, string current) =>
            (value == current) ? "active" : "";
        public static string Active(int value, int current) =>
            (value == current) ? "active" : "";
    }
}

