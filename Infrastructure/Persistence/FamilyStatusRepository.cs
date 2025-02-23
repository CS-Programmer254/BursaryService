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
    public class FamilyStatusRepository : IFamilyStatusRepository
    {
        private readonly AppDbContext _context;

        public FamilyStatusRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SaveFamilyStatusAsync(FamilyStatus familyStatus)
        {
            if (familyStatus == null)

                throw new ArgumentNullException(nameof(familyStatus));

            await _context.FamilyStatuses.AddAsync(familyStatus);

            await _context.SaveChangesAsync();
        }

 
        public async Task UpdateFamilyStatusAsync(FamilyStatus familyStatus)
        {
            if (familyStatus == null)

                throw new ArgumentNullException(nameof(familyStatus));

            _context.FamilyStatuses.Update(familyStatus);

            await _context.SaveChangesAsync();
        }
    }
}
