using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pro_events.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changincolumntitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "AspNetUsers",
                newName: "Degree");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "AspNetUsers",
                newName: "Title");
        }
    }
}
