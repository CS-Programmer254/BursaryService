using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBursaryApprovalRepository
    {
        Task<bool> SaveBursaryApprovalAsync(BursaryApproval bursaryApproval); 

        Task<BursaryApproval?> GetBursaryApprovalByIdAsync(Guid id);

        Task<BursaryApproval?> GetBursaryApprovalByBursaryApplicationIdAsync(Guid id);

        Task<IEnumerable<BursaryApproval?>> GetAllBursaryApprovalAsync();

    }
}
