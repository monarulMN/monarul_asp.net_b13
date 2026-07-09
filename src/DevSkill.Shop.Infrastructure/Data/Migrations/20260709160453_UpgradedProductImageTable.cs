using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSkill.Shop.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpgradedProductImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "ProductImages");
        }
    }
}
