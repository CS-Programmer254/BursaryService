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
        public string ApplicantFullName { get; set; }
        public string AdmissionNumber { get; set; }
        public string SchoolName { get; set; }
        public string DepartmentName { get;  set; }
        public string EnrolledCourse { get; set; }
        public string YearOfStudy { get; set; }
        public string ApplicationStatus { get; set; }
        public DateTime ApplicationDate { get; set; }
        public Money AmountAppliedFor { get; set; }
    }
}
