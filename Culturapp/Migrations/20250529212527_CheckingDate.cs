using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Culturapp.Migrations
{
    /// <inheritdoc />
    public partial class CheckingDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckInDate",
                table: "Checkings",
                newName: "CheckingDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckingDate",
                table: "Checkings",
                newName: "CheckInDate");
        }
    }
}
