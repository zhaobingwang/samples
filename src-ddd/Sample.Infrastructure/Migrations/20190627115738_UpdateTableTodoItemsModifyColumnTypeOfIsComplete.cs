using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample.Infrastructure.Migrations
{
    public partial class UpdateTableTodoItemsModifyColumnTypeOfIsComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "IsComplete",
                table: "TodoItems",
                nullable: false,
                oldClrType: typeof(short));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "IsComplete",
                table: "TodoItems",
                nullable: false,
                oldClrType: typeof(short));
        }
    }
}
