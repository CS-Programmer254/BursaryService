using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Bursary
{
    public record UpdateBursaryApplicationCommand(

        Guid ApplicationId,

        string ? ApplicantFullName,

        string ? ApplicantPhoneNumber,

        string ? EmailAddress,

        string ? AdmissionNumber,

        string ? NationalIdentificationNumber,

        string ? SchoolName,

        string ? DepartmentName,

        string ? EnrolledCourse,

        string ? YearOfStudy,

        string ? PreviousAcademicYearGrade,

        string ? SponsorshipType,

        string ? AnyFormOfDisability,

        string ? ApplicationStatus,

        string ? County,

        string ? BatchNumber

    ):IRequest<bool>;
}
