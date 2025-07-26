using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHistoryAI.Data.Migrations
{
    /// <inheritdoc />
    public partial class Enit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalFigures_AspNetUsers_CreatedById",
                table: "HistoricalFigures");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "HistoricalFigures",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalFigures_AspNetUsers_CreatedById",
                table: "HistoricalFigures",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricalFigures_AspNetUsers_CreatedById",
                table: "HistoricalFigures");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "HistoricalFigures",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricalFigures_AspNetUsers_CreatedById",
                table: "HistoricalFigures",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
