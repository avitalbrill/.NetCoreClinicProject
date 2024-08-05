using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solid.Data.Migrations
{
    public partial class many_to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Turns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Turns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Turns_DoctorId",
                table: "Turns",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_PatientId",
                table: "Turns",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turns_Doctors_DoctorId",
                table: "Turns",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turns_Patients_PatientId",
                table: "Turns",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turns_Doctors_DoctorId",
                table: "Turns");

            migrationBuilder.DropForeignKey(
                name: "FK_Turns_Patients_PatientId",
                table: "Turns");

            migrationBuilder.DropIndex(
                name: "IX_Turns_DoctorId",
                table: "Turns");

            migrationBuilder.DropIndex(
                name: "IX_Turns_PatientId",
                table: "Turns");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Turns");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Turns");
        }
    }
}
