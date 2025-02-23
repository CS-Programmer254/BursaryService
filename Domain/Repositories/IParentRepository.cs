using Domain.Aggregates;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IParentRepository
    {
        Task SaveParentAsync(Parent parent);

        Task UpdateParentAsync(Parent parent);
    }
}
