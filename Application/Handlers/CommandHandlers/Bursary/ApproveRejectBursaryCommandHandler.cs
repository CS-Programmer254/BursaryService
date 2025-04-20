using Application.Commands.Bursary;
using Application.DTOs;
using Application.services;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CommandHandlers.Bursary
{
    public class ApproveRejectBursaryCommandHandler : IRequestHandler<ApproveRejectBursaryCommand, GetBursaryApprovalResponseDto>
    {
        private readonly IBursaryApplicationService _bursaryApplicationService;


        private readonly IBursaryApprovalService _bursaryApprovalService;

        public ApproveRejectBursaryCommandHandler(IBursaryApplicationService bursaryApplicationService, IBursaryApprovalService bursaryApprovalService)
        {

            _bursaryApplicationService = bursaryApplicationService ?? throw new ArgumentNullException(nameof(bursaryApplicationService));

            _bursaryApprovalService = bursaryApprovalService ?? throw new ArgumentNullException(nameof(bursaryApprovalService));
        }

        public async Task<GetBursaryApprovalResponseDto?> Handle(ApproveRejectBursaryCommand request, CancellationToken cancellationToken)
        {
            if (request == null)

               throw new ArgumentNullException(nameof(request));
      
            var updatedRequest = request with
            {
                AmountAllocated = request.ApprovalStatus == "Rejected" ? new Money(0, request.AmountAllocated.Currency) : request.AmountAllocated,
                AssignedBatchNumber = request.ApprovalStatus == "Rejected" ? "Not Assigned" : request.AssignedBatchNumber
            };

            var bursaryApproval = await _bursaryApprovalService.SaveBursaryApproval(updatedRequest);

            if (!bursaryApproval)
                
                return null;
            

            if (!await _bursaryApplicationService.ApproveOrRejectBursaryApplicationAsync(updatedRequest))
                
                return null;
           
            return new GetBursaryApprovalResponseDto(
                updatedRequest.ApproverFullName,
                updatedRequest.ApproverNationalIdentificationNumber,
                updatedRequest.ApproverPhoneNumber,
                updatedRequest.ApproverEmailAddress,
                updatedRequest.ApprovalStatus,
                updatedRequest.AssignedBatchNumber,
                updatedRequest.AmountAppliedFor,
                updatedRequest.AmountAllocated,
                updatedRequest.Remark,
                updatedRequest.ApprovedDate,
                $"Bursary application {updatedRequest.BursaryApplicationId} approved successfully.");
        }
    }
}
