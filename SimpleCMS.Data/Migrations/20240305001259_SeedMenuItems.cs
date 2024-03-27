using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMenuItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

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

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Link", "ParentId", "Published", "Title" },
                values: new object[,]
                {
                    { 1, "test", null, true, "Училище" },
                    { 2, "test", null, true, "Начало" },
                    { 3, "test", null, true, "Прием" },
                    { 4, "test", null, true, "За Родителя" },
                    { 5, "test", null, true, "За Ученика" },
                    { 6, "test", null, true, "Контакти" },
                    { 7, "test", null, true, "Галерия" },
                    { 8, "test", null, true, "Профил на куповача" }
                });

            //migrationBuilder.InsertData(
            //    table: "Roles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "8c24c741-010d-4045-9868-1098ac1e5e05", null, "Administrator", "ADMINISTRATOR" });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[] { "9ab49ddd-0059-4804-b78d-5371e6b9d1e6", 0, "5f8c485a-9c37-4c1a-8bb1-f07330eba6c0", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAEP3fKU4aCUJDIw5jXQ9IrltZKP1KiECg0g034HRkFENhThVQQ48wdkHkEvwzTf+huw==", "1234567890", false, "4afd4ab1-aaae-422c-a5ce-4a81a07d9324", false, "admin@simplecms.net" });

            //migrationBuilder.InsertData(
            //    table: "UserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[] { "8c24c741-010d-4045-9868-1098ac1e5e05", "b31b87f1-496e-4b93-b631-33a3a6531b45" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8);


            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Files",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

        }
    }
}
