using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Equinox.Infra.Data.Migrations.EventStoreSQL
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoredEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    AggregateId = table.Column<Guid>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    Action = table.Column<string>(type: "varchar(100)", nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredEvents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoredEvents");
        }
    }
}
