using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperHeros.Data.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Superheros",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Alter_Ego = table.Column<string>(nullable: true),
                    Primary_Ability = table.Column<string>(nullable: true),
                    Secondary_Ability = table.Column<string>(nullable: true),
                    Catchphrase = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superheros", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Superheros");
        }
    }
}
