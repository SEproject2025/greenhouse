using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace greenhouse.Migrations
{
    /// <inheritdoc />
    public partial class RenameCurrentDayField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "relative_current_day",
                table: "AspNetUsers",
                newName: "UserCurrentDay");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserCurrentDay",
                table: "AspNetUsers",
                newName: "relative_current_day");
        }
    }
}
