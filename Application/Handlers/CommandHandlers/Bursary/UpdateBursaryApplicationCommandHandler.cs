using Application.Commands.Bursary;
using Application.services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CommandHandlers.Bursary
{
    public class UpdateBursaryApplicationCommandHandler : IRequestHandler<UpdateBursaryApplicationCommand, bool>
    {
        private readonly IBursaryApplicationService _bursaryApplicationService;

        public UpdateBursaryApplicationCommandHandler(IBursaryApplicationService bursaryApplicationService)
        {
            _bursaryApplicationService = bursaryApplicationService ?? throw new ArgumentNullException(nameof(bursaryApplicationService));
        }

        public async Task<bool> Handle(UpdateBursaryApplicationCommand request, CancellationToken cancellationToken)
        {
            return await _bursaryApplicationService.UpdateBursaryApplicationByIdAsync(request.ApplicationId, request);
        }
    }

}
