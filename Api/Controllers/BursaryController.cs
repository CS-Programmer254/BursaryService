using Application.Commands.Bursary;
using Application.Queries.Bursary;
using Domain.Aggregates;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BursaryController : ControllerBase
    {
        private IMediator _mediator;
        public BursaryController(IMediator mediator) {

            _mediator = mediator;
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyForBursary([FromBody] CreateBursaryApplicationCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(new { Success = result, Message = "Bursary application submitted successfully." });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBursaryApplication([FromBody] UpdateBursaryApplicationCommand command, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(command, cancellationToken);


            if (!result)

                return NotFound(new { Success = false, Message = "Bursary application not found or update failed." });


            return Ok(new { Success = true, Message = "Bursary application updated successfully." });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBursaryApplications(CancellationToken cancellationToken)
        {
            var query = new GetAllBursaryApplicationsQuery();

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetBursaryApplicationById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetBursaryApplicationByIdQuery(id);

            var result = await _mediator.Send(query, cancellationToken);

            if (result == null)

                return NotFound(new { Success = false, Message = "Bursary application not found." });

            return Ok(result);
        }

        [HttpGet("get-by-phone/{phoneNumber}")]
        public async Task<IActionResult> GetBursaryApplicationByPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        {
            var query = new GetBursaryApplicationByPhoneNumberQuery(phoneNumber);

            var result = await _mediator.Send(query, cancellationToken);


            if (result == null)

                return NotFound(new { Success = false, Message = "No bursary application found for this phone number." });

            return Ok(result);
        }

    }
}
