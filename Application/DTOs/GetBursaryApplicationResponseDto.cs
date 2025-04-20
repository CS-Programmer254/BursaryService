using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GetBursaryApplicationResponseDto
    {
        public Guid BursaryApplicationId { get; set; }
        public string BatchNumber { get; set; }
        public string ApplicantFullName { get; set; }
        public string ApplicantPhoneNumber { get; set; }
        public string ApplicantEmail { get; set; }
        public string AdmissionNumber { get; set; }
        public string SchoolName { get; set; }
        public string DepartmentName { get; set; }
        public string EnrolledCourse { get; set; }
        public string YearOfStudy { get; set; }
        public string ApplicationStatus { get; set; }
        public DateTime ApplicationDate { get; set; }
        public Money AmountAppliedFor { get; set; }
        public string NationalIdentificationNumber { get; set; }

        public string PreviousAcademicYearGrade { get;set; }

        public string SponsorshipType { get; set; }

        public string AnyFormOfDisability { get; set; }

        public string County { get; set; }

    }
}
