using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DinosaursShop.Migrations
{
    /// <summary>
    /// Represents details of performing the migration.
    /// </summary>
    public partial class InitialMigration : Migration
    {
        /// <summary>
        /// Upgrade database from current state to the state expected by current code migration.
        /// </summary>
        /// <param name="migrationBuilder">Migration builder.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryDescription = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Dinosaurs",
                columns: table => new
                {
                    DinosaurId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageThumbnailUrl = table.Column<string>(nullable: true),
                    IsOnSale = table.Column<bool>(nullable: false),
                    IsInStock = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinosaurs", x => x.DinosaurId);
                    table.ForeignKey(
                        name: "FK_Dinosaurs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[] { 1, "Meat eating dinosaur", "Carnivornes" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[] { 2, "Plant eating dinosaur", "Herbivores" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[] { 3, "Meat and plants eating dinosaur", "Omnivores" });

            migrationBuilder.InsertData(
                table: "Dinosaurs",
                columns: new[] { "DinosaurId", "CategoryId", "Description", "ImageThumbnailUrl", "ImageUrl", "IsInStock", "IsOnSale", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Allosaurus was a typical large theropod, having a massive skull on a short neck, a long, slightly sloping tail and reduced forelimbs. Allosaurus fragilis, the best-known species, had an average length of 8.5 m (28 ft), with the largest definitive Allosaurus specimen estimated at 9.7 meters (32 feet) long, and an estimated weight of 2.3 metric tons (2.5 short tons).", "/images/thumbnails/Allosaurus_Juvenile_Reconstruction.jpg", "/images/Allosaurus_Juvenile_Reconstruction.jpg", true, false, "Allosaurus", 1500m },
                    { 3, 1, "Velociraptor was a mid-sized dromaeosaurid, with adults measuring up to 2.07 m (6 ft 9 1⁄2 in) long, 0.5 m (1 ft 7 1⁄2 in) high at the hip, and weighing up to 15 kg (33 lb), though there is a higher estimate of 19.7 kg (43 1⁄2 lb). The skull, which grew up to 25 cm (10 in) long, is uniquely up-curved, concave on the upper surface and convex on the lower. The jaws is lined with 26–28 widely spaced teeth on each side, each more strongly serrated on the back edge than the front", "/images/thumbnails/220px-Velociraptor_Restoration.png", "/images/1024px-Velociraptor_Restoration.png", true, true, "Velociraptor", 1000m },
                    { 5, 2, "Individual Triceratops are estimated to have reached about 7.9 to 9 metres (26 to 30 ft) in length, 2.9 to 3.0 m (9.5 to 9.8 ft) in height, and 6.1 to 12.0 tonnes (13,400 to 26,500 lb) in weight. The most distinctive feature is their large skull, among the largest of all land animals.", "/images/thumbnails/220px-Knight_Triceratops.jpg", "/images/Knight_Triceratops.jpg", true, true, "Triceratops", 1500m },
                    { 6, 2, "Over the years, the mass of B. altithorax has been estimated at 35.0 metric tons (38.6 short tons),28.3 metric tons (31.2 short tons), 43.9 metric tons (48.4 short tons), 28.7 metric tons (31.6 short tons), 56.3 metric tons (62.1 short tons), and 58 metric tons (64 short tons). The length of Brachiosaurus has been estimated at 20–21 meters (66–69 ft) and 18 meters (59 ft), and its height at 9.4 meters (30 3⁄4 ft) and 12–13 meters (39–43 ft).", "/images/thumbnails/220px-Brachiosaurus_NT_new.jpg", "/images/Brachiosaurus_NT_new.jpg", true, false, "Brachiosaurus", 2500m },
                    { 2, 3, "Nomingia is a medium-sized oviraptorosaur to have been 1.7 metres (5.6 ft) long and 20 kilograms (44 lb) in weight. It is characterized by a pygostyle-like mass of five fused vertebrae at the tail end.", "/images/thumbnails/220px-Nomingia_gobiensis.png", "/images/800px-Nomingia_gobiensis.png.jpg", true, false, "Nomingia", 950m },
                    { 4, 3, "Eoraptor has a slender body that grew to about 1 metre (3 ft 3 in) in length, with an estimated weight of about 10 kilograms (22 lb). It has a lightly built skull with a slightly enlarged external naris.", "/images/thumbnails/220px-Eoraptor_NT_small.jpg", "/images/Eoraptor_NT_small.jpg", true, true, "Eoraptor", 500m },
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dinosaurs_CategoryId",
                table: "Dinosaurs",
                column: "CategoryId");
        }

        /// <summary>
        /// Remove all the changes from the current migration and revert database to the state expected
        /// by the previous migration.
        /// </summary>
        /// <param name="migrationBuilder">Migration builder.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropTable(
                name: "Dinosaurs");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
