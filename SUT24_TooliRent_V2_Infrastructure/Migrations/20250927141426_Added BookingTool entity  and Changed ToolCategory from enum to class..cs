using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedBookingToolentityandChangedToolCategoryfromenumtoclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tools_ToolId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ToolId",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "ToolId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "ToolCategoryId",
                table: "Tools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "MembershipValidUntil",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BookingTool",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    ReturnStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTool", x => new { x.BookingId, x.ToolId });
                    table.ForeignKey(
                        name: "FK_BookingTool_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingTool_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToolCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BookingTool",
                columns: new[] { "BookingId", "ToolId", "CreatedDate", "ReturnStatus", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2370), 0, new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2370) },
                    { 1, 2, new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2380), 0, new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2380) }
                });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "StartDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2360), new DateTime(2025, 10, 4, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2360), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2360), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2360) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2390), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2390), new DateTime(2026, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2390), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "MemberId", "ToolId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2390), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2400), new DateTime(2026, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2400), 2, null, new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2400) });

            migrationBuilder.InsertData(
                table: "Certifications",
                columns: new[] { "Id", "CertificationDate", "CreatedDate", "ExpirationDate", "MemberId", "ToolId", "Type", "UpdatedDate" },
                values: new object[] { 3, new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2410), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2410), new DateTime(2026, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2410), 1, 2, "WorkshopSpecific", new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2410) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MembershipDate", "MembershipValidUntil", "PersonalNumber" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2320), new DateTime(2026, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2320), "19800101-1234" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Email", "MembershipDate", "MembershipValidUntil", "Name", "PersonalNumber" },
                values: new object[] { "Lillgatan 2", "bertil@example.com", new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2330), new DateTime(2026, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2330), "Bertil Bengtsson", "19900202-5678" });

            migrationBuilder.InsertData(
                table: "ToolCategories",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2180), "Skruvmejslar, hammare, tänger", "Handverktyg", new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2180) },
                    { 2, new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2180), "Borrmaskiner, cirkelsågar", "Elverktyg", new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2180) },
                    { 3, new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2180), "Tyngre utrustning som CNC, svets", "Maskiner", new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2180) }
                });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DemandsCertification", "Description", "Name", "ToolCategoryId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2290), false, "Standard hammare", "Hammare", 1, new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Name", "ToolCategoryId", "UpdatedDate", "WorkshopId" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2300), "Elborrmaskin 500W", "Borrmaskin", 2, new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2300), 1 });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Condition", "CreatedDate", "DemandsCertification", "Description", "IsAvailable", "Name", "ToolCategoryId", "UpdatedDate", "WorkshopId" },
                values: new object[] { "NeedsRepair", new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2300), true, "Industrisvets", false, "Svets", 3, new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2300), 2 });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2270), "För träarbete", "Träverkstad", new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2270), "För metallbearbetning", "Metallverkstad", new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.CreateIndex(
                name: "IX_Tools_ToolCategoryId",
                table: "Tools",
                column: "ToolCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTool_ToolId",
                table: "BookingTool",
                column: "ToolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_ToolCategories_ToolCategoryId",
                table: "Tools",
                column: "ToolCategoryId",
                principalTable: "ToolCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tools_ToolCategories_ToolCategoryId",
                table: "Tools");

            migrationBuilder.DropTable(
                name: "BookingTool");

            migrationBuilder.DropTable(
                name: "ToolCategories");

            migrationBuilder.DropIndex(
                name: "IX_Tools_ToolCategoryId",
                table: "Tools");

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ToolCategoryId",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "MembershipValidUntil",
                table: "Members");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ToolId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "StartDate", "ToolId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2390), new DateTime(2025, 10, 2, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2390), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2390), 1, new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2390) });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CreatedDate", "EndDate", "MemberId", "StartDate", "Status", "ToolId", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2400), new DateTime(2025, 9, 28, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2400), 2, new DateTime(2025, 9, 26, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2400), 0, 2, new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2400) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2360), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2360), new DateTime(2026, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2360), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2360) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "MemberId", "ToolId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2370), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2370), new DateTime(2026, 3, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2370), 1, 1, new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2370) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MembershipDate", "PersonalNumber" },
                values: new object[] { new DateTime(2023, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2300), "8501011234" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Email", "MembershipDate", "Name", "PersonalNumber" },
                values: new object[] { "Lillgatan 5", "bjorn@example.com", new DateTime(2024, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2310), "Björn Berg", "9202025678" });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "CreatedDate", "DemandsCertification", "Description", "Name", "UpdatedDate" },
                values: new object[] { "PowerTools", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2330), true, "En kraftfull borrmaskin", "Borrmaskin", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "CreatedDate", "Description", "Name", "UpdatedDate", "WorkshopId" },
                values: new object[] { "HeavyMachinery", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2330), "MIG-svets för metall", "Svets", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2330), 2 });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Condition", "CreatedDate", "DemandsCertification", "Description", "IsAvailable", "Name", "UpdatedDate", "WorkshopId" },
                values: new object[] { "HandTools", "Good", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2340), false, "En klassisk hammare", true, "Hammare", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2340), 1 });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "Category", "Condition", "CreatedDate", "DemandsCertification", "Description", "IsAvailable", "Name", "UpdatedDate", "WorkshopId" },
                values: new object[] { 4, "MeasuringTools", "Good", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2340), false, "För precis mätning", true, "Laseravståndsmätare", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2340), 1 });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2220), "För träarbeten", "Snickeriverkstaden", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2220) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2220), "För metallarbete och svetsning", "Metallverkstaden", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2220) });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ToolId",
                table: "Bookings",
                column: "ToolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tools_ToolId",
                table: "Bookings",
                column: "ToolId",
                principalTable: "Tools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
