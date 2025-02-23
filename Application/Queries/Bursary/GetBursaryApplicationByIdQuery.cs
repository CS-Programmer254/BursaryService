﻿using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Bursary
{
   public record GetBursaryApplicationByIdQuery(Guid ApplicationId ) : IRequest<GetBursaryApplicationResponseDto?>;
}
