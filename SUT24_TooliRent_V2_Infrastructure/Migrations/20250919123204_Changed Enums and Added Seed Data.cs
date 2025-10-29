using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEnumsandAddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "personalNumber",
                table: "Members",
                newName: "PersonalNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Workshops",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Workshops",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tools",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tools",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Members",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Members",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Address", "Email", "IsActive", "MembershipDate", "Name", "PersonalNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Storgatan 1", "anna@example.com", true, new DateTime(2023, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9940), "Anna Andersson", "8501011234", "0701234567" },
                    { 2, "Lillgatan 5", "bjorn@example.com", true, new DateTime(2024, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9950), "Björn Berg", "9202025678", "0709876543" }
                });

            migrationBuilder.InsertData(
                table: "Workshops",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9830), "För träarbeten", "Snickeriverkstaden", new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9830) },
                    { 2, new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9830), "För metallarbete och svetsning", "Metallverkstaden", new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9830) }
                });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "Condition", "CreatedDate", "DemandsCertification", "Description", "IsAvailable", "Name", "UpdatedDate", "WorkshopId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9970), true, "En kraftfull borrmaskin", true, "Borrmaskin", new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9970), 1 },
                    { 2, 1, new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9980), true, "MIG-svets för metall", true, "Svets", new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9980), 2 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CreatedDate", "EndDate", "MemberId", "StartDate", "Status", "ToolId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30), new DateTime(2025, 9, 26, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30), 1, new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30), 1, 1, new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30) },
                    { 2, new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30), new DateTime(2025, 9, 22, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30), 2, new DateTime(2025, 9, 20, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30), 0, 2, new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30) }
                });

            migrationBuilder.InsertData(
                table: "Certifications",
                columns: new[] { "Id", "CertificationDate", "CreatedDate", "ExpirationDate", "MemberId", "ToolId", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990), new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990), new DateTime(2026, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990), 1, 1, 0, new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990) },
                    { 2, new DateTime(2024, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990), new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990), new DateTime(2026, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990), 2, 1, 0, new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc) },
                    { 3, new DateTime(2025, 3, 19, 12, 32, 4, 346, DateTimeKind.Utc), new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc), new DateTime(2026, 3, 19, 12, 32, 4, 346, DateTimeKind.Utc), 1, 1, 1, new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc) },
                    { 4, new DateTime(2025, 6, 19, 12, 32, 4, 346, DateTimeKind.Utc), new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc), new DateTime(2026, 6, 19, 12, 32, 4, 346, DateTimeKind.Utc), 1, 2, 2, new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "PersonalNumber",
                table: "Members",
                newName: "personalNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Workshops",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Workshops",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
