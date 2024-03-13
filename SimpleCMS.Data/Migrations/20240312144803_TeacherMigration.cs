using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeacherMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e3d519a-f76c-4357-aadb-cd5f5df99e7b", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "626180d2-59e3-41b7-b96c-6af7be55ad62", 0, "e0d48dde-78d9-4f0b-af6d-e8e1c00cfd83", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAEDzhpJ9GUICvAIuPiH1P9VqcSZrs+z3BCIIGGJYt3tZH6EJBCAu5LODg3TBWux3n9w==", "1234567890", false, "aa48ad4d-49d2-4d35-9469-2c82a9ff4115", false, "admin@simplecms.net" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1e3d519a-f76c-4357-aadb-cd5f5df99e7b", "626180d2-59e3-41b7-b96c-6af7be55ad62" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1e3d519a-f76c-4357-aadb-cd5f5df99e7b", "626180d2-59e3-41b7-b96c-6af7be55ad62" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1e3d519a-f76c-4357-aadb-cd5f5df99e7b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "626180d2-59e3-41b7-b96c-6af7be55ad62");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d994190-47f5-4d77-b72c-8d22b72d59f0", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "83ddfc1e-4bc6-4919-8aba-d7809cf7cd20", 0, "45b6124b-b70d-4d63-b44f-e7ef699e6689", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAEDbfXKi+Kprz2qerZym84suGxKIu/flYDc9JhT9HPEH0MFiLi678JNSgTIFmqAdoHw==", "1234567890", false, "020e2a7f-f70b-4c35-8758-09c3ddf8ea4f", false, "admin@simplecms.net" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3d994190-47f5-4d77-b72c-8d22b72d59f0", "83ddfc1e-4bc6-4919-8aba-d7809cf7cd20" });
        }
    }
}
