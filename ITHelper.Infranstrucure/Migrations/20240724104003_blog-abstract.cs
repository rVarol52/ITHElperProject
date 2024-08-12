using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITHelper.Infranstrucure.Migrations
{
    /// <inheritdoc />
    public partial class blogabstract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "Bloglar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeTarihi",
                table: "Bloglar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKullaniciID",
                table: "Bloglar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OlusturanKullaniciID",
                table: "Bloglar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarihi",
                table: "Bloglar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Bloglar_GuncelleyenKullaniciID",
                table: "Bloglar",
                column: "GuncelleyenKullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Bloglar_OlusturanKullaniciID",
                table: "Bloglar",
                column: "OlusturanKullaniciID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bloglar_Kullanicilar_GuncelleyenKullaniciID",
                table: "Bloglar");

            migrationBuilder.DropForeignKey(
                name: "FK_Bloglar_Kullanicilar_OlusturanKullaniciID",
                table: "Bloglar");

            migrationBuilder.DropIndex(
                name: "IX_Bloglar_GuncelleyenKullaniciID",
                table: "Bloglar");

            migrationBuilder.DropIndex(
                name: "IX_Bloglar_OlusturanKullaniciID",
                table: "Bloglar");

            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "Bloglar");

            migrationBuilder.DropColumn(
                name: "GuncellemeTarihi",
                table: "Bloglar");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKullaniciID",
                table: "Bloglar");

            migrationBuilder.DropColumn(
                name: "OlusturanKullaniciID",
                table: "Bloglar");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarihi",
                table: "Bloglar");
        }
    }
}
