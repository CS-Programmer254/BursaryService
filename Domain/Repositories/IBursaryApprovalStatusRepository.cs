using Domain.Aggregates;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBursaryApprovalStatusRepository
    {
        Task SaveBursaryApprovalStatusAsync(BursaryApprovalStatus bursaryApprovalStatus);

        Task UpdateBursaryApprovalStatusAsync(BursaryApprovalStatus bursaryApprovalStatus);
    }
}
