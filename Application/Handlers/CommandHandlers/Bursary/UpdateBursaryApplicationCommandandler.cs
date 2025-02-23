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
        private readonly IBursaryService _bursaryService;

        public UpdateBursaryApplicationCommandHandler(IBursaryService bursaryService)
        {
            _bursaryService = bursaryService ?? throw new ArgumentNullException(nameof(bursaryService));
        }

        public async Task<bool> Handle(UpdateBursaryApplicationCommand request, CancellationToken cancellationToken)
        {
            return await _bursaryService.UpdateBursaryApplicationByIdAsync(request.ApplicationId, request);
        }
    }

}
