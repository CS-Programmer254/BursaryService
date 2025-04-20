using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BursaryApplications",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApplicantFullName = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicantPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    AdmissionNumber = table.Column<string>(type: "TEXT", nullable: false),
                    NationalIdentificationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    SchoolName = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentName = table.Column<string>(type: "TEXT", nullable: false),
                    EnrolledCourse = table.Column<string>(type: "TEXT", nullable: false),
                    YearOfStudy = table.Column<string>(type: "TEXT", nullable: false),
                    PreviousAcademicYearGrade = table.Column<string>(type: "TEXT", nullable: false),
                    SponsorshipType = table.Column<string>(type: "TEXT", nullable: false),
                    AnyFormOfDisability = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicationStatus = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AmountAppliedFor = table.Column<decimal>(type: "TEXT", nullable: false),
                    AmountAppliedFor_Currency = table.Column<string>(type: "TEXT", nullable: false),
                    County = table.Column<string>(type: "TEXT", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BursaryApplications", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "BursaryApprovalStatuses",
                columns: table => new
                {
                    BursaryApprovalStatusId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BursaryApprovalStatusName = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BursaryApprovalStatuses", x => x.BursaryApprovalStatusId);
                });

            migrationBuilder.CreateTable(
                name: "FamilyStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AdmissionNumber = table.Column<string>(type: "TEXT", nullable: false),
                    IsOrphan = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSingleParent = table.Column<bool>(type: "INTEGER", nullable: false),
                    NumberOfSiblings = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfSiblingsInInstitutionOfHigherLearning = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeeBalances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AdmissionNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    FeeBalance_CurrentBalance = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    FeeBalance_Currency = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeBalances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialSponsorships",
                columns: table => new
                {
                    FinancialSponsorshipEntryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AwardingOrganization = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    SponsorshipType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AmountFunded = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    AmountFunded_Currency = table.Column<string>(type: "TEXT", nullable: false),
                    AdmissionNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialSponsorships", x => x.FinancialSponsorshipEntryId);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    NationalIdentificationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    EmploymentStatus = table.Column<string>(type: "TEXT", nullable: false),
                    IsDisabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    RelationshipWithBursaryApplicant = table.Column<string>(type: "TEXT", nullable: false),
                    BursaryApplicantAdmissionNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ParentId);
                });

            migrationBuilder.CreateTable(
                name: "BursaryApprovals",
                columns: table => new
                {
                    ApprovalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApproverFullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ApproverNationalIdentificationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ApproverPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ApproverEmailAddress = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    BursaryApplicationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApprovalStatus = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    AssignedBatchNumber = table.Column<string>(type: "TEXT", nullable: false),
                    AmountAppliedFor = table.Column<decimal>(type: "TEXT", nullable: false),
                    AmountAppliedFor_Currency = table.Column<string>(type: "TEXT", nullable: false),
                    AmountAllocated = table.Column<decimal>(type: "TEXT", nullable: false),
                    AmountAllocated_Currency = table.Column<string>(type: "TEXT", nullable: false),
                    Remark = table.Column<string>(type: "TEXT", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BursaryApprovals", x => x.ApprovalId);
                    table.ForeignKey(
                        name: "FK_BursaryApprovals_BursaryApplications_BursaryApplicationId",
                        column: x => x.BursaryApplicationId,
                        principalTable: "BursaryApplications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BursaryApplications_ApplicationId",
                table: "BursaryApplications",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_BursaryApprovals_BursaryApplicationId",
                table: "BursaryApprovals",
                column: "BursaryApplicationId",
                unique: true);

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
                name: "BursaryApprovals");

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

            migrationBuilder.DropTable(
                name: "BursaryApplications");
        }
    }
}
