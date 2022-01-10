using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainServices.Migrations
{
    public partial class o : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeRatings_Anime_AnimeId1",
                table: "AnimeRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AnimeRatings_AnimeRatingId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Anime_AnimeId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId1",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "AnimeRatingScore");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AnimeId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AnimeRatingId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AnimeRatings_AnimeId1",
                table: "AnimeRatings");

            migrationBuilder.DropColumn(
                name: "AnimeId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AnimeRatingId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AnimeId1",
                table: "AnimeRatings");

            migrationBuilder.DropColumn(
                name: "ScoreId",
                table: "AnimeRatings");

            migrationBuilder.AlterColumn<int>(
                name: "AnimeId",
                table: "Genres",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Genres",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "AnimeId",
                table: "FollowedAnime",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FollowedAnime",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Comments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "LastWatchedAnimeId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AnimeRatings",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AnimeRatings",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "AnimeRatings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Anime",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimeId",
                table: "Comments",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeRatings_AnimeId",
                table: "AnimeRatings",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeRatings_UserId",
                table: "AnimeRatings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeRatings_Anime_AnimeId",
                table: "AnimeRatings",
                column: "AnimeId",
                principalTable: "Anime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeRatings_AspNetUsers_UserId",
                table: "AnimeRatings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Anime_AnimeId",
                table: "Comments",
                column: "AnimeId",
                principalTable: "Anime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeRatings_Anime_AnimeId",
                table: "AnimeRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeRatings_AspNetUsers_UserId",
                table: "AnimeRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Anime_AnimeId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AnimeId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_AnimeRatings_AnimeId",
                table: "AnimeRatings");

            migrationBuilder.DropIndex(
                name: "IX_AnimeRatings_UserId",
                table: "AnimeRatings");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "AnimeRatings");

            migrationBuilder.AlterColumn<long>(
                name: "AnimeId",
                table: "Genres",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Genres",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "AnimeId",
                table: "FollowedAnime",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "FollowedAnime",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Comments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "AnimeId1",
                table: "Comments",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Comments",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LastWatchedAnimeId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AnimeRatingId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AnimeRatings",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AnimeRatings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "AnimeId1",
                table: "AnimeRatings",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScoreId",
                table: "AnimeRatings",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Anime",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeRatingScore",
                columns: table => new
                {
                    AnimeRatingsId = table.Column<long>(type: "bigint", nullable: false),
                    ScoresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeRatingScore", x => new { x.AnimeRatingsId, x.ScoresId });
                    table.ForeignKey(
                        name: "FK_AnimeRatingScore_AnimeRatings_AnimeRatingsId",
                        column: x => x.AnimeRatingsId,
                        principalTable: "AnimeRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeRatingScore_Scores_ScoresId",
                        column: x => x.ScoresId,
                        principalTable: "Scores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimeId1",
                table: "Comments",
                column: "AnimeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId1",
                table: "Comments",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AnimeRatingId",
                table: "AspNetUsers",
                column: "AnimeRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeRatings_AnimeId1",
                table: "AnimeRatings",
                column: "AnimeId1");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeRatingScore_ScoresId",
                table: "AnimeRatingScore",
                column: "ScoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeRatings_Anime_AnimeId1",
                table: "AnimeRatings",
                column: "AnimeId1",
                principalTable: "Anime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AnimeRatings_AnimeRatingId",
                table: "AspNetUsers",
                column: "AnimeRatingId",
                principalTable: "AnimeRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Anime_AnimeId1",
                table: "Comments",
                column: "AnimeId1",
                principalTable: "Anime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId1",
                table: "Comments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
