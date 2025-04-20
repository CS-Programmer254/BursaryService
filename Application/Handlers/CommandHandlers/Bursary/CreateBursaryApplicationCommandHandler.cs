using Application.Commands.Bursary;
using Application.services;
using Domain.Aggregates;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CommandHandlers.Bursary
{
    public class CreateBursaryApplicationCommandHandler : IRequestHandler<CreateBursaryApplicationCommand, bool>
    {
        private readonly IBursaryApplicationService _bursaryApplicationService;

        public CreateBursaryApplicationCommandHandler(IBursaryApplicationService bursaryApplicationService)
        {
            _bursaryApplicationService = bursaryApplicationService ?? throw new ArgumentNullException(nameof(bursaryApplicationService));
        }

        public async Task<bool> Handle(CreateBursaryApplicationCommand request, CancellationToken cancellationToken)
        {
            return await _bursaryApplicationService.SaveBursaryApplicationAsync(Guid.NewGuid(),request);
        }
    }

}
