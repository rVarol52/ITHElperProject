using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITHelper.Infranstrucure.Migrations
{
    /// <inheritdoc />
    public partial class BlogokunmaSayisi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogEtiketler_Blog_BlogID",
                table: "BlogEtiketler");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogEtiketler_Etiketler_EtiketID",
                table: "BlogEtiketler");

            migrationBuilder.AlterColumn<int>(
                name: "EtiketID",
                table: "BlogEtiketler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlogID",
                table: "BlogEtiketler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OkunmaSayisi",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogEtiketler_Blog_BlogID",
                table: "BlogEtiketler",
                column: "BlogID",
                principalTable: "Blog",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogEtiketler_Etiketler_EtiketID",
                table: "BlogEtiketler",
                column: "EtiketID",
                principalTable: "Etiketler",
                principalColumn: "EtiketID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogEtiketler_Blog_BlogID",
                table: "BlogEtiketler");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogEtiketler_Etiketler_EtiketID",
                table: "BlogEtiketler");

            migrationBuilder.DropColumn(
                name: "OkunmaSayisi",
                table: "Blog");

            migrationBuilder.AlterColumn<int>(
                name: "EtiketID",
                table: "BlogEtiketler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BlogID",
                table: "BlogEtiketler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogEtiketler_Blog_BlogID",
                table: "BlogEtiketler",
                column: "BlogID",
                principalTable: "Blog",
                principalColumn: "BlogID");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogEtiketler_Etiketler_EtiketID",
                table: "BlogEtiketler",
                column: "EtiketID",
                principalTable: "Etiketler",
                principalColumn: "EtiketID");
        }
    }
}
