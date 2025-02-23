using Application.Commands.Bursary;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.services
{
    public interface IBursaryService
    {
       Task<bool>SaveBursaryApplicationAsync(Guid id,CreateBursaryApplicationCommand bursaryApplicationCommand);

       Task<IEnumerable<BursaryApplication?>>GetAllBursaryApplicationsAsync();

       Task<BursaryApplication?>GetBursaryApplicationByIdAsync(Guid applicationId);

       Task<BursaryApplication?> GetBursaryApplicationByPhoneNumberAsync(string phoneNUmber);

       Task<bool>UpdateBursaryApplicationByIdAsync(Guid id,UpdateBursaryApplicationCommand updatedBursaryApplicationCommand);

    }
}
