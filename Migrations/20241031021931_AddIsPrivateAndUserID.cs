using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace greenhouse.Migrations
{
    /// <inheritdoc />
    public partial class AddIsPrivateAndUserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlantName",
                table: "Plant",
                newName: "PLANT_NAME");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                table: "Plant",
                newName: "PLANT_ID");

            migrationBuilder.AddColumn<string>(
                name: "IS_PRIVATE",
                table: "Plant",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "USER_ID",
                table: "Plant",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_PRIVATE",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "USER_ID",
                table: "Plant");

            migrationBuilder.RenameColumn(
                name: "PLANT_NAME",
                table: "Plant",
                newName: "PlantName");

            migrationBuilder.RenameColumn(
                name: "PLANT_ID",
                table: "Plant",
                newName: "PlantId");
        }
    }
}
