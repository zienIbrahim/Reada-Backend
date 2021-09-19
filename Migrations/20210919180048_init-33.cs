using Microsoft.EntityFrameworkCore.Migrations;

namespace Reada_Backend.Migrations
{
    public partial class init33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UnitName",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitName",
                table: "Units");
        }
    }
}
