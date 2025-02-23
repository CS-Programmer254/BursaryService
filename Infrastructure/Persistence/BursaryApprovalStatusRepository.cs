using Domain.Aggregates;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class BursaryApprovalStatusRepository : IBursaryApprovalStatusRepository
    {
        public Task SaveBursaryApprovalStatusAsync(BursaryApprovalStatus bursaryApprovalStatus)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBursaryApprovalStatusAsync(BursaryApprovalStatus bursaryApprovalStatus)
        {
            throw new NotImplementedException();
        }
    }
}
