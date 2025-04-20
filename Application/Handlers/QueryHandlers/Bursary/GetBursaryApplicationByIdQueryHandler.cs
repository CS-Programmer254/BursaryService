using Application.DTOs;
using Application.Queries.Bursary;
using Application.services;
using Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Handlers.QueryHandlers.Bursary
{
    public class GetBursaryApplicationByIdQueryHandler : IRequestHandler<GetBursaryApplicationByIdQuery, GetBursaryApplicationResponseDto?>
    {
        private readonly IBursaryApplicationService _bursaryService;

        public GetBursaryApplicationByIdQueryHandler(IBursaryApplicationService bursaryService)
        {
            _bursaryService = bursaryService ?? throw new ArgumentNullException(nameof(bursaryService));
        }

        public async Task<GetBursaryApplicationResponseDto?> Handle(GetBursaryApplicationByIdQuery request, CancellationToken cancellationToken)
        {
            var application = await _bursaryService.GetBursaryApplicationByIdAsync(request.ApplicationId);

            if (application == null)

                return null;

            return new GetBursaryApplicationResponseDto
            {
                BursaryApplicationId = application.ApplicationId,
                BatchNumber = application.BatchNumber,
                ApplicantFullName = application.ApplicantFullName,
                ApplicantPhoneNumber = application.ApplicantPhoneNumber,
                ApplicantEmail = application.EmailAddress,
                AdmissionNumber = application.AdmissionNumber,
                SchoolName = application.SchoolName,
                DepartmentName = application.DepartmentName,
                EnrolledCourse = application.EnrolledCourse,
                YearOfStudy = application.YearOfStudy,
                ApplicationStatus = application.ApplicationStatus,
                ApplicationDate = application.ApplicationDate,
                AmountAppliedFor = application.AmountAppliedFor,
                NationalIdentificationNumber = application.NationalIdentificationNumber,
                PreviousAcademicYearGrade = application.PreviousAcademicYearGrade,
                SponsorshipType = application.SponsorshipType,
                AnyFormOfDisability = application.AnyFormOfDisability,
                County = application.County
            };
        }
    }
}
