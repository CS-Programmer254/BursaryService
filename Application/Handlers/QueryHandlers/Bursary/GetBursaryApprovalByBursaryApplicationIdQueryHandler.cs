using Application.DTOs;
using Application.Queries.Bursary;
using Application.services;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Handlers.QueryHandlers.Bursary
{
    public class GetBursaryApprovalByBursaryApplicationIdQueryHandler : IRequestHandler<GetBursaryApprovalByBursaryApplicationIdQuery, GetBursaryApprovalResponseDto>
    {
        private readonly IBursaryApprovalService _bursaryApprovalService;

        public GetBursaryApprovalByBursaryApplicationIdQueryHandler( IBursaryApprovalService bursaryApprovalService)
        {

            _bursaryApprovalService= bursaryApprovalService ?? throw new ArgumentNullException(nameof(bursaryApprovalService));
            
        }
        public async Task<GetBursaryApprovalResponseDto?> Handle(GetBursaryApprovalByBursaryApplicationIdQuery request, CancellationToken cancellationToken)
        {
            var approval = await _bursaryApprovalService.GetBursaryApprovalByBursaryApplicationId(request.BursaryApplicationId);

            if (approval is null)
                return null;

            return new GetBursaryApprovalResponseDto(
                approval.ApproverFullName,
                approval.ApproverNationalIdentificationNumber,
                approval.ApproverPhoneNumber,
                approval.ApproverEmailAddress,
                approval.ApprovalStatus,
                approval.AssignedBatchNumber,
                approval.AmountAppliedFor,
                approval.AmountAllocated,
                approval.Remark,
                approval.ApprovedDate,
                "Bursary approval details retrieved successfully."
            );
        }

    }
}
