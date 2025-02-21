using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BursaryApplication
    {
        private string ApplicationID { get; set; }
        private string ApplicantFullName {  get; set; }
        private string EmailAddress { get; set; }
        private string AddmissionNumber { get; set; }
        private string ApplicantNationalIdentificationNumber {  get; set; }
        private string SchoolName { get; set; }
        private string DepartmentName { get; set; }
        private string EnrolledCourse {  get; set; }
        private string YearOfStudy {  get; set; }
        private string SponsorshipType {  get; set; }
        private string AnyFormOfDisability {  get; set; }
        private string ApplicationStatus {  get; set; }
        private string ApplicationDate {  get; set; }
        private string AmountAppliedFor { get; set; }
        private string County { get; set; }

        public BursaryApplication()
        {
                
        }
        public BursaryApplication(string applicantFullName)
        {
            ApplicantFullName = applicantFullName;

        }

    }
}
