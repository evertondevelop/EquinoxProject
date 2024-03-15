using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Equinox.UI.Web.Data.Migrations
{
    public partial class CreateIdentitySchema : Migration // This class is a partial implementation of the Migration class for Entity Framework Core
    {
        protected override void Up(MigrationBuilder migrationBuilder) // This method is called when the migration is applied
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles", // Creates a new table named "AspNetRoles"
                columns: table => new // Defines the columns of the table
                {
                    Id = table.Column<string>(nullable: false), // Column named "Id" of type string, cannot be null
                    Name = table.Column<string>(maxLength: 256, nullable: true), // Column named "Name" of type string, with a maximum length of 256 characters, can be null
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true), // Column named "NormalizedName" of type string, with a maximum length of 256 characters, can be null
                    ConcurrencyStamp = table.Column<string>(nullable: true) // Column named "ConcurrencyStamp" of type string, can be null
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id); // Sets the primary key of the table to the "Id" column
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers", // Creates a new table named "AspNetUsers"
                columns: table => new // Defines the columns of the table
                {
                    Id = table.Column<string>(nullable: false), // Column named "Id" of type string, cannot be null
                    UserName = table.Column<string>(maxLength: 256, nullable: true), // Column named "UserName" of type string, with a maximum length of 256 characters, can be null
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true), // Column named "NormalizedUserName" of type string, with a maximum length of 256 characters, can be null
                    Email = table.Column<string>(maxLength: 256, nullable: true), // Column named "Email" of type string, with a maximum length of 256 characters, can be null
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true), // Column named "NormalizedEmail" of type string, with a maximum length of 256 characters, can be null
                    EmailConfirmed = table.Column<bool>(nullable: false), // Column named "EmailConfirmed" of type bool, cannot be null
                    PasswordHash = table.Column<string>(nullable: true), // Column named "PasswordHash" of type string, can be null
                    SecurityStamp = table.Column<string>(nullable: true), // Column named "SecurityStamp" of type string, can be null
                    ConcurrencyStamp = table.Column<string>(nullable: true), // Column named "ConcurrencyStamp" of type string, can be null
                    PhoneNumber = table.Column<string>(nullable: true), // Column named "PhoneNumber" of type string, can be null
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false), // Column named "PhoneNumberConfirmed" of type bool, cannot be null
                    TwoFactorEnabled = table.Column<bool>(nullable: false), // Column named "TwoFactorEnabled" of type bool, cannot be null
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true), // Column named "LockoutEnd" of type DateTimeOffset, can be null
                    LockoutEnabled = table.Column<bool>(nullable: false), // Column named "LockoutEnabled" of type bool, cannot be null
                    AccessFailedCount = table.Column<int>(nullable: false) // Column named "AccessFailedCount" of type int, cannot be null
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id); // Sets the primary key of the table to the "Id" column
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims", // Creates a new table named "AspNetRoleClaims"
                columns: table => new // Defines the columns of the table
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn), // Column named "Id" of type int, cannot be null, is an identity column
                    RoleId = table.Column<string>(nullable: false), // Column named "RoleId" of type string, cannot be null
                    ClaimType = table.Column<string>(nullable: true), // Column named "ClaimType" of type string, can be null
                    ClaimValue = table.Column<string>(nullable: true) // Column named "ClaimValue" of type string, can be null
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id); // Sets the primary key of the table to the "Id" column
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId", // Defines a foreign key constraint named "FK_AspNetRoleClaims_AspNetRoles_RoleId"
                        column: x => x.RoleId, // The foreign key column is "RoleId"
                        principalTable: "AspNetRoles", // The principal table is "AspNetRoles"
                        principalColumn: "Id", // The principal column is "Id"
                        onDelete: ReferentialAction.Cascade); // On delete of the principal key, cascade the delete operation
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims", // Creates a new table named "AspNetUserClaims"
                columns: table => new // Defines the columns of the table
                {
                    Id = table.Column<int>(nullable: false)
                        .
