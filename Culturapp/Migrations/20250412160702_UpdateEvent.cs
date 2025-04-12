using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Culturapp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ScoreValue",
                table: "Events",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Events",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<double>(
                name: "TicketPrice",
                table: "Events",
                type: "double",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreValue",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Events");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Events",
                type: "decimal(65,30)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
