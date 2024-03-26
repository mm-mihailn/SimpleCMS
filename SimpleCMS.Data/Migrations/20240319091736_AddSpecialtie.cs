using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecialtie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_CreatedById",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CreatedById",
                table: "Articles");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3d994190-47f5-4d77-b72c-8d22b72d59f0", "83ddfc1e-4bc6-4919-8aba-d7809cf7cd20" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3d994190-47f5-4d77-b72c-8d22b72d59f0");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "83ddfc1e-4bc6-4919-8aba-d7809cf7cd20");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Files",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a84a8248-2860-449b-8c1d-e7c4379bf250", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
              table: "UserRoles",
               columns: new[] { "RoleId", "UserId" },
               values: new object[] { "a84a8248-2860-449b-8c1d-e7c4379bf250", "5f94502d-ed6a-485a-ae39-9fb2a1bc3bfc" });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_CreatedById",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CreatedById",
                table: "Articles");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a84a8248-2860-449b-8c1d-e7c4379bf250", "5f94502d-ed6a-485a-ae39-9fb2a1bc3bfc" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a84a8248-2860-449b-8c1d-e7c4379bf250");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Files",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d994190-47f5-4d77-b72c-8d22b72d59f0", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "83ddfc1e-4bc6-4919-8aba-d7809cf7cd20", 0, "45b6124b-b70d-4d63-b44f-e7ef699e6689", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAEDbfXKi+Kprz2qerZym84suGxKIu/flYDc9JhT9HPEH0MFiLi678JNSgTIFmqAdoHw==", "1234567890", false, "020e2a7f-f70b-4c35-8758-09c3ddf8ea4f", false, "admin@simplecms.net" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreatedById",
                table: "Articles",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_CreatedById",
                table: "Articles",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
