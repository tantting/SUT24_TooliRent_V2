using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsOverDuetoBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookingTools",
                keyColumns: new[] { "BookingId", "ToolId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "ReturnStatus", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3290), 1, new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3290) });

            migrationBuilder.UpdateData(
                table: "BookingTools",
                keyColumns: new[] { "BookingId", "ToolId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedDate", "ReturnStatus", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3290), 1, new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3290) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "StartDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3270), new DateTime(2025, 10, 6, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3270), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3270), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3300), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3300), new DateTime(2026, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3300), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3300) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3310), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3310), new DateTime(2026, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3310), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3310) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3330), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3340), new DateTime(2026, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3330), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3340) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MembershipDate", "MembershipValidUntil" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MembershipDate", "MembershipValidUntil" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3090), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3090), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3090), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3220), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3220), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3220), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3190), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3200), new DateTime(2025, 9, 29, 7, 21, 36, 91, DateTimeKind.Utc).AddTicks(3200) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookingTools",
                keyColumns: new[] { "BookingId", "ToolId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "ReturnStatus", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6840), 0, new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "BookingTools",
                keyColumns: new[] { "BookingId", "ToolId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedDate", "ReturnStatus", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6840), 0, new DateTime(2025, 9, 29, 6, 30, 25, 452, DateTimeKind.Utc).AddTicks(6840) });

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
        }
    }
}
