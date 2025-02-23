using Domain.Aggregates;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IFinancialSponsorshipRepository
    {
        Task SaveFinancialSponsorshipAsync(FinancialSponsorship financialSponsorship);

        Task UpdateFinancialSponsorshipAsync(FinancialSponsorship financialSponsorship);

    }
}
