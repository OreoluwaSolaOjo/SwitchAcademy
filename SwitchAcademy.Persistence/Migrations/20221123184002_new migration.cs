using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwitchAcademy.Persistence.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasTakenExam",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasTakenExam",
                table: "Users");
        }
    }
}
