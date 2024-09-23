using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCM.API.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Fullname = table.Column<string>(type: "text", nullable: false),
                    UserImage = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Fullname", "LastLogin", "Password", "Role", "UserImage", "Username", "createdAt", "isActive" },
                values: new object[] { new Guid("33e492b2-c141-4fe4-a512-a8bc30e4cbc9"), "wsumardji@yahoo.com", "Super User", new DateTime(2024, 8, 30, 17, 40, 26, 413, DateTimeKind.Local).AddTicks(2031), "sangkanayu", "admin", null, "admin", new DateTime(2024, 8, 30, 17, 40, 26, 413, DateTimeKind.Local).AddTicks(2032), true });

            migrationBuilder.InsertData(
                table: "Profile",
                columns: new[] { "Id", "Address", "Age", "Gender", "Mobile", "UserId" },
                values: new object[] { new Guid("4cb3adc1-d18b-4e50-b486-e5f982be29e8"), "Jl. Mampang prapatan XIV No. 30", "47", "Male", "08176349999", new Guid("33e492b2-c141-4fe4-a512-a8bc30e4cbc9") });

            migrationBuilder.CreateIndex(
                name: "IX_Profile_UserId",
                table: "Profile",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
