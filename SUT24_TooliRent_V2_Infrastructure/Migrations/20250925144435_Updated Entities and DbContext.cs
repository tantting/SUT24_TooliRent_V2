using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEntitiesandDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Members_MemberId",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Tools_ToolId",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Tools_Workshops_WorkshopId",
                table: "Tools");

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 4);

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
                name: "Condition",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Certifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ToolId",
                table: "Certifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CertificationTool",
                columns: table => new
                {
                    CertificationsId = table.Column<int>(type: "int", nullable: false),
                    ToolsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationTool", x => new { x.CertificationsId, x.ToolsId });
                    table.ForeignKey(
                        name: "FK_CertificationTool_Certifications_CertificationsId",
                        column: x => x.CertificationsId,
                        principalTable: "Certifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificationTool_Tools_ToolsId",
                        column: x => x.ToolsId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "StartDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2390), new DateTime(2025, 10, 2, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2390), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2390), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "StartDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2400), new DateTime(2025, 9, 28, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2400), new DateTime(2025, 9, 26, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2400), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2400) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "ToolId", "Type", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2360), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2360), new DateTime(2026, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2360), null, "General", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2360) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "MemberId", "Type", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2370), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2370), new DateTime(2026, 3, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2370), 1, "PowerTools", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2370) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                column: "MembershipDate",
                value: new DateTime(2023, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                column: "MembershipDate",
                value: new DateTime(2024, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Condition", "CreatedDate", "UpdatedDate" },
                values: new object[] { "PowerTools", "Good", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2330), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Condition", "CreatedDate", "UpdatedDate" },
                values: new object[] { "HeavyMachinery", "Good", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2330), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Condition", "CreatedDate", "UpdatedDate" },
                values: new object[] { "HandTools", "Good", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2340), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2340) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Condition", "CreatedDate", "UpdatedDate" },
                values: new object[] { "MeasuringTools", "Good", new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2340), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2340) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2220), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2220) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2220), new DateTime(2025, 9, 25, 14, 44, 35, 36, DateTimeKind.Utc).AddTicks(2220) });

            migrationBuilder.CreateIndex(
                name: "IX_CertificationTool_ToolsId",
                table: "CertificationTool",
                column: "ToolsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Members_MemberId",
                table: "Certifications",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Tools_ToolId",
                table: "Certifications",
                column: "ToolId",
                principalTable: "Tools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_Workshops_WorkshopId",
                table: "Tools",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Members_MemberId",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Tools_ToolId",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Tools_Workshops_WorkshopId",
                table: "Tools");

            migrationBuilder.DropTable(
                name: "CertificationTool");

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

            migrationBuilder.AlterColumn<int>(
                name: "Condition",
                table: "Tools",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Tools",
                type: "int",
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

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Certifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ToolId",
                table: "Certifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "StartDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7970), new DateTime(2025, 9, 26, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7970), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7970), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7970) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "StartDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7970), new DateTime(2025, 9, 22, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7970), new DateTime(2025, 9, 20, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7970), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7970) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "ToolId", "Type", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7930), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940), 1, 0, new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "MemberId", "Type", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940), 2, 0, new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.InsertData(
                table: "Certifications",
                columns: new[] { "Id", "CertificationDate", "CreatedDate", "ExpirationDate", "MemberId", "ToolId", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { 3, new DateTime(2025, 3, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950), new DateTime(2026, 3, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950), 1, 1, 1, new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950) },
                    { 4, new DateTime(2025, 6, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950), new DateTime(2026, 6, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950), 1, 2, 2, new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950) }
                });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                column: "MembershipDate",
                value: new DateTime(2023, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                column: "MembershipDate",
                value: new DateTime(2024, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Condition", "CreatedDate", "UpdatedDate" },
                values: new object[] { 1, 1, new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7910), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Condition", "CreatedDate", "UpdatedDate" },
                values: new object[] { 2, 1, new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7910), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Condition", "CreatedDate", "UpdatedDate" },
                values: new object[] { 0, 1, new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7910), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Condition", "CreatedDate", "UpdatedDate" },
                values: new object[] { 3, 1, new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7920), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7800), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7800), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7800) });

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Members_MemberId",
                table: "Certifications",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Tools_ToolId",
                table: "Certifications",
                column: "ToolId",
                principalTable: "Tools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_Workshops_WorkshopId",
                table: "Tools",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
