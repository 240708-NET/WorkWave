using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repo.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardUser_Board_BoardsID",
                table: "BoardUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CardTag_Card_CardsID",
                table: "CardTag");

            migrationBuilder.DropForeignKey(
                name: "FK_CardTag_Tag_TagsID",
                table: "CardTag");

            migrationBuilder.DropForeignKey(
                name: "FK_CardUser_Card_CardsID",
                table: "CardUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Board",
                table: "Board");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "Cards");

            migrationBuilder.RenameTable(
                name: "Board",
                newName: "Boards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boards",
                table: "Boards",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SectionID",
                table: "Cards",
                column: "SectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardUser_Boards_BoardsID",
                table: "BoardUser",
                column: "BoardsID",
                principalTable: "Boards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Sections_SectionID",
                table: "Cards",
                column: "SectionID",
                principalTable: "Sections",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardTag_Cards_CardsID",
                table: "CardTag",
                column: "CardsID",
                principalTable: "Cards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardTag_Tags_TagsID",
                table: "CardTag",
                column: "TagsID",
                principalTable: "Tags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardUser_Cards_CardsID",
                table: "CardUser",
                column: "CardsID",
                principalTable: "Cards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardUser_Boards_BoardsID",
                table: "BoardUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Sections_SectionID",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_CardTag_Cards_CardsID",
                table: "CardTag");

            migrationBuilder.DropForeignKey(
                name: "FK_CardTag_Tags_TagsID",
                table: "CardTag");

            migrationBuilder.DropForeignKey(
                name: "FK_CardUser_Cards_CardsID",
                table: "CardUser");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_SectionID",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boards",
                table: "Boards");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Card");

            migrationBuilder.RenameTable(
                name: "Boards",
                newName: "Board");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Board",
                table: "Board",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardUser_Board_BoardsID",
                table: "BoardUser",
                column: "BoardsID",
                principalTable: "Board",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardTag_Card_CardsID",
                table: "CardTag",
                column: "CardsID",
                principalTable: "Card",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardTag_Tag_TagsID",
                table: "CardTag",
                column: "TagsID",
                principalTable: "Tag",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardUser_Card_CardsID",
                table: "CardUser",
                column: "CardsID",
                principalTable: "Card",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
