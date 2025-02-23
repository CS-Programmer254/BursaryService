using Domain.Aggregates;
using Domain.Data;
using Domain.Repositories;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class BursaryRepository : IBursaryRepository
    {
        private readonly AppDbContext _context;

        public BursaryRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<BursaryApplication>> GetAllBursaryApplicationsAsync()
        {
            return await _context.BursaryApplications.ToListAsync();
        }

        public async Task<BursaryApplication?> GetBursaryApplicationByIdAsync(Guid id)
        {
            return await _context.BursaryApplications.AsNoTracking().FirstOrDefaultAsync(b => b.ApplicationId == id);
        }

        public async Task <bool> SaveBursaryApplicationAsync(BursaryApplication bursaryApplication)
        {
            if (bursaryApplication == null)
                
                throw new ArgumentNullException(nameof(bursaryApplication));
            
            await _context.BursaryApplications.AddAsync(bursaryApplication);

            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> UpdateBursaryApplicationAsync(BursaryApplication bursaryApplication)
        {
            if (bursaryApplication == null)

                throw new ArgumentNullException(nameof(bursaryApplication));

            _context.BursaryApplications.Update(bursaryApplication);

            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<IEnumerable<BursaryApplication>> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.BursaryApplications.Where(b => b.ApplicantPhoneNumber == phoneNumber).ToListAsync();
        }

        public async Task<IEnumerable<BursaryApplication>> GetAllBursaryApplicationsByStatusAsync(string status)
        {
            return await _context.BursaryApplications.Where(b => b.ApplicationStatus == status).ToListAsync();
        }
    }
}
