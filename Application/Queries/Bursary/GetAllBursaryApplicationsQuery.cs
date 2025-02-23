using Application.DTOs;
using Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Bursary
{
    public record GetAllBursaryApplicationsQuery() : IRequest<IEnumerable<GetBursaryApplicationResponseDto?>>;
}
