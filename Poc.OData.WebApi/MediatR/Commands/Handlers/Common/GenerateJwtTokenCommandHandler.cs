using MediatR;
using Poc.OData.WebApi.Jwt;
using Poc.OData.WebApi.MediatR.Commands.Models.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Poc.OData.WebApi.MediatR.Commands.Handlers.Common
{
    public class GenerateJwtTokenCommandHandler : IRequestHandler<GenerateJwtTokenCommand, string>
    {
        private readonly ApiConfig _apiConfig;

        public GenerateJwtTokenCommandHandler() { }

        public GenerateJwtTokenCommandHandler(ApiConfig apiConfig)
        {
            _apiConfig = apiConfig;
        }
        public async Task<string> Handle(GenerateJwtTokenCommand request, CancellationToken cancellationToken)
        {
            var token = new JwtTokenBuilder();
            token.AddSecurityKey(JwtSecurityKey.Create("_apiConfig.SecretKey"));

            if (_apiConfig.ValidateIssuer)
                token.AddIssuer(_apiConfig.ValidIssuer);
            if (_apiConfig.ValidateAudience)
                token.AddAudience(_apiConfig.ValidAudience);

            token.AddClaims(request.Claims);
            token.AddExpiry(_apiConfig.ExpiryInMinutes);
            token.Build();

            return await Task.FromResult(token.Build().Value);
        }
    }
}
