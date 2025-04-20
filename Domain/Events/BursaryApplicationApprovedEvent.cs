using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public record BursaryApplicationApprovedEvent(

      Guid ApplicationId,

      Guid ApprovalId,

      string ApplicantFullName,

      string ApplicantEmail,

      string ApprovalStatus,

      string ApplicantPhoneNumber,

      string AllocatedAmount,

      string AssignedBatchNumber

   ) : IDomainEvent;

}
