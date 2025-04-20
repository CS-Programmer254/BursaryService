using Application.Commands.Bursary;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.services
{
    public interface IBursaryApplicationService
    {
       Task<bool>SaveBursaryApplicationAsync(Guid id,CreateBursaryApplicationCommand bursaryApplicationCommand);

       Task<IEnumerable<BursaryApplication?>>GetAllBursaryApplicationsAsync();

       Task<BursaryApplication?>GetBursaryApplicationByIdAsync(Guid applicationId);

       Task<IEnumerable<BursaryApplication?>> GetBursaryApplicationsByPhoneNumberAsync(string phoneNumber);

       Task<IEnumerable<BursaryApplication>>GetBursaryApplicationsByApplicationStatusAsync(string applicationStatus);

       Task<bool>UpdateBursaryApplicationByIdAsync(Guid id,UpdateBursaryApplicationCommand updatedBursaryApplicationCommand);
       
       Task<bool> ApproveOrRejectBursaryApplicationAsync(ApproveRejectBursaryCommand approveBursaryCommand);

    }
}
