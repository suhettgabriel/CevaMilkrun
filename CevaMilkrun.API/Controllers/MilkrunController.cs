using CevaMilkrun.Application.Features.Milkrun;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CevaMilkrun.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MilkrunController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MilkrunController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetMilkrunData(string phoneNumber)
        {
            var query = new GetMilkrunDataQuery { PhoneNumber = phoneNumber };
            var result = await _mediator.Send(query);

            if (string.IsNullOrEmpty(result))
            {
                return NotFound(new { message = "Nenhum dado encontrado ou erro de comunicação." });
            }

            return Content(result, "application/json");
        }
    }
}