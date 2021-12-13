using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

//shadows Ch16 Models/DataLayer/BookstoreContext
// attempting to recreate Exercise 16-1 items 8-10 which allow User Login Properties to be added to a database

namespace ToDoList.Models
{
    public class ToDoContext : IdentityDbContext<User>
    {
        // combined from previous Models/ToDoContext.cs
        // user's todo list creation??
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options) { }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // adapting from bookstoreContext
            base.OnModelCreating(modelBuilder);

            // CategoryID: set primary key
            modelBuilder.Entity<Category>().HasKey(ba => new { ba.CategoryId, ba.Name });

            // CategoryID: set foreign keys ?? confused here need to think about how foreign keys work
            // this will connect to the status of the ToDo List
            /*
            modelBuilder.Entity<Category>().HasOne(ba => ba.CategoryID)
                   .WithMany(b => b. CategoryID)
                   .HasForeignKey(ba => )
            */

            // CategoryID: remove cascading delete
            // will add later, simply testing now to see if we can get working User in database

            // see initial data
            // all seeds shadow get/sets above
            // seed data comes from something like Ch16/Models/DataLayer/SeedData
            //  see examples in this folder, very evident this is simply data that we want to have initially. not needed here
         




            // commenting out below from original, seems to have need for primary key, likely true, will try to adap
            /*
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "work", Name = "Work" },
                new Category { CategoryId = "home", Name = "Home" },
                new Category { CategoryId = "ex", Name = "Exercise" },
                new Category { CategoryId = "shop", Name = "Shopping" },
                new Category { CategoryId = "call", Name = "Contact" }
            );
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "open", Name = "Open" },
                new Status { StatusId = "closed", Name = "Completed" }
            );
            */
        }


        // below user creation
        public static async Task CreateAdminUser(IServiceProvider serviceProvider){
            UserManager<User> userManager =
               serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();


            string username = "admin";
            string password = "Sesame";
            string roleName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }


            // if username doesn't exist, create it and add to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

        /*
        public IActionResult Index(){
            return View();
        }
        */
    }
}
