using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Poc.OData.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("odata/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class BaseODataController : ODataController
    {
        public override ForbidResult Forbid()
        {
            return new ForbidResult(JwtBearerDefaults.AuthenticationScheme);
        }
    }
}
