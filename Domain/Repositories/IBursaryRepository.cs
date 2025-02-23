using Domain.Aggregates;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBursaryRepository
    {
        Task<IEnumerable<BursaryApplication>> GetAllBursaryApplicationsAsync();

        Task<BursaryApplication?> GetBursaryApplicationByIdAsync(Guid id);
       
        Task<bool>SaveBursaryApplicationAsync(BursaryApplication application);

        Task<bool>UpdateBursaryApplicationAsync(BursaryApplication application);

        Task<IEnumerable<BursaryApplication>> GetByPhoneNumberAsync(string phoneNumber);

        Task<IEnumerable<BursaryApplication>> GetAllBursaryApplicationsByStatusAsync(string status);


    }
}
