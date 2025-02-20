using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace greenhouse.Migrations
{
    /// <inheritdoc />
    public partial class AddPlantTaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FERT_FREQ",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "PEST_FREQ",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "PRUNE_FREQ",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "WATER_FREQ",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "WEED_FREQ",
                table: "Plant");

            migrationBuilder.CreateTable(
                name: "PlantTasks",
                columns: table => new
                {
                    TASK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PLANT_ID = table.Column<int>(type: "int", nullable: false),
                    TASK_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FREQ = table.Column<int>(type: "int", nullable: false),
                    DAYS_UNTIL = table.Column<int>(type: "int", nullable: false),
                    IS_COMPLETED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DONE_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    OVERDUE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTasks", x => x.TASK_ID);
                    table.ForeignKey(
                        name: "FK_PlantTasks_Plant_PLANT_ID",
                        column: x => x.PLANT_ID,
                        principalTable: "Plant",
                        principalColumn: "PLANT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PlantTasks_PLANT_ID",
                table: "PlantTasks",
                column: "PLANT_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantTasks");

            migrationBuilder.AddColumn<int>(
                name: "FERT_FREQ",
                table: "Plant",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "WATER_FREQ",
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
    }
}
