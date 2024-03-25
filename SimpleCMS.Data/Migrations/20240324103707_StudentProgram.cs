using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Articles_Users_CreatedById",
            //    table: "Articles");

            //migrationBuilder.DropIndex(
            //    name: "IX_Articles_CreatedById",
            //    table: "Articles");

            //migrationBuilder.DeleteData(
            //    table: "UserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "1e3d519a-f76c-4357-aadb-cd5f5df99e7b", "626180d2-59e3-41b7-b96c-6af7be55ad62" });

            //migrationBuilder.DeleteData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: "1e3d519a-f76c-4357-aadb-cd5f5df99e7b");

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: "626180d2-59e3-41b7-b96c-6af7be55ad62");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "Files",
            //    type: "nvarchar(100)",
            //    maxLength: 100,
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(100)",
            //    oldMaxLength: 100,
            //    oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Image",
            //    table: "Articles",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            migrationBuilder.CreateTable(
                name: "StudentPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonsNumber = table.Column<int>(type: "int", nullable: false),
                    DayOfTheWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPrograms", x => x.Id);
                });

            //migrationBuilder.InsertData(
            //    table: "Roles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "898f706d-b2f9-47ee-bd95-66a7107056f4", null, "Administrator", "ADMINISTRATOR" });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[] { "c786b21a-19f6-4fa9-8c18-bdc85fe0ddff", 0, "bd9ed8da-a3da-4e3d-8dea-b306e18b864d", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAEGDR48S38E56b2wQr0t3D0IsfgSk6DPUejN0bsqteQ4U636c+dqRxVTDmHQaSXlgrA==", "1234567890", false, "8e775597-d45b-4d72-bf71-2ec8bfe0e803", false, "admin@simplecms.net" });

            //migrationBuilder.InsertData(
            //    table: "UserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[] { "898f706d-b2f9-47ee-bd95-66a7107056f4", "6f7bf916-8a44-459b-bacb-e2569efc4e1e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentPrograms");

            //migrationBuilder.DeleteData(
            //    table: "UserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "898f706d-b2f9-47ee-bd95-66a7107056f4", "6f7bf916-8a44-459b-bacb-e2569efc4e1e" });

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: "c786b21a-19f6-4fa9-8c18-bdc85fe0ddff");

            //migrationBuilder.DeleteData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: "898f706d-b2f9-47ee-bd95-66a7107056f4");

            //migrationBuilder.DropColumn(
            //    name: "Image",
            //    table: "Articles");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "Files",
            //    type: "nvarchar(100)",
            //    maxLength: 100,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(100)",
            //    oldMaxLength: 100);

            //migrationBuilder.InsertData(
            //    table: "Roles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "1e3d519a-f76c-4357-aadb-cd5f5df99e7b", null, "Administrator", "ADMINISTRATOR" });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[] { "626180d2-59e3-41b7-b96c-6af7be55ad62", 0, "e0d48dde-78d9-4f0b-af6d-e8e1c00cfd83", "admin@simplecms.net", true, false, null, "John Smith", "ADMIN@SIMPLECMS.NET", "ADMIN@SIMPLECMS.NET", "AQAAAAIAAYagAAAAEDzhpJ9GUICvAIuPiH1P9VqcSZrs+z3BCIIGGJYt3tZH6EJBCAu5LODg3TBWux3n9w==", "1234567890", false, "aa48ad4d-49d2-4d35-9469-2c82a9ff4115", false, "admin@simplecms.net" });

            //migrationBuilder.InsertData(
            //    table: "UserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[] { "1e3d519a-f76c-4357-aadb-cd5f5df99e7b", "626180d2-59e3-41b7-b96c-6af7be55ad62" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Articles_CreatedById",
            //    table: "Articles",
            //    column: "CreatedById");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Articles_Users_CreatedById",
            //    table: "Articles",
            //    column: "CreatedById",
            //    principalTable: "Users",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
