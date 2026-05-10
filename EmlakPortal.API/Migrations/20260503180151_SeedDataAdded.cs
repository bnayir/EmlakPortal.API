using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmlakPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Status" },
                values: new object[,]
                {
                    { 1, "Konut", false },
                    { 2, "İşyeri", false },
                    { 3, "Arsa", false },
                    { 4, "Villa", false }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "CityName" },
                values: new object[,]
                {
                    { 1, "İstanbul" },
                    { 2, "Ankara" },
                    { 3, "Antalya" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "DistrictId", "CityId", "DistrictName" },
                values: new object[,]
                {
                    { 1, 1, "Kadıköy" },
                    { 2, 1, "Beşiktaş" },
                    { 3, 3, "Muratpaşa" },
                    { 4, 3, "Konyaaltı" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "DistrictId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "DistrictId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "DistrictId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "DistrictId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityId",
                keyValue: 3);
        }
    }
}
