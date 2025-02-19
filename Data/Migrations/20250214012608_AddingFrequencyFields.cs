using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace greenhouse.Migrations
{
    /// <inheritdoc />
    public partial class AddingFrequencyFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PEST_FREQ",
                table: "Plant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PRUNE_FREQ",
                table: "Plant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WEED_FREQ",
                table: "Plant",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PEST_FREQ",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "PRUNE_FREQ",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "WEED_FREQ",
                table: "Plant");
        }
    }
}
