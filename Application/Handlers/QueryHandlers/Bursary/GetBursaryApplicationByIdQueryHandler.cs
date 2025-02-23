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
        private readonly IBursaryService _bursaryService;

        public GetBursaryApplicationByIdQueryHandler(IBursaryService bursaryService)
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
                ApplicantFullName = application.ApplicantFullName,
                AdmissionNumber = application.AdmissionNumber,
                SchoolName = application.SchoolName,
                DepartmentName = application.DepartmentName,
                EnrolledCourse = application.EnrolledCourse,
                YearOfStudy = application.YearOfStudy,
                ApplicationStatus = application.ApplicationStatus,
                ApplicationDate = application.ApplicationDate,
                AmountAppliedFor = application.AmountAppliedFor
            };
        }
    }
}
