using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record GetBursaryApprovalResponseDto(
    string ? ApproverFullName,
    string ? ApproverNationalIdentificationNumber,
    string ? ApproverPhoneNumber,
    string ? ApproverEmailAddress,
    string ? ApprovalStatus,
    string ? AssignedBatchNumber,
    Money  ? AmountAppliedFor,
    Money  ? AmountAllocated,
    string ? Remark,
    DateTime ? ApprovedDate,
    string ? Message 
    );


}
