using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaleFashion.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyProductSizeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sizes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sizes");
        }
    }
}
