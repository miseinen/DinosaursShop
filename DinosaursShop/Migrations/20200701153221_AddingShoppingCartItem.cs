using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DinosaursShop.Migrations
{
    /// <summary>
    /// Represents details of performing the migration.
    /// </summary>
    public partial class AddingShoppingCartItem : Migration
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
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<string>(nullable: true),
                    DinosaurId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Dinosaurs_DinosaurId",
                        column: x => x.DinosaurId,
                        principalTable: "Dinosaurs",
                        principalColumn: "DinosaurId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_DinosaurId",
                table: "ShoppingCartItems",
                column: "DinosaurId");
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
                name: "ShoppingCartItems");
        }
    }
}
