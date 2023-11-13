using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssessmentEF.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fk_update_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "personnel_salary_id_fk",
                schema: "dbo",
                table: "Salaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salaries",
                schema: "dbo",
                table: "Salaries");

            migrationBuilder.RenameColumn(
                name: "PersonnelId",
                schema: "dbo",
                table: "Salaries",
                newName: "PersonnelID");

            migrationBuilder.AlterColumn<int>(
                name: "PersonnelID",
                schema: "dbo",
                table: "Salaries",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            /*migrationBuilder.AddColumn<int>(
                name: "PersonnelId",
                schema: "dbo",
                table: "Salaries",
                type: "int",
                nullable: false,
                defaultValue: 0);*/

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salaries",
                schema: "dbo",
                table: "Salaries",
                column: "PersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_PersonnelID",
                schema: "dbo",
                table: "Salaries",
                column: "PersonnelID");

            /*migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Personnels_PersonnelID",
                schema: "dbo",
                table: "Salaries",
                column: "PersonnelID",
                principalSchema: "dbo",
                principalTable: "Personnels",
                principalColumn: "ID");*/

            migrationBuilder.AddForeignKey(
                name: "personnel_salary_id_fk",
                schema: "dbo",
                table: "Salaries",
                column: "PersonnelId",
                principalSchema: "dbo",
                principalTable: "Personnels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Personnels_PersonnelID",
                schema: "dbo",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "personnel_salary_id_fk",
                schema: "dbo",
                table: "Salaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salaries",
                schema: "dbo",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_PersonnelID",
                schema: "dbo",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "PersonnelId",
                schema: "dbo",
                table: "Salaries");

            migrationBuilder.RenameColumn(
                name: "PersonnelID",
                schema: "dbo",
                table: "Salaries",
                newName: "PersonnelId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonnelId",
                schema: "dbo",
                table: "Salaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salaries",
                schema: "dbo",
                table: "Salaries",
                column: "PersonnelId");

            migrationBuilder.AddForeignKey(
                name: "personnel_salary_id_fk",
                schema: "dbo",
                table: "Salaries",
                column: "PersonnelId",
                principalSchema: "dbo",
                principalTable: "Personnels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
