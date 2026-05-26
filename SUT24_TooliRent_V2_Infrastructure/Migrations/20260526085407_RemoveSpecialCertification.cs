using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSpecialCertification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Tools_ToolId",
                table: "Certifications");

            migrationBuilder.DropIndex(
                name: "IX_Certifications_ToolId",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "ToolId",
                table: "Certifications");

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3340), new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3340) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3340), new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3340) });

            migrationBuilder.UpdateData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3350), new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3420), new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3410), new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3410), new DateTime(2026, 5, 26, 8, 54, 7, 317, DateTimeKind.Utc).AddTicks(3410) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToolId",
                table: "Certifications",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_ToolId",
                table: "Certifications",
                column: "ToolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Tools_ToolId",
                table: "Certifications",
                column: "ToolId",
                principalTable: "Tools",
                principalColumn: "Id");
        }
    }
}
