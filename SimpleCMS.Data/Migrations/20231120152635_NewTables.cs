using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c68082b0-9474-46bf-aca9-332626444635", "a525f9ed-fbbe-41b9-afd5-774664d714be" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c68082b0-9474-46bf-aca9-332626444635");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a525f9ed-fbbe-41b9-afd5-774664d714be");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleFiles_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleFiles_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b2e3bc1-ebce-42b3-8daf-3efc16731c9e", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "01fb0d8e-41b3-4937-a9ca-afe415ed54c1", 0, "bbbbb4dd-263a-4d1e-9b44-e2a6f0966d91", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", 0, "AQAAAAIAAYagAAAAEPmc+rjY61Dn7igx136Ec3kwhw3yUVZ9CIj7XidrojKQk1N7NY6zl9hEsdbR6RFi9A==", "1234567890", false, "539ee5bd-bd89-49a0-bf27-3cb3de50fb15", false, "admin@simplecms.net" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9b2e3bc1-ebce-42b3-8daf-3efc16731c9e", "01fb0d8e-41b3-4937-a9ca-afe415ed54c1" });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleFiles_ArticleId",
                table: "ArticleFiles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleFiles_FileId",
                table: "ArticleFiles",
                column: "FileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleFiles");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9b2e3bc1-ebce-42b3-8daf-3efc16731c9e", "01fb0d8e-41b3-4937-a9ca-afe415ed54c1" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9b2e3bc1-ebce-42b3-8daf-3efc16731c9e");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "01fb0d8e-41b3-4937-a9ca-afe415ed54c1");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c68082b0-9474-46bf-aca9-332626444635", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a525f9ed-fbbe-41b9-afd5-774664d714be", 0, "e8f68bf6-40ba-4456-bbd7-d751e0b64351", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", 0, "AQAAAAIAAYagAAAAEApzlpmy0aMuygE5j8a7ZdRnusfl+ZJoO/z1MIHlhg+CLoizNy1Nw8axFy3iz7lSGg==", "1234567890", false, "1774fde8-e2a3-4660-a61f-33fd325e7c1a", false, "admin@simplecms.net" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c68082b0-9474-46bf-aca9-332626444635", "a525f9ed-fbbe-41b9-afd5-774664d714be" });
        }
    }
}
