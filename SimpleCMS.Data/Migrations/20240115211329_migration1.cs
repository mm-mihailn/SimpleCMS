using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6bb36cb-f8bf-47cd-98df-f707c2e57b88", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a74293cb-c060-43b0-9767-ea2cdc68c59d", 0, "a5ea3eb4-7123-44d2-81e6-561f45c0406b", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAEN7SfbeVcBlwwR95g8+x9FvXxJRkhka5nCnz1l7YTyG6Y7gVy8a2B6j/20byyORuBg==", "1234567890", false, "cada3f11-4c1d-4d70-a2dd-69f2b2561898", false, "admin@simplecms.net" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b6bb36cb-f8bf-47cd-98df-f707c2e57b88", "a74293cb-c060-43b0-9767-ea2cdc68c59d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b6bb36cb-f8bf-47cd-98df-f707c2e57b88", "a74293cb-c060-43b0-9767-ea2cdc68c59d" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b6bb36cb-f8bf-47cd-98df-f707c2e57b88");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a74293cb-c060-43b0-9767-ea2cdc68c59d");

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
