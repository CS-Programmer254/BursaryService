using Domain.Aggregates;
using Domain.Data;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class FeeBalanceRepository : IFeeBalanceRepository
    {
        private readonly AppDbContext _context;

        public FeeBalanceRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task SaveFeeBalanceAsync(FeeBalance feeBalance)
        {
            if (feeBalance == null)

                throw new ArgumentNullException(nameof(feeBalance));

            await _context.FeeBalances.AddAsync(feeBalance);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateFeeBalanceAsync(FeeBalance feeBalance)
        {
            if (feeBalance == null)

                throw new ArgumentNullException(nameof(feeBalance));
            
            _context.FeeBalances.Update(feeBalance);

            await _context.SaveChangesAsync();
        }
    }
}
