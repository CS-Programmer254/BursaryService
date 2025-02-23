using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BursaryApplications",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicantFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnrolledCourse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousAcademicYearGrade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SponsorshipType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnyFormOfDisability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountAppliedFor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BursaryApplications", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "BursaryApprovalStatuses",
                columns: table => new
                {
                    BursaryApprovalStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BursaryApprovalStatusName = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BursaryApprovalStatuses", x => x.BursaryApprovalStatusId);
                });

            migrationBuilder.CreateTable(
                name: "FamilyStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOrphan = table.Column<bool>(type: "bit", nullable: false),
                    IsSingleParent = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfSiblings = table.Column<int>(type: "int", nullable: false),
                    NumberOfSiblingsInInstitutionOfHigherLearning = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeeBalances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissionNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeBalances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialSponsorships",
                columns: table => new
                {
                    FinancialSponsorshipEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AwardingOrganization = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SponsorshipType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AmountFunded = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdmissionNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialSponsorships", x => x.FinancialSponsorshipEntryId);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    RelationshipWithBursaryApplicant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BursaryApplicantAdmissionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ParentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BursaryApplications_ApplicationId",
                table: "BursaryApplications",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeBalances_AdmissionNumber",
                table: "FeeBalances",
                column: "AdmissionNumber");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialSponsorships_AdmissionNumber",
                table: "FinancialSponsorships",
                column: "AdmissionNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BursaryApplications");

            migrationBuilder.DropTable(
                name: "BursaryApprovalStatuses");

            migrationBuilder.DropTable(
                name: "FamilyStatuses");

            migrationBuilder.DropTable(
                name: "FeeBalances");

            migrationBuilder.DropTable(
                name: "FinancialSponsorships");

            migrationBuilder.DropTable(
                name: "Parents");
        }
    }
}
