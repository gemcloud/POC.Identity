using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Poc.OData.WebApi.MediatR.Commands.Models.Common;
using Poc.OData.WebApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc.OData.WebApi.Controllers
{
    [ApiController]
    [Area("Api")]
    [Route("[area]/[controller]/[action]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [SwaggerTag(description: "Create token")]
    public class JwtTokenController : Controller
    {
        private readonly IMediator _mediator;

        public JwtTokenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LoginModel model)
        {
            var claims = new Dictionary<string, string>();
            claims.Add("Email", model.Email);

            var token = await _mediator.Send(new GenerateJwtTokenCommand() { Claims = claims });
            //return Content(token);
            return Ok(new { TokenDemo = token });
        }
    }
}
