using Domain.Aggregates;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IFamilyStatusRepository
    {
        Task SaveFamilyStatusAsync(FamilyStatus familyStatus);

        Task UpdateFamilyStatusAsync(FamilyStatus familyStatus);
    }
}
