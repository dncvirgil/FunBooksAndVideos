using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunBooksAndVideosData.Migrations
{
    /// <inheritdoc />
    public partial class remove_unique_product_name_index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_Product_Name",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "Index_Product_Name",
                table: "Products",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_Product_Name",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "Index_Product_Name",
                table: "Products",
                column: "Name",
                unique: true);
        }
    }
}
