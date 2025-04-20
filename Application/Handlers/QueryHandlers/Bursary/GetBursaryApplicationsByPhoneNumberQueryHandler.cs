using Application.DTOs;
using Application.Queries.Bursary;
using Application.services;
using Application.Services;
using Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.QueryHandlers.Bursary
{
    public class GetBursaryApplicationsByPhoneNumberQueryHandler : IRequestHandler<GetBursaryApplicationsByPhoneNumberQuery,IEnumerable<GetBursaryApplicationResponseDto?>>
    {

        private readonly IBursaryApplicationService _bursaryService;

        public GetBursaryApplicationsByPhoneNumberQueryHandler(IBursaryApplicationService bursaryService)
        {
            _bursaryService = bursaryService ?? throw new ArgumentNullException(nameof(bursaryService));
        }

        public async Task<IEnumerable<GetBursaryApplicationResponseDto?>> Handle(GetBursaryApplicationsByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var applications = await _bursaryService.GetBursaryApplicationsByPhoneNumberAsync(request.PhoneNumber);

            if (applications == null)
            {
                return Enumerable.Empty<GetBursaryApplicationResponseDto>();
            }

            return applications.Select(a => new GetBursaryApplicationResponseDto
            {
                BursaryApplicationId = a.ApplicationId,
                BatchNumber = a.BatchNumber,
                ApplicantFullName = a.ApplicantFullName,
                ApplicantPhoneNumber = a.ApplicantPhoneNumber,
                ApplicantEmail = a.EmailAddress,
                AdmissionNumber = a.AdmissionNumber,
                SchoolName = a.SchoolName,
                DepartmentName = a.DepartmentName,
                EnrolledCourse = a.EnrolledCourse,
                YearOfStudy = a.YearOfStudy,
                ApplicationStatus = a.ApplicationStatus,
                ApplicationDate = a.ApplicationDate,
                AmountAppliedFor = a.AmountAppliedFor,
                NationalIdentificationNumber = a.NationalIdentificationNumber,
                PreviousAcademicYearGrade = a.PreviousAcademicYearGrade,
                SponsorshipType = a.SponsorshipType,
                AnyFormOfDisability = a.AnyFormOfDisability,
                County = a.County
            }).ToList();
        }
    }
}
