using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwitchAcademy.Persistence.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingTracks",
                columns: table => new
                {
                    TrainingTrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingTrackName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTracks", x => x.TrainingTrackId);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentGoogleDriveLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignmentGithubLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Others = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingTrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignment_TrainingTracks_TrainingTrackId",
                        column: x => x.TrainingTrackId,
                        principalTable: "TrainingTracks",
                        principalColumn: "TrainingTrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingTrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_TrainingTracks_TrainingTrackId",
                        column: x => x.TrainingTrackId,
                        principalTable: "TrainingTracks",
                        principalColumn: "TrainingTrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionsBanks",
                columns: table => new
                {
                    QuestionsBankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionContent = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    option1 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    option2 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    option3 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    option4 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingTrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsBanks", x => x.QuestionsBankId);
                    table.ForeignKey(
                        name: "FK_QuestionsBanks_TrainingTracks_TrainingTrackId",
                        column: x => x.TrainingTrackId,
                        principalTable: "TrainingTracks",
                        principalColumn: "TrainingTrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    IsCompletedNysc = table.Column<bool>(type: "bit", nullable: false),
                    IsExperienced = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: true),
                    TimeTaken = table.Column<int>(type: "int", nullable: true),
                    TrainingTrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_TrainingTracks_TrainingTrackId",
                        column: x => x.TrainingTrackId,
                        principalTable: "TrainingTracks",
                        principalColumn: "TrainingTrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_TrainingTrackId",
                table: "Assignment",
                column: "TrainingTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TrainingTrackId",
                table: "Notifications",
                column: "TrainingTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsBanks_TrainingTrackId",
                table: "QuestionsBanks",
                column: "TrainingTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TrainingTrackId",
                table: "Users",
                column: "TrainingTrackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "QuestionsBanks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TrainingTracks");
        }
    }
}
