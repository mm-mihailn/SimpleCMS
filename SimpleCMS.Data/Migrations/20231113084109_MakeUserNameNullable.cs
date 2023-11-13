using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeUserNameNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0b328320-154a-4b7e-bb12-98316b5db3df", "3a4db87a-086c-4def-8339-420ef138b8dc" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0b328320-154a-4b7e-bb12-98316b5db3df");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3a4db87a-086c-4def-8339-420ef138b8dc");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a48d5b89-e3d1-45e4-8c54-f3e63f22a301", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cb8719fc-fa56-4fc7-87eb-af260df197c5", 0, "941f048d-72c6-4119-8fe7-963149a60b63", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAEJsb5IbTGlAEsnmi0viWJEoz0rfEny2MVsJoydkDcUf5G1Lr4LVpXALO+qATmGwu5Q==", "1234567890", false, "054aaa3a-acc8-4ac6-8e32-4cf80eebbea6", false, "admin@simplecms.net" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a48d5b89-e3d1-45e4-8c54-f3e63f22a301", "cb8719fc-fa56-4fc7-87eb-af260df197c5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a48d5b89-e3d1-45e4-8c54-f3e63f22a301", "cb8719fc-fa56-4fc7-87eb-af260df197c5" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a48d5b89-e3d1-45e4-8c54-f3e63f22a301");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "cb8719fc-fa56-4fc7-87eb-af260df197c5");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b328320-154a-4b7e-bb12-98316b5db3df", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3a4db87a-086c-4def-8339-420ef138b8dc", 0, "c9670a06-a4f5-494a-ade4-d74f3fce96eb", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAEOIe7gWF9NUJJwQy9pIkxwET0euiWuOEytyL2Eoib0Hut1CX4WfkatxIB8hbd6/xXA==", "1234567890", false, "3d8f71f9-ca6f-46ba-88fb-3bfed464b117", false, "admin@simplecms.net" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0b328320-154a-4b7e-bb12-98316b5db3df", "3a4db87a-086c-4def-8339-420ef138b8dc" });
        }
    }
}
