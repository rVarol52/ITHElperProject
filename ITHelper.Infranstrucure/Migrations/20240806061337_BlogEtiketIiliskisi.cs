using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITHelper.Infranstrucure.Migrations
{
    /// <inheritdoc />
    public partial class BlogEtiketIiliskisi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogEtiketler",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "int", nullable: false),
                    EtiketID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogEtiketler", x => new { x.BlogID, x.EtiketID });
                    table.ForeignKey(
                        name: "FK_BlogEtiketler_Blog_BlogID",
                        column: x => x.BlogID,
                        principalTable: "Blog",
                        principalColumn: "BlogID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogEtiketler_Etiketler_EtiketID",
                        column: x => x.EtiketID,
                        principalTable: "Etiketler",
                        principalColumn: "EtiketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogEtiketler_EtiketID",
                table: "BlogEtiketler",
                column: "EtiketID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogEtiketler");
        }
    }
}
