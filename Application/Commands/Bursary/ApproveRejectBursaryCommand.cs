using Application.DTOs;
using Domain.ValueObjects;
using MediatR;
using System;

namespace Application.Commands.Bursary
{
    public record ApproveRejectBursaryCommand(

        string ApproverFullName,

        string ApproverNationalIdentificationNumber,

        string ApproverPhoneNumber,

        string ApproverEmailAddress,

        Guid BursaryApplicationId,

        string ApprovalStatus,

        string AssignedBatchNumber,

        Money AmountAppliedFor,

        Money AmountAllocated,

        string Remark,

        DateTime ApprovedDate

    ) : IRequest<GetBursaryApprovalResponseDto>;
}
