using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedBookingTooltoDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingTool_Bookings_BookingId",
                table: "BookingTool");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingTool_Tools_ToolId",
                table: "BookingTool");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingTool",
                table: "BookingTool");

            migrationBuilder.RenameTable(
                name: "BookingTool",
                newName: "BookingTools");

            migrationBuilder.RenameIndex(
                name: "IX_BookingTool_ToolId",
                table: "BookingTools",
                newName: "IX_BookingTools_ToolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingTools",
                table: "BookingTools",
                columns: new[] { "BookingId", "ToolId" });

            migrationBuilder.UpdateData(
                table: "BookingTools",
                keyColumns: new[] { "BookingId", "ToolId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6840), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "BookingTools",
                keyColumns: new[] { "BookingId", "ToolId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6840), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "StartDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6820), new DateTime(2025, 10, 6, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6820), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6820), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6850), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6850), new DateTime(2026, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6850), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6860), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6860), new DateTime(2026, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6860), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6870), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6880), new DateTime(2026, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6870), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MembershipDate", "MembershipValidUntil" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6790), new DateTime(2026, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6790) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MembershipDate", "MembershipValidUntil" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6800), new DateTime(2026, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6800) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6630), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6630), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6640), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6640) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6760), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6760) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6770), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6770) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6770), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6770) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6740), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6740), new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6740) });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTools_Bookings_BookingId",
                table: "BookingTools",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTools_Tools_ToolId",
                table: "BookingTools",
                column: "ToolId",
                principalTable: "Tools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingTools_Bookings_BookingId",
                table: "BookingTools");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingTools_Tools_ToolId",
                table: "BookingTools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingTools",
                table: "BookingTools");

            migrationBuilder.RenameTable(
                name: "BookingTools",
                newName: "BookingTool");

            migrationBuilder.RenameIndex(
                name: "IX_BookingTools_ToolId",
                table: "BookingTool",
                newName: "IX_BookingTool_ToolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingTool",
                table: "BookingTool",
                columns: new[] { "BookingId", "ToolId" });

            migrationBuilder.UpdateData(
                table: "BookingTool",
                keyColumns: new[] { "BookingId", "ToolId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2370), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2370) });

            migrationBuilder.UpdateData(
                table: "BookingTool",
                keyColumns: new[] { "BookingId", "ToolId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2380), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2380) });

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
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2390), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2400), new DateTime(2026, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2400), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2400) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2410), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2410), new DateTime(2026, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2410), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2410) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MembershipDate", "MembershipValidUntil" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2320), new DateTime(2026, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2320) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MembershipDate", "MembershipValidUntil" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2330), new DateTime(2026, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2180), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2180), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2180), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2290), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2300), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2300) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2300), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2300) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2270), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2270), new DateTime(2025, 9, 27, 14, 14, 25, 843, DateTimeKind.Utc).AddTicks(2270) });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTool_Bookings_BookingId",
                table: "BookingTool",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTool_Tools_ToolId",
                table: "BookingTool",
                column: "ToolId",
                principalTable: "Tools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
