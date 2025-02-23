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
    public class GetAllBursaryApplicationsQueryHandler : IRequestHandler<GetAllBursaryApplicationsQuery, IEnumerable<GetBursaryApplicationResponseDto?>>
    {
        private readonly IBursaryService _bursaryService;

        public GetAllBursaryApplicationsQueryHandler(IBursaryService bursaryService)
        {
            _bursaryService = bursaryService ?? throw new ArgumentNullException(nameof(bursaryService));
        }

        public async Task<IEnumerable<GetBursaryApplicationResponseDto?>> Handle(GetAllBursaryApplicationsQuery request, CancellationToken cancellationToken)
        {
            var applications = await _bursaryService.GetAllBursaryApplicationsAsync();

            return applications.Select(a => new GetBursaryApplicationResponseDto
            {
                ApplicantFullName = a.ApplicantFullName,
                AdmissionNumber = a.AdmissionNumber,
                SchoolName = a.SchoolName,
                DepartmentName = a.DepartmentName,
                EnrolledCourse = a.EnrolledCourse,
                YearOfStudy = a.YearOfStudy,
                ApplicationStatus = a.ApplicationStatus,
                ApplicationDate = a.ApplicationDate,
                AmountAppliedFor = a.AmountAppliedFor
            }).ToList();
        }
    }
}
