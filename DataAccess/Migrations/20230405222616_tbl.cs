using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class tbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "To",
                table: "Schedules",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Schedules",
                newName: "Ends");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Schedules",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "Ends",
                table: "Schedules",
                newName: "From");
        }
    }
}
