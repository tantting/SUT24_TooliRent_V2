using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMemberSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8580), new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8590) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8590), new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8590) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8590), new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8590) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8650), new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8650) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8650), new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8650) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8650), new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8650) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8630), new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8640) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8640), new DateTime(2026, 5, 26, 8, 41, 29, 137, DateTimeKind.Utc).AddTicks(8640) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5410), new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5410), new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5410), new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5460) });
        }
    }
}
