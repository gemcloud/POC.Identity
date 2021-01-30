using MediatR;
using System.Collections.Generic;

namespace Poc.OData.WebApi.MediatR.Commands.Models.Common
{
    public class GenerateJwtTokenCommand : IRequest<string>
    {
        public Dictionary<string, string> Claims { get; set; }
    }

}
