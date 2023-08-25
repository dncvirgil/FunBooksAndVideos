using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FunBooksAndVideosData.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MembershipTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Book Club Membership" },
                    { 2, "Video Club Membership" },
                    { 3, "Premium Club Membership" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Book" },
                    { 2, "Video" },
                    { 3, "eBook" },
                    { 4, "Membership" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "ProductTypeId", "Url" },
                values: new object[,]
                {
                    { 1, "Video description", "Video \"Comprehensive First Aid Training\"", 10m, 2, "video url" },
                    { 2, "eBook description", "eBook \"The Girl on the train\"", 16m, 3, "ebook url" },
                    { 3, "Book description", "Book \"The Girl on the train\"", 15m, 1, "book url" },
                    { 4, "Book Club description", "Book Club Membership", 5m, 4, "book memebership url" },
                    { 5, "Video Club description", "Video Club Membership", 5m, 4, "video memebership url" },
                    { 6, "Premium Club description", "Premium Club Membership", 8m, 4, "premium memebership url" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MembershipTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MembershipTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MembershipTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
