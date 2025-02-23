using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public record BursaryApplicationCreatedEvent(
        
        Guid ApplicationId,

        string ApplicantFullName,

        string ApplicantPhoneNumber,

        string EmailAddress,

        string AdmissionNumber,

        string NationalIdentificationNumber,

        string SchoolName,

        string DepartmentName,

        string EnrolledCourse,

        string YearOfStudy,

        string previousAcademicYearGrade,

        string SponsorshipType,

        string AnyFormOfDisability,

        string ApplicationStatus,
        
        DateTime ApplicationDate,

        Money AmountAppliedFor,

        string County

        ):IDomainEvent;
       
    
}
