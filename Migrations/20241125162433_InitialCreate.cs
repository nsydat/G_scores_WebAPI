using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G_Scores.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sbd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    toan = table.Column<double>(type: "float", nullable: true),
                    ngu_van = table.Column<double>(type: "float", nullable: true),
                    ngoai_ngu = table.Column<double>(type: "float", nullable: true),
                    vat_li = table.Column<double>(type: "float", nullable: true),
                    hoa_hoc = table.Column<double>(type: "float", nullable: true),
                    sinh_hoc = table.Column<double>(type: "float", nullable: true),
                    lich_su = table.Column<double>(type: "float", nullable: true),
                    dia_li = table.Column<double>(type: "float", nullable: true),
                    gdcd = table.Column<double>(type: "float", nullable: true),
                    ma_ngoai_ngu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_dia_li",
                table: "Students",
                column: "dia_li");

            migrationBuilder.CreateIndex(
                name: "IX_Students_gdcd",
                table: "Students",
                column: "gdcd");

            migrationBuilder.CreateIndex(
                name: "IX_Students_hoa_hoc",
                table: "Students",
                column: "hoa_hoc");

            migrationBuilder.CreateIndex(
                name: "IX_Students_lich_su",
                table: "Students",
                column: "lich_su");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ngoai_ngu",
                table: "Students",
                column: "ngoai_ngu");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ngu_van",
                table: "Students",
                column: "ngu_van");

            migrationBuilder.CreateIndex(
                name: "IX_Students_sinh_hoc",
                table: "Students",
                column: "sinh_hoc");

            migrationBuilder.CreateIndex(
                name: "IX_Students_toan",
                table: "Students",
                column: "toan");

            migrationBuilder.CreateIndex(
                name: "IX_Students_vat_li",
                table: "Students",
                column: "vat_li");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
