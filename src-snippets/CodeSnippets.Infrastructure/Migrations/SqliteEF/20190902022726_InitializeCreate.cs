using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeSnippets.Infrastructure.Migrations.SqliteEF
{
    public partial class InitializeCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SampleEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StringValue = table.Column<string>(nullable: true),
                    DateTimeValue = table.Column<DateTime>(nullable: false),
                    BoolValue = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleEntity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleEntity");
        }
    }
}
