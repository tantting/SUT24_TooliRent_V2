using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MembershipDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MembershipValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Workshops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    DemandsCertification = table.Column<bool>(type: "bit", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToolCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tools_ToolCategories_ToolCategoryId",
                        column: x => x.ToolCategoryId,
                        principalTable: "ToolCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tools_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingTools",
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
                    table.PrimaryKey("PK_BookingTools", x => new { x.BookingId, x.ToolId });
                    table.ForeignKey(
                        name: "FK_BookingTools_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingTools_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    CertificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certifications_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certifications_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "ToolCategories",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5410), "Skruvmejslar, hammare, tänger", "Handverktyg", new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5410) },
                    { 2, new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5410), "Borrmaskiner, cirkelsågar", "Elverktyg", new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5410) },
                    { 3, new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5410), "Tyngre utrustning som CNC, svets", "Maskiner", new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5410) }
                });

            migrationBuilder.InsertData(
                table: "Workshops",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5460), "För träarbete", "Träverkstad", new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5460) },
                    { 2, new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5460), "För metallbearbetning", "Metallverkstad", new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5460) }
                });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "Condition", "CreatedDate", "DemandsCertification", "Description", "IsAvailable", "Name", "ToolCategoryId", "UpdatedDate", "WorkshopId" },
                values: new object[,]
                {
                    { 1, "Good", new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5470), false, "Standard hammare", true, "Hammare", 1, new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5470), 1 },
                    { 2, "Good", new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5470), true, "Elborrmaskin 500W", true, "Borrmaskin", 2, new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5470), 1 },
                    { 3, "NeedsRepair", new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5470), true, "Industrisvets", false, "Svets", 3, new DateTime(2026, 5, 26, 6, 58, 32, 429, DateTimeKind.Utc).AddTicks(5470), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MemberId",
                table: "Bookings",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTools_ToolId",
                table: "BookingTools",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_MemberId",
                table: "Certifications",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_ToolId",
                table: "Certifications",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationTool_ToolsId",
                table: "CertificationTool",
                column: "ToolsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_ToolCategoryId",
                table: "Tools",
                column: "ToolCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_WorkshopId",
                table: "Tools",
                column: "WorkshopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingTools");

            migrationBuilder.DropTable(
                name: "CertificationTool");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "ToolCategories");

            migrationBuilder.DropTable(
                name: "Workshops");
        }
    }
}
