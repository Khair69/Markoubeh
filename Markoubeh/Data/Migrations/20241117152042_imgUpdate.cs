using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Markoubeh.Migrations
{
    /// <inheritdoc />
    public partial class imgUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgURL",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgURL",
                table: "Cars");
        }
    }
}
