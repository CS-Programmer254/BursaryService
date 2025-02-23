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
        private readonly IBursaryService _bursaryService;

        public CreateBursaryApplicationCommandHandler(IBursaryService bursaryService)
        {
            _bursaryService = bursaryService ?? throw new ArgumentNullException(nameof(bursaryService));
        }

        public async Task<bool> Handle(CreateBursaryApplicationCommand request, CancellationToken cancellationToken)
        {
            return await _bursaryService.SaveBursaryApplicationAsync(Guid.NewGuid(),request);
        }
    }

}
