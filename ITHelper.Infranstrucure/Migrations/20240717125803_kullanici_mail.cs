using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITHelper.Infranstrucure.Migrations
{
    /// <inheritdoc />
    public partial class kullanici_mail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KullaniciMail",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciMail",
                table: "Kullanicilar");
        }
    }
}
