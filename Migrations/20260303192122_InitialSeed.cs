using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tools_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tools_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "DeWalt" },
                    { 2, "Milwaukee" },
                    { 3, "Makita" },
                    { 4, "Bosch" },
                    { 5, "Ryobi" },
                    { 6, "Craftsman" },
                    { 7, "Ridgid" },
                    { 8, "Black+Decker" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Hand Tools" },
                    { 2, "Power Drills" },
                    { 3, "Saws" },
                    { 4, "Sanders & Grinders" },
                    { 5, "Measuring Tools" },
                    { 6, "Fastening Tools" }
                });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "ID", "BrandID", "CategoryID", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, "Claw Hammer 16oz", 24.989999999999998 },
                    { 2, 2, 1, "Claw Hammer 20oz", 34.990000000000002 },
                    { 3, 6, 1, "Adjustable Wrench", 19.989999999999998 },
                    { 4, 4, 1, "Pliers Set (3-piece)", 39.990000000000002 },
                    { 5, 8, 1, "Screwdriver Set (8-piece)", 29.989999999999998 },
                    { 6, 5, 1, "Utility Knife Folding", 14.99 },
                    { 7, 1, 2, "20V Cordless Drill/Driver", 129.0 },
                    { 8, 2, 2, "M18 Fuel Hammer Drill", 229.0 },
                    { 9, 3, 2, "18V LXT Brushless Drill", 189.0 },
                    { 10, 4, 2, "18V Compact Drill", 99.0 },
                    { 11, 5, 2, "ONE+ 18V Cordless Drill", 79.0 },
                    { 12, 1, 3, "7-1/4 Circular Saw", 149.0 },
                    { 13, 2, 3, "M18 Fuel Circular Saw 7-1/4", 279.0 },
                    { 14, 3, 3, "6-1/2 Circular Saw Compact", 119.0 },
                    { 15, 4, 3, "Jigsaw Variable Speed", 89.989999999999995 },
                    { 16, 5, 3, "Reciprocating Saw 18V", 129.0 },
                    { 17, 1, 4, "Random Orbital Sander", 79.989999999999995 },
                    { 18, 2, 4, "M18 Orbital Sander", 149.0 },
                    { 19, 4, 4, "4-1/2 Angle Grinder", 69.989999999999995 },
                    { 20, 3, 4, "Cordless Angle Grinder 18V", 119.0 },
                    { 21, 1, 5, "25ft Tape Measure", 19.989999999999998 },
                    { 22, 4, 5, "Laser Distance Measurer 165ft", 89.989999999999995 },
                    { 23, 6, 5, "Digital Caliper", 39.990000000000002 },
                    { 24, 1, 6, "Impact Driver 20V", 149.0 },
                    { 25, 2, 6, "M18 Fuel Impact Driver", 199.0 },
                    { 26, 3, 6, "Brad Nailer 18Ga Cordless", 269.0 },
                    { 27, 5, 6, "18V Cordless Stapler", 99.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tools_BrandID",
                table: "Tools",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_CategoryID",
                table: "Tools",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
