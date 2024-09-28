using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaNet.Backend.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrators_Institutions_InstitutionId",
                table: "Administrators");

            migrationBuilder.DropIndex(
                name: "IX_Administrators_InstitutionId_Name",
                table: "Administrators");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Administrators");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstitutionId",
                table: "Administrators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_InstitutionId_Name",
                table: "Administrators",
                columns: new[] { "InstitutionId", "Name" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Administrators_Institutions_InstitutionId",
                table: "Administrators",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "InstitutionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
