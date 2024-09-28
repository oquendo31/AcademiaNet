using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaNet.Backend.Migrations
{
    /// <inheritdoc />
    public partial class addTablesEntitity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicPrograms",
                columns: table => new
                {
                    ProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InstitutionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPrograms", x => x.ProgramID);
                    table.ForeignKey(
                        name: "FK_AcademicPrograms_Institutions_InstitutionID",
                        column: x => x.InstitutionID,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentPeriods",
                columns: table => new
                {
                    PeriodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDateEnrollment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateEnrollment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateExam = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateExam = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstitutionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentPeriods", x => x.PeriodID);
                    table.ForeignKey(
                        name: "FK_EnrollmentPeriods_Institutions_InstitutionID",
                        column: x => x.InstitutionID,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MinValue = table.Column<int>(type: "int", nullable: false),
                    MaxValue = table.Column<int>(type: "int", nullable: false),
                    EnrollmentPeriodPeriodID = table.Column<int>(type: "int", nullable: false),
                    PeriodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamID);
                    table.ForeignKey(
                        name: "FK_Exams_EnrollmentPeriods_EnrollmentPeriodPeriodID",
                        column: x => x.EnrollmentPeriodPeriodID,
                        principalTable: "EnrollmentPeriods",
                        principalColumn: "PeriodID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeriodAcademicPrograms",
                columns: table => new
                {
                    PeriodAcademicProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramID = table.Column<int>(type: "int", nullable: false),
                    AcademicProgramProgramID = table.Column<int>(type: "int", nullable: false),
                    PeriodID = table.Column<int>(type: "int", nullable: false),
                    EnrollmentPeriodPeriodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodAcademicPrograms", x => x.PeriodAcademicProgramID);
                    table.ForeignKey(
                        name: "FK_PeriodAcademicPrograms_AcademicPrograms_AcademicProgramProgramID",
                        column: x => x.AcademicProgramProgramID,
                        principalTable: "AcademicPrograms",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodAcademicPrograms_EnrollmentPeriods_EnrollmentPeriodPeriodID",
                        column: x => x.EnrollmentPeriodPeriodID,
                        principalTable: "EnrollmentPeriods",
                        principalColumn: "PeriodID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Document = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InstitutionID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Institutions_InstitutionID",
                        column: x => x.InstitutionID,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PeriodID = table.Column<int>(type: "int", nullable: false),
                    ProgramID = table.Column<int>(type: "int", nullable: false),
                    EnrollmentPeriodPeriodID = table.Column<int>(type: "int", nullable: false),
                    AcademicProgramProgramID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollments_AcademicPrograms_AcademicProgramProgramID",
                        column: x => x.AcademicProgramProgramID,
                        principalTable: "AcademicPrograms",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_EnrollmentPeriods_EnrollmentPeriodPeriodID",
                        column: x => x.EnrollmentPeriodPeriodID,
                        principalTable: "EnrollmentPeriods",
                        principalColumn: "PeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamResults",
                columns: table => new
                {
                    ResultID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ExamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResults", x => x.ResultID);
                    table.ForeignKey(
                        name: "FK_ExamResults_Exams_ExamID",
                        column: x => x.ExamID,
                        principalTable: "Exams",
                        principalColumn: "ExamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamResults_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PeriodID = table.Column<int>(type: "int", nullable: false),
                    EnrollmentPeriodPeriodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notifications_EnrollmentPeriods_EnrollmentPeriodPeriodID",
                        column: x => x.EnrollmentPeriodPeriodID,
                        principalTable: "EnrollmentPeriods",
                        principalColumn: "PeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPrograms_InstitutionID",
                table: "AcademicPrograms",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentPeriods_InstitutionID",
                table: "EnrollmentPeriods",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_AcademicProgramProgramID",
                table: "Enrollments",
                column: "AcademicProgramProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EnrollmentPeriodPeriodID",
                table: "Enrollments",
                column: "EnrollmentPeriodPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_UserID",
                table: "Enrollments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_ExamID",
                table: "ExamResults",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_UserID",
                table: "ExamResults",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_EnrollmentPeriodPeriodID",
                table: "Exams",
                column: "EnrollmentPeriodPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_EnrollmentPeriodPeriodID",
                table: "Notifications",
                column: "EnrollmentPeriodPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodAcademicPrograms_AcademicProgramProgramID",
                table: "PeriodAcademicPrograms",
                column: "AcademicProgramProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodAcademicPrograms_EnrollmentPeriodPeriodID",
                table: "PeriodAcademicPrograms",
                column: "EnrollmentPeriodPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_InstitutionID",
                table: "Users",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "ExamResults");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PeriodAcademicPrograms");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AcademicPrograms");

            migrationBuilder.DropTable(
                name: "EnrollmentPeriods");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
