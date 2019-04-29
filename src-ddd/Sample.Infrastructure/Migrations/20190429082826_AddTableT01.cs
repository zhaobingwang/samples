using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample.Infrastructure.Migrations
{
    public partial class AddTableT01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T01",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    StringValue = table.Column<string>(nullable: true),
                    IntValue = table.Column<int>(nullable: false),
                    DateTimeValue = table.Column<DateTime>(nullable: false),
                    BooleanValue = table.Column<short>(nullable: false),
                    IntNullableValue = table.Column<int>(nullable: true),
                    DateTimeNullableValue = table.Column<DateTime>(nullable: true),
                    BooleanNullableValue = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T01", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T01");
        }
    }
}
