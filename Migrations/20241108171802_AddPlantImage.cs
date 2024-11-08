using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace greenhouse.Migrations
{
    /// <inheritdoc />
    public partial class AddPlantImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "IMAGE_DATA",
                table: "Plant",
                type: "longblob",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMAGE_DATA",
                table: "Plant");
        }
    }
}
