using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Database.Migrations
{
    /// <inheritdoc />
    public partial class ProductOrderUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ProductOrder",
                newName: "ProductQuantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductQuantity",
                table: "ProductOrder",
                newName: "Quantity");
        }
    }
}
