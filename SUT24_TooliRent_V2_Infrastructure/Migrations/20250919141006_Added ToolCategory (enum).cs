using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedToolCategoryenum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Tools",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7930), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 3, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7940), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950), new DateTime(2026, 3, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950), new DateTime(2026, 6, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7950) });

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
                columns: new[] { "Category", "CreatedDate", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7910), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "CreatedDate", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7910), new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "Category", "Condition", "CreatedDate", "DemandsCertification", "Description", "IsAvailable", "Name", "UpdatedDate", "WorkshopId" },
                values: new object[,]
                {
                    { 3, 0, 1, new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7910), false, "En klassisk hammare", true, "Hammare", new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7910), 1 },
                    { 4, 3, 1, new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7920), false, "För precis mätning", true, "Laseravståndsmätare", new DateTime(2025, 9, 19, 14, 10, 6, 117, DateTimeKind.Utc).AddTicks(7920), 1 }
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Tools");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "StartDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30), new DateTime(2025, 9, 26, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30), new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30), new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "StartDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30), new DateTime(2025, 9, 22, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30), new DateTime(2025, 9, 20, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30), new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc).AddTicks(30) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990), new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990), new DateTime(2026, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990), new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990), new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990), new DateTime(2026, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9990), new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 3, 19, 12, 32, 4, 346, DateTimeKind.Utc), new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc), new DateTime(2026, 3, 19, 12, 32, 4, 346, DateTimeKind.Utc), new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Certifications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CertificationDate", "CreatedDate", "ExpirationDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 6, 19, 12, 32, 4, 346, DateTimeKind.Utc), new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc), new DateTime(2026, 6, 19, 12, 32, 4, 346, DateTimeKind.Utc), new DateTime(2025, 9, 19, 12, 32, 4, 346, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                column: "MembershipDate",
                value: new DateTime(2023, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9940));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                column: "MembershipDate",
                value: new DateTime(2024, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9970), new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9970) });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9980), new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9980) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9830), new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9830) });

            migrationBuilder.UpdateData(
                table: "Workshops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9830), new DateTime(2025, 9, 19, 12, 32, 4, 345, DateTimeKind.Utc).AddTicks(9830) });
        }
    }
}
