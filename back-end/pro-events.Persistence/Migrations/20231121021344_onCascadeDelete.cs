using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pro_events.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class onCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Events_EventId",
                table: "Socials");

            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Speakers_SpeakerId",
                table: "Socials");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Socials",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Events_EventId",
                table: "Socials",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Speakers_SpeakerId",
                table: "Socials",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Events_EventId",
                table: "Socials");

            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Speakers_SpeakerId",
                table: "Socials");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Socials",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Events_EventId",
                table: "Socials",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Speakers_SpeakerId",
                table: "Socials",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id");
        }
    }
}
