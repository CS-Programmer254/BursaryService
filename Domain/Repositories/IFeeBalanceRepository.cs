using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IFeeBalanceRepository
    {
        Task SaveFeeBalanceAsync(FeeBalance feeBalance);

        Task UpdateFeeBalanceAsync(FeeBalance feeBalance);
    }
}
