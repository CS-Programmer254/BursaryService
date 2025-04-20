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

namespace Application.Handlers.QueryHandlers.Bursary
{
    public class GetAllBursaryApplicationsByApplicationStatusQueryHandler : IRequestHandler<GetAllBursaryApplicationsByApplicationStatusQuery, IEnumerable<GetBursaryApplicationResponseDto?>>
    {
        private readonly IBursaryApplicationService _bursaryApplicationService; 
        public GetAllBursaryApplicationsByApplicationStatusQueryHandler( IBursaryApplicationService bursaryApplicationService)
        {
            _bursaryApplicationService = bursaryApplicationService ?? throw new ArgumentNullException(nameof(bursaryApplicationService));

        }
        public async Task<IEnumerable<GetBursaryApplicationResponseDto?>> Handle(GetAllBursaryApplicationsByApplicationStatusQuery request, CancellationToken cancellationToken)
        {
            var applications = await _bursaryApplicationService.GetBursaryApplicationsByApplicationStatusAsync(request.applicationStatus);

            if (applications == null || !applications.Any())
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
