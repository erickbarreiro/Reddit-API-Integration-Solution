using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedditAPI.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subreddits",
                columns: table => new
                {
                    SubredditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subreddits", x => x.SubredditId);
                });

            migrationBuilder.CreateTable(
                name: "FetchHistories",
                columns: table => new
                {
                    FetchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubredditId = table.Column<int>(type: "int", nullable: false),
                    FetchDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FetchHistories", x => x.FetchId);
                    table.ForeignKey(
                        name: "FK_FetchHistories_Subreddits_SubredditId",
                        column: x => x.SubredditId,
                        principalTable: "Subreddits",
                        principalColumn: "SubredditId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubredditId = table.Column<int>(type: "int", nullable: false),
                    FetchDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Subreddits_SubredditId",
                        column: x => x.SubredditId,
                        principalTable: "Subreddits",
                        principalColumn: "SubredditId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FetchHistories_SubredditId",
                table: "FetchHistories",
                column: "SubredditId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SubredditId",
                table: "Posts",
                column: "SubredditId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FetchHistories");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Subreddits");
        }
    }
}
