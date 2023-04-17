using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MF_DataAccess.Migrations
{
    public partial class AddingGenderTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "CustomerForms",
                newName: "GenderTypeId");

            migrationBuilder.CreateTable(
                name: "GenderType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerForms_GenderTypeId",
                table: "CustomerForms",
                column: "GenderTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerForms_GenderType_GenderTypeId",
                table: "CustomerForms",
                column: "GenderTypeId",
                principalTable: "GenderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerForms_GenderType_GenderTypeId",
                table: "CustomerForms");

            migrationBuilder.DropTable(
                name: "GenderType");

            migrationBuilder.DropIndex(
                name: "IX_CustomerForms_GenderTypeId",
                table: "CustomerForms");

            migrationBuilder.RenameColumn(
                name: "GenderTypeId",
                table: "CustomerForms",
                newName: "Gender");
        }
    }
}
