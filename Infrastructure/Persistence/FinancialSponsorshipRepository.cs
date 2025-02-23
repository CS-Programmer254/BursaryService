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
using static System.Net.Mime.MediaTypeNames;

namespace Infrastructure.Persistence
{
    public class FinancialSponsorshipRepository : IFinancialSponsorshipRepository
    {
        private readonly AppDbContext _context;

        public FinancialSponsorshipRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task SaveFinancialSponsorshipAsync(FinancialSponsorship financialSponsorship)
        {
            if (financialSponsorship == null)

                throw new ArgumentNullException(nameof(financialSponsorship));

            await _context.FinancialSponsorships.AddAsync(financialSponsorship);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateFinancialSponsorshipAsync(FinancialSponsorship financialSponsorship)
        {
            if (financialSponsorship == null)

                throw new ArgumentNullException(nameof(financialSponsorship));

            _context.FinancialSponsorships.Update(financialSponsorship);

            await _context.SaveChangesAsync();
        }
    }
}
