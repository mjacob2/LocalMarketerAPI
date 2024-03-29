﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DealHasNoSellerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerFullName",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Deals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerFullName",
                table: "Deals",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Deals",
                type: "int",
                maxLength: 150,
                nullable: false,
                defaultValue: 0);
        }
    }
}
