using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITHelper.Infranstrucure.Migrations
{
    /// <inheritdoc />
    public partial class ozetbloglar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bloglar_Kullanicilar_GuncelleyenKullaniciID",
                table: "Bloglar");

            migrationBuilder.DropForeignKey(
                name: "FK_Bloglar_Kullanicilar_OlusturanKullaniciID",
                table: "Bloglar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bloglar",
                table: "Bloglar");

            migrationBuilder.RenameTable(
                name: "Bloglar",
                newName: "Blog");

            migrationBuilder.RenameIndex(
                name: "IX_Bloglar_OlusturanKullaniciID",
                table: "Blog",
                newName: "IX_Blog_OlusturanKullaniciID");

            migrationBuilder.RenameIndex(
                name: "IX_Bloglar_GuncelleyenKullaniciID",
                table: "Blog",
                newName: "IX_Blog_GuncelleyenKullaniciID");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciSoyadi",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciSifresi",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciMail",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciAdi",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Icerik",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Baslik",
                table: "Blog",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Ozet",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "BlogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Kullanicilar_GuncelleyenKullaniciID",
                table: "Blog",
                column: "GuncelleyenKullaniciID",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Kullanicilar_OlusturanKullaniciID",
                table: "Blog",
                column: "OlusturanKullaniciID",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Kullanicilar_GuncelleyenKullaniciID",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Kullanicilar_OlusturanKullaniciID",
                table: "Blog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Ozet",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "Bloglar");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_OlusturanKullaniciID",
                table: "Bloglar",
                newName: "IX_Bloglar_OlusturanKullaniciID");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_GuncelleyenKullaniciID",
                table: "Bloglar",
                newName: "IX_Bloglar_GuncelleyenKullaniciID");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciSoyadi",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciSifresi",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciMail",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciAdi",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Icerik",
                table: "Bloglar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Baslik",
                table: "Bloglar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bloglar",
                table: "Bloglar",
                column: "BlogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bloglar_Kullanicilar_GuncelleyenKullaniciID",
                table: "Bloglar",
                column: "GuncelleyenKullaniciID",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bloglar_Kullanicilar_OlusturanKullaniciID",
                table: "Bloglar",
                column: "OlusturanKullaniciID",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciID");
        }
    }
}
