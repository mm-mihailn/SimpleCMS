using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedSubMenuItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8c24c741-010d-4045-9868-1098ac1e5e05", "b31b87f1-496e-4b93-b631-33a3a6531b45" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9ab49ddd-0059-4804-b78d-5371e6b9d1e6");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8c24c741-010d-4045-9868-1098ac1e5e05");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "Профил на купувача");

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Link", "ParentId", "Published", "Title" },
                values: new object[,]
                {
                    { 9, "test", 1, true, "Административни услуги" },
                    { 10, "test", 1, true, "Учителски състав" },
                    { 11, "test", 1, true, "История" },
                    { 12, "test", 1, true, "Новини" },
                    { 13, "test", 1, true, "Партньори и проекти" },
                    { 14, "test", 3, true, "Брошура" },
                    { 15, "test", 3, true, "Специалности" },
                    { 21, "test", 4, true, "Стипендии" },
                    { 22, "test", 4, true, "Ел. Дневник" },
                    { 23, "test", 5, true, "Изпити" },
                    { 24, "test", 5, true, "Учебници" },
                    { 25, "test", 5, true, "Седмично разписание" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c22aa1d5-6185-414f-be86-36e5c9aac53b", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "652ac0fa-4ec4-437d-89be-b49493d87217", 0, "f24aa94a-fd74-4828-88ef-18554ff1f52c", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAELDvxpW084RrBdBl+e9/35ID1Kh1/0qO8RxBegGzZSV6Kka0USyNuI1g5/R1219u5Q==", "1234567890", false, "c8aa1998-e893-454e-bbe1-5a8a2dc0b523", false, "admin@simplecms.net" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Link", "ParentId", "Published", "Title" },
                values: new object[,]
                {
                    { 16, "test", 15, true, "Приложно програмиране" },
                    { 17, "test", 15, true, "КТТ" },
                    { 18, "test", 15, true, "Електроенергетика" },
                    { 19, "test", 15, true, "Електрообзавеждане" },
                    { 20, "test", 15, true, "Роботика" },
                    { 26, "test", 23, true, "ДЗИ" },
                    { 27, "test", 23, true, "Поправителни изпити" },
                    { 28, "test", 23, true, "Самостоятелна форма" }
                });

            //migrationBuilder.InsertData(
            //    table: "UserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[] { "c22aa1d5-6185-414f-be86-36e5c9aac53b", "011a47d1-fae5-4ee4-a04b-d6bf6703aa88" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c22aa1d5-6185-414f-be86-36e5c9aac53b", "011a47d1-fae5-4ee4-a04b-d6bf6703aa88" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "652ac0fa-4ec4-437d-89be-b49493d87217");

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c22aa1d5-6185-414f-be86-36e5c9aac53b");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "Профил на куповача");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c24c741-010d-4045-9868-1098ac1e5e05", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9ab49ddd-0059-4804-b78d-5371e6b9d1e6", 0, "5f8c485a-9c37-4c1a-8bb1-f07330eba6c0", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAEP3fKU4aCUJDIw5jXQ9IrltZKP1KiECg0g034HRkFENhThVQQ48wdkHkEvwzTf+huw==", "1234567890", false, "4afd4ab1-aaae-422c-a5ce-4a81a07d9324", false, "admin@simplecms.net" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8c24c741-010d-4045-9868-1098ac1e5e05", "b31b87f1-496e-4b93-b631-33a3a6531b45" });
        }
    }
}
