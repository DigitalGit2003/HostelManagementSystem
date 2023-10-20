using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HostelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "floor",
                table: "rooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "floor",
                table: "rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
