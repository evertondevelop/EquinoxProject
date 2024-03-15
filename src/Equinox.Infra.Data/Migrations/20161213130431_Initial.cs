using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Equinox.Infra.Data.Migrations
{
    /// <summary>
    /// This class represents the initial migration for the Customers table.
    /// </summary>
    public partial class Initial : Migration
    {
        /// <summary>
        /// This method is called when the migration is applied to the database.
        /// It creates a new table called Customers.
        /// </summary>
        /// <param name="migrationBuilder">The migration builder instance.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers", // The name of the new table.
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false), // The Id column, which is a unique identifier for each customer.
                    BirthDate = table.Column<DateTime>(nullable: false), // The BirthDate column, which stores the customer's date of birth.
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 11, nullable: false), // The Email column, which stores the customer's email address.
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false) // The Name column, which stores the customer's name.
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id); // Sets the Id column as the primary key of the Customers table.
                });
        }

        /// <summary>
        /// This method is called when the migration is rolled back.
        /// It drops the Customers table from the database.
        /// </summary>
        /// <param name="migrationBuilder">The migration builder instance.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(

