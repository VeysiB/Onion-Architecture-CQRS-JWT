using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medas.JwtAPP.Back.Persistance.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Point",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
