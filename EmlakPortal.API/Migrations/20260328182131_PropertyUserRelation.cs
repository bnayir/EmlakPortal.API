using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmlakPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class PropertyUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AppUserId",
                table: "Properties",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_AspNetUsers_AppUserId",
                table: "Properties",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_AspNetUsers_AppUserId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_AppUserId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Properties");
        }
    }
}
