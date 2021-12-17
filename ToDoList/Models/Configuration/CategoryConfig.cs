using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoList.Models
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        /*
        { "work", "Work" },
                    { "home", "Home" },
                    { "ex", "Exercise" },
                    { "shop", "Shopping" },
                    { "call", "Contact" }
        */
        {
            entity.HasData(
               new Category { CategoryId = 1, Name = "Work"},
               new Category { CategoryId = 2, Name = "Home"},
               new Category { CategoryId = 3, Name = "Exercise" },
               new Category { CategoryId = 4, Name = "Shopping" },
               new Category { CategoryId = 5, Name = "Contact" }
            );
        }
    }

}