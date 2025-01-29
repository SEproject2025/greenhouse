using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace greenhouse.Migrations
{
    /// <inheritdoc />
    public partial class WaterFreqField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WATER_FREQ",
                table: "Plant",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WATER_FREQ",
                table: "Plant");
        }
    }
}
