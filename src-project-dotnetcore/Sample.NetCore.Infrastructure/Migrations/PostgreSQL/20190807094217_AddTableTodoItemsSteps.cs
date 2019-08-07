using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sample.NetCore.Infrastructure.Migrations.PostgreSQL
{
    public partial class AddTableTodoItemsSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifyTime",
                table: "TodoItems",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreateTime",
                table: "TodoItems",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "TodoItemStep",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Index = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    TodoItemID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItemStep", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TodoItemStep_TodoItems_TodoItemID",
                        column: x => x.TodoItemID,
                        principalTable: "TodoItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItemStep_TodoItemID",
                table: "TodoItemStep",
                column: "TodoItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItemStep");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "TodoItems",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "TodoItems",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));
        }
    }
}
