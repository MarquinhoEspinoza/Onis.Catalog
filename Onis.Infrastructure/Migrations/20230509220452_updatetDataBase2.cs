using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetDataBase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogItems_CatalogBrands_CatalogBrandId",
                table: "CatalogItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalogItems_CatalogTypes_CatalogTypeId",
                table: "CatalogItems");

            migrationBuilder.AlterColumn<int>(
                name: "CatalogTypeId",
                table: "CatalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CatalogBrandId",
                table: "CatalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogItems_CatalogBrands_CatalogBrandId",
                table: "CatalogItems",
                column: "CatalogBrandId",
                principalTable: "CatalogBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogItems_CatalogTypes_CatalogTypeId",
                table: "CatalogItems",
                column: "CatalogTypeId",
                principalTable: "CatalogTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogItems_CatalogBrands_CatalogBrandId",
                table: "CatalogItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalogItems_CatalogTypes_CatalogTypeId",
                table: "CatalogItems");

            migrationBuilder.AlterColumn<int>(
                name: "CatalogTypeId",
                table: "CatalogItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CatalogBrandId",
                table: "CatalogItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogItems_CatalogBrands_CatalogBrandId",
                table: "CatalogItems",
                column: "CatalogBrandId",
                principalTable: "CatalogBrands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogItems_CatalogTypes_CatalogTypeId",
                table: "CatalogItems",
                column: "CatalogTypeId",
                principalTable: "CatalogTypes",
                principalColumn: "Id");
        }
    }
}
