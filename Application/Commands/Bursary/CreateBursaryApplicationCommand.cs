using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Bursary
{
    public record CreateBursaryApplicationCommand(

      string ApplicantFullName,

      string ApplicantPhoneNumber,

      string EmailAddress,

      string AdmissionNumber,

      string NationalIdentificationNumber,

      string SchoolName,

      string DepartmentName,

      string EnrolledCourse,

      string YearOfStudy,

      string PreviousAcademicYearGrade,

      string SponsorshipType,

      string AnyFormOfDisability,

      Money AmountAppliedFor,

      string County
  ) : IRequest<bool>;

}
