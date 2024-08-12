using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITHelper.Infranstrucure.Migrations
{
    /// <inheritdoc />
    public partial class kullanici_aktifligi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KullaniciŞifresi",
                table: "Kullanicilar",
                newName: "KullaniciSifresi");

            migrationBuilder.AddColumn<bool>(
                name: "KullaniciAktifligi",
                table: "Kullanicilar",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciAktifligi",
                table: "Kullanicilar");

            migrationBuilder.RenameColumn(
                name: "KullaniciSifresi",
                table: "Kullanicilar",
                newName: "KullaniciŞifresi");
        }
    }
}
