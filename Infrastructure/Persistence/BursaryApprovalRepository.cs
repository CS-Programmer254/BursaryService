using Domain.Aggregates;
using Domain.Data;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class BursaryApprovalRepository : IBursaryApprovalRepository
    {
        private readonly AppDbContext _context;
        public BursaryApprovalRepository(AppDbContext context)
        {
            _context= context ?? throw new ArgumentNullException(nameof(context));  
        }
        public async Task<IEnumerable<BursaryApproval?>> GetAllBursaryApprovalAsync()
        {

          return await _context.BursaryApprovals.ToListAsync();

        }

        public async Task<BursaryApproval?> GetBursaryApprovalByBursaryApplicationIdAsync(Guid id)
        {
            return await _context.BursaryApprovals.AsNoTracking().FirstOrDefaultAsync(b=>b.BursaryApplicationId==id);
        }

        public async Task<BursaryApproval?> GetBursaryApprovalByIdAsync(Guid id)
        {

            return await _context.BursaryApprovals.AsNoTracking().FirstOrDefaultAsync(b => b.ApprovalId == id);

        }

        public async Task<bool> SaveBursaryApprovalAsync(BursaryApproval bursaryApproval)
        {
            if (bursaryApproval == null)
                
                throw new ArgumentNullException(nameof(bursaryApproval));
            
            await _context.BursaryApprovals.AddAsync(bursaryApproval);
            
            await _context.SaveChangesAsync();
            
            return true;
        }
    }
}
