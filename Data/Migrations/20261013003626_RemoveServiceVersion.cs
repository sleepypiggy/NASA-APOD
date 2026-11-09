using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NASA_APOD.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveServiceVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceVersion",
                table: "Apods");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceVersion",
                table: "Apods",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
