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
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_CreatedById",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CreatedById",
                table: "Articles");

           

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
