using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITHelper.Infranstrucure.Migrations
{
    /// <inheritdoc />
    public partial class blogEtiketDuzeltme : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogEtiketler",
                table: "BlogEtiketler");

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

            migrationBuilder.AddColumn<int>(
                name: "BlogEtiketID",
                table: "BlogEtiketler",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogEtiketler",
                table: "BlogEtiketler",
                column: "BlogEtiketID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogEtiketler_BlogID",
                table: "BlogEtiketler",
                column: "BlogID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogEtiketler_Blog_BlogID",
                table: "BlogEtiketler");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogEtiketler_Etiketler_EtiketID",
                table: "BlogEtiketler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogEtiketler",
                table: "BlogEtiketler");

            migrationBuilder.DropIndex(
                name: "IX_BlogEtiketler_BlogID",
                table: "BlogEtiketler");

            migrationBuilder.DropColumn(
                name: "BlogEtiketID",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogEtiketler",
                table: "BlogEtiketler",
                columns: new[] { "BlogID", "EtiketID" });

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
    }
}
