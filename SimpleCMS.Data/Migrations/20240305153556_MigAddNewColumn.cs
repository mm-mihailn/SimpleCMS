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
            

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

           

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Articles");

           

        }
    }
}
