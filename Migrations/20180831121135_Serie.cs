using Microsoft.EntityFrameworkCore.Migrations;

namespace serview.Migrations
{
    public partial class Serie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Serie_SerieID",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_AspNetUsers_UserId1",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Serie",
                table: "Serie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.RenameTable(
                name: "Serie",
                newName: "Series");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_UserId1",
                table: "Ratings",
                newName: "IX_Ratings_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_SerieID",
                table: "Ratings",
                newName: "IX_Ratings_SerieID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Series",
                table: "Series",
                column: "SerieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Series_SerieID",
                table: "Ratings",
                column: "SerieID",
                principalTable: "Series",
                principalColumn: "SerieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId1",
                table: "Ratings",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Series_SerieID",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId1",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Series",
                table: "Series");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.RenameTable(
                name: "Series",
                newName: "Serie");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserId1",
                table: "Rating",
                newName: "IX_Rating_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_SerieID",
                table: "Rating",
                newName: "IX_Rating_SerieID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Serie",
                table: "Serie",
                column: "SerieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Serie_SerieID",
                table: "Rating",
                column: "SerieID",
                principalTable: "Serie",
                principalColumn: "SerieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_AspNetUsers_UserId1",
                table: "Rating",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
