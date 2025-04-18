using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Culturapp.Migrations
{
    /// <inheritdoc />
    public partial class RenameOrganizerToEnterprise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Organizers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checkings",
                table: "Checkings");

            migrationBuilder.RenameTable(
                name: "Checkings",
                newName: "Checks");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnterpriseId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventLocationId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "EventLocations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Customers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnterpriseId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Checks",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "CheckString",
                table: "Checks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Checks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Checks",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checks",
                table: "Checks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Enterprises ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Cnpj = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprises ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enterprises _Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EnterpriseId",
                table: "Events",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventLocationId",
                table: "Events",
                column: "EventLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLocations_AddressId",
                table: "EventLocations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_EventId",
                table: "Categories",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EnterpriseId",
                table: "Addresses",
                column: "EnterpriseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EventId",
                table: "Addresses",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checks_CustomerId",
                table: "Checks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_EventId",
                table: "Checks",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises _UserId",
                table: "Enterprises ",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Enterprises _EnterpriseId",
                table: "Addresses",
                column: "EnterpriseId",
                principalTable: "Enterprises ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Events_EventId",
                table: "Categories",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_Customers_CustomerId",
                table: "Checks",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_Events_EventId",
                table: "Checks",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventLocations_Addresses_AddressId",
                table: "EventLocations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Enterprises _EnterpriseId",
                table: "Events",
                column: "EnterpriseId",
                principalTable: "Enterprises ",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventLocations_EventLocationId",
                table: "Events",
                column: "EventLocationId",
                principalTable: "EventLocations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Enterprises _EnterpriseId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Events_EventId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Checks_Customers_CustomerId",
                table: "Checks");

            migrationBuilder.DropForeignKey(
                name: "FK_Checks_Events_EventId",
                table: "Checks");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_EventLocations_Addresses_AddressId",
                table: "EventLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Enterprises _EnterpriseId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventLocations_EventLocationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Enterprises ");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Events_EnterpriseId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventLocationId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_EventLocations_AddressId",
                table: "EventLocations");

            migrationBuilder.DropIndex(
                name: "IX_Categories_EventId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_EnterpriseId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_EventId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checks",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_Checks_CustomerId",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_Checks_EventId",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventLocationId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "EventLocations");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CheckString",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Checks");

            migrationBuilder.RenameTable(
                name: "Checks",
                newName: "Checkings");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: null,
                column: "Username",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Phone",
                keyValue: null,
                column: "Phone",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Password",
                keyValue: null,
                column: "Password",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Name",
                keyValue: null,
                column: "Name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Email",
                keyValue: null,
                column: "Email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CPF",
                keyValue: null,
                column: "CPF",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Customers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Name",
                keyValue: null,
                column: "Name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Description",
                keyValue: null,
                column: "Description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Checkings",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checkings",
                table: "Checkings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cnpj = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
