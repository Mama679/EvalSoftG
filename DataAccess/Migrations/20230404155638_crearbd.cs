using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class crearbd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Last_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ssn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
