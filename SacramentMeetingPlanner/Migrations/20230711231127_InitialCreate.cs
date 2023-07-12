using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    MeetingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Presiding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conducting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Invocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Benediction = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.MeetingId);
                });

            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    HymnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HymnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HymnType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HymnPage = table.Column<int>(type: "int", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.HymnId);
                    table.ForeignKey(
                        name: "FK_Hymn_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "MeetingId");
                });

            migrationBuilder.CreateTable(
                name: "Talk",
                columns: table => new
                {
                    TalkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    TalkType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeakerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talk", x => x.TalkId);
                    table.ForeignKey(
                        name: "FK_Talk_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hymn_MeetingId",
                table: "Hymn",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Talk_MeetingId",
                table: "Talk",
                column: "MeetingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hymn");

            migrationBuilder.DropTable(
                name: "Talk");

            migrationBuilder.DropTable(
                name: "Meeting");
        }
    }
}
