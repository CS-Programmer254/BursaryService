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
    public class ParentRepository : IParentRepository
    {
     
        private readonly AppDbContext _context;

        public ParentRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task SaveParentAsync(Parent parent)
        {
            if (parent == null)
                
                throw new ArgumentNullException(nameof(parent));

            await _context.Parents.AddAsync(parent);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateParentAsync(Parent parent)
        {
            if (parent == null)

                throw new ArgumentNullException(nameof(parent));

            _context.Parents.Update(parent);

            await _context.SaveChangesAsync();
        }
    }
}
