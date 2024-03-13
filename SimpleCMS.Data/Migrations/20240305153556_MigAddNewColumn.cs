using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigAddNewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bbfc51c6-64f0-4f20-81ed-d1231c5705ad", "c625ca2a-68c4-437d-b2d8-247afee5d10a" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "633df66d-b7d1-4efb-ac5e-1f5228e4971c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bbfc51c6-64f0-4f20-81ed-d1231c5705ad");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6c98092-19e6-479f-bc67-a6c7dd2b838f", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e9e6f77d-91c4-425a-9fd0-940b718a2c39", 0, "d90df42e-86b0-4c87-9a59-0897578fd11c", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAEDJeuJk1/qfGTpFPT4kCmh/QZcwcrT0MfZ0WP0zMTUbxABryAeU+j7xE5tKTNZJ5sA==", "1234567890", false, "2cb477a5-332e-4792-bba5-2b531fbef590", false, "admin@simplecms.net" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b6c98092-19e6-479f-bc67-a6c7dd2b838f", "cbda24e6-ed16-4481-9dfb-644e6ac82187" });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b6c98092-19e6-479f-bc67-a6c7dd2b838f", "cbda24e6-ed16-4481-9dfb-644e6ac82187" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e9e6f77d-91c4-425a-9fd0-940b718a2c39");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b6c98092-19e6-479f-bc67-a6c7dd2b838f");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bbfc51c6-64f0-4f20-81ed-d1231c5705ad", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "633df66d-b7d1-4efb-ac5e-1f5228e4971c", 0, "f5abbbad-d0ab-487c-afcc-9ec2813782ae", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAEPJUgxKCiq3VRIPrnGBODblstHGIusXmf7wdY8qKMXeTufXRS8G/RlFqmHG5mlA3Bw==", "1234567890", false, "09259523-b674-46d7-b736-f48ba91372a7", false, "admin@simplecms.net" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bbfc51c6-64f0-4f20-81ed-d1231c5705ad", "c625ca2a-68c4-437d-b2d8-247afee5d10a" });

        }
    }
}
