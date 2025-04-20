using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Domain.Events
{
    public record BursaryApprovalUpdatedEvent(

        Guid ApprovalId,

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


    ) : IDomainEvent;
}
