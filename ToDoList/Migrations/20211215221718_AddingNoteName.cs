using Microsoft.EntityFrameworkCore.Migrations;

namespace Ch10ToDoList.Migrations
{
    public partial class AddingNoteName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoteName",
                table: "ToDos",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteName",
                table: "ToDos");
        }
    }
}
