using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranscriptApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Blob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "FileUpload",
                table: "FinalApprovedResults",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FinalApprovedResults",
                keyColumn: "FileUpload",
                keyValue: null,
                column: "FileUpload",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FileUpload",
                table: "FinalApprovedResults",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
