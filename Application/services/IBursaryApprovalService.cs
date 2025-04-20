using Application.Commands.Bursary;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.services
{
    public interface IBursaryApprovalService
    {
        Task<bool>SaveBursaryApproval(ApproveRejectBursaryCommand approveBursaryCommand);

        Task<BursaryApproval?>GetBursaryApprovalById(Guid approvalId);

        Task<BursaryApproval?>GetBursaryApprovalByBursaryApplicationId(Guid BursaryApplicationId);

        Task<IEnumerable<BursaryApproval?>>GetAllBursaryApprovals();


    }
}
