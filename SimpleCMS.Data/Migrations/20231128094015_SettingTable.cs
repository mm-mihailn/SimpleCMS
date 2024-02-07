using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class SettingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9ba28c4d-fe1c-4f8b-a7ef-c1081c9823a9", "83651fd9-a992-4644-9dff-437dfe02c30d" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9ba28c4d-fe1c-4f8b-a7ef-c1081c9823a9");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "83651fd9-a992-4644-9dff-437dfe02c30d");

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ba28c4d-fe1c-4f8b-a7ef-c1081c9823a9", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "83651fd9-a992-4644-9dff-437dfe02c30d", 0, "af78c873-8e03-4d8a-a253-ed7360621de7", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAEIJhfl2KX5bys8RJqsLvWIfcx/HqkuiqXcX2o+DiqVsf7HPnw/GSei8CkjNEVsBzJQ==", "1234567890", false, "a46c8ea8-8155-4309-9870-00c5e78c0236", false, "admin@simplecms.net" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9ba28c4d-fe1c-4f8b-a7ef-c1081c9823a9", "83651fd9-a992-4644-9dff-437dfe02c30d" });
        }
    }
}
