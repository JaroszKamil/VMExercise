using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "varchar(5)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => new { x.CustomerId, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "varchar(5)", nullable: false),
                    AddressType = table.Column<string>(type: "varchar(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ZIP = table.Column<string>(type: "varchar(20)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Country = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => new { x.CustomerId, x.AddressType });
                    table.ForeignKey(
                        name: "FK_Address_Customer_CustomerId_Name",
                        columns: x => new { x.CustomerId, x.Name },
                        principalTable: "Customer",
                        principalColumns: new[] { "CustomerId", "Name" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId_Name",
                table: "Address",
                columns: new[] { "CustomerId", "Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
