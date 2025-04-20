using Application.Commands.Bursary;
using Application.Queries.Bursary;
using MediatR;
using Microsoft.AspNetCore.Cors;
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

        [HttpGet("get-all-bursary-by-application-status/{applicationStatus}")]
        public async Task<IActionResult> GetAllBursaryApplicationsByStatus(string applicationStatus, CancellationToken cancellationToken)
        {
            var query = new GetAllBursaryApplicationsByApplicationStatusQuery(applicationStatus);

            var result = await _mediator.Send(query, cancellationToken);

            if (result == null)

                return NotFound(new { Success = false, Message = "Bursary applications not found." });

            return Ok(result);
        }

        [HttpGet("get-bursary-applications-by-phone/{phoneNumber}")]
        public async Task<IActionResult> GetBursaryApplicationsByPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        {
            var query = new GetBursaryApplicationsByPhoneNumberQuery(phoneNumber);

            var result = await _mediator.Send(query, cancellationToken);


            if (result == null)

                return NotFound(new { Success = false, Message = "No bursary application found for this phone number." });

            return Ok(result);
        }

        [HttpPut("approve-reject-bursary-application")]
        public async Task<IActionResult> ApproveBursaryApplication([FromBody] ApproveRejectBursaryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                if (result == null)
                {
                    return BadRequest(new { Success = false, Message = "Bursary approval/rejection failed." });
                }

                return Ok(new { Success = true, Message = result.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "An unexpected error occurred.", Error = ex.Message });
            }
        }

      
        [HttpGet("approval/bursary-application-id/{id}")]
        public async Task<IActionResult> GetBursaryApprovalByBursaryApplicationId(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetBursaryApprovalByBursaryApplicationIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            if (result == null)
                return NotFound(new { Success = false, Message = "Bursary approval details not found for the given application ID." });

            return Ok(result);
        }


    }
}
