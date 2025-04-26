using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Culturapp.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Enterprises _Users_UserId",
                table: "Enterprises ");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Enterprises _EnterpriseId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventLocations_EventLocationId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "EventLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faqs",
                table: "Faqs");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventLocationId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises _UserId",
                table: "Enterprises ");

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
                name: "PK_Phones",
                table: "Phones");

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
                name: "Location",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Events");

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
                name: "Faqs",
                newName: "FAQs");

            migrationBuilder.RenameTable(
                name: "Phones",
                newName: "Telephones");

            migrationBuilder.RenameTable(
                name: "Checks",
                newName: "Checkings");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Events",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "EventLocationId",
                table: "Events",
                newName: "LocationAddressId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Events",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "Enterprises ",
                newName: "CNPJ");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Enterprises ",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Telephones",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Telephones",
                newName: "AreaCode");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Checkings",
                newName: "CheckInDate");

            migrationBuilder.AddColumn<int>(
                name: "PhoneId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CheckingId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Events",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FAQId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SalesEndDate",
                table: "Events",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SalesStartDate",
                table: "Events",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Enterprises ",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Enterprises ",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Enterprises ",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "EnterpriseId",
                table: "Telephones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Telephones",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FAQs",
                table: "FAQs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Telephones",
                table: "Telephones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checkings",
                table: "Checkings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CheckingsUsers",
                columns: table => new
                {
                    ChecksId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingsUsers", x => new { x.ChecksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CheckingsUsers_Checkings_ChecksId",
                        column: x => x.ChecksId,
                        principalTable: "Checkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingsUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventUsers",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUsers", x => new { x.EventsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_EventUsers_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneId",
                table: "Users",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CheckingId",
                table: "Events",
                column: "CheckingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_FAQId",
                table: "Events",
                column: "FAQId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationAddressId",
                table: "Events",
                column: "LocationAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_StatusId",
                table: "Events",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises _AddressId",
                table: "Enterprises ",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telephones_EnterpriseId",
                table: "Telephones",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Telephones_EventId",
                table: "Telephones",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingsUsers_UsersId",
                table: "CheckingsUsers",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUsers_UsersId",
                table: "EventUsers",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises _Addresses_AddressId",
                table: "Enterprises ",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Addresses_LocationAddressId",
                table: "Events",
                column: "LocationAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Checkings_CheckingId",
                table: "Events",
                column: "CheckingId",
                principalTable: "Checkings",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Enterprises _EnterpriseId",
                table: "Events",
                column: "EnterpriseId",
                principalTable: "Enterprises ",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_FAQs_FAQId",
                table: "Events",
                column: "FAQId",
                principalTable: "FAQs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Statuses_StatusId",
                table: "Events",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Telephones_Enterprises _EnterpriseId",
                table: "Telephones",
                column: "EnterpriseId",
                principalTable: "Enterprises ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telephones_Events_EventId",
                table: "Telephones",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Telephones_PhoneId",
                table: "Users",
                column: "PhoneId",
                principalTable: "Telephones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises _Addresses_AddressId",
                table: "Enterprises ");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Addresses_LocationAddressId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Checkings_CheckingId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Enterprises _EnterpriseId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_FAQs_FAQId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Statuses_StatusId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Telephones_Enterprises _EnterpriseId",
                table: "Telephones");

            migrationBuilder.DropForeignKey(
                name: "FK_Telephones_Events_EventId",
                table: "Telephones");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Telephones_PhoneId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CheckingsUsers");

            migrationBuilder.DropTable(
                name: "EventUsers");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Users_PhoneId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FAQs",
                table: "FAQs");

            migrationBuilder.DropIndex(
                name: "IX_Events_CategoryId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CheckingId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_FAQId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_LocationAddressId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_StatusId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises _AddressId",
                table: "Enterprises ");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Telephones",
                table: "Telephones");

            migrationBuilder.DropIndex(
                name: "IX_Telephones_EnterpriseId",
                table: "Telephones");

            migrationBuilder.DropIndex(
                name: "IX_Telephones_EventId",
                table: "Telephones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checkings",
                table: "Checkings");

            migrationBuilder.DropColumn(
                name: "PhoneId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CheckingId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "FAQId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SalesEndDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SalesStartDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Enterprises ");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Enterprises ");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Enterprises ");

            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "Telephones");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Telephones");

            migrationBuilder.RenameTable(
                name: "FAQs",
                newName: "Faqs");

            migrationBuilder.RenameTable(
                name: "Telephones",
                newName: "Phones");

            migrationBuilder.RenameTable(
                name: "Checkings",
                newName: "Checks");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Events",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Events",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "LocationAddressId",
                table: "Events",
                newName: "EventLocationId");

            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "Enterprises ",
                newName: "Cnpj");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Enterprises ",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Phones",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AreaCode",
                table: "Phones",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "CheckInDate",
                table: "Checks",
                newName: "DateTime");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Events",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Events",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "PK_Faqs",
                table: "Faqs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phones",
                table: "Phones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checks",
                table: "Checks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CPF = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLocations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventLocationId",
                table: "Events",
                column: "EventLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises _UserId",
                table: "Enterprises ",
                column: "UserId");

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
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLocations_AddressId",
                table: "EventLocations",
                column: "AddressId");

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
                name: "FK_Enterprises _Users_UserId",
                table: "Enterprises ",
                column: "UserId",
                principalTable: "Users",
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
        }
    }
}
