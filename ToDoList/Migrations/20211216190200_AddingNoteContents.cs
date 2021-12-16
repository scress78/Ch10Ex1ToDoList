using Microsoft.EntityFrameworkCore.Migrations;

namespace Ch10ToDoList.Migrations
{
    public partial class AddingNoteContents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoteContents",
                table: "ToDos",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteContents",
                table: "ToDos");
        }
    }
}
