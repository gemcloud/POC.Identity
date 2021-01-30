//using Microsoft.AspNet.OData;
//using Microsoft.AspNet.OData.Query;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Swashbuckle.AspNetCore.Annotations;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Poc.OData.WebApi.Controllers.OData
//{
//    //[Route("odata/[controller]")]
//    //[ApiExplorerSettings(IgnoreApi = false)]
//    public class CountryController : BaseODataController   // ODataController //BaseODataController
//    {
//        //private readonly IMediator _mediator;
//        //private readonly IPermissionService _permissionService;

//        public CountryController()//IMediator mediator, IPermissionService permissionService)
//        {
//            //_mediator = mediator;
//            //_permissionService = permissionService;
//        }

//        [AllowAnonymous]
//        [SwaggerOperation(summary: "Get entity from Country by key", OperationId = "GetCountryById")]
//        [HttpGet("{key}")]
//        public async Task<IActionResult> Get(string key)
//        {
//            //if (!await _permissionService.Authorize(PermissionSystemName.Countries))
//            //    return Forbid();

//            //var country = await _mediator.Send(new GetQuery<CountryDto>() { Id = key });
//            var country = new List<string> {"Canada" ,"USA", "China" };
//            if (!country.Any())
//                return NotFound();

//            return Ok(country.FirstOrDefault());
//        }

//        [AllowAnonymous]
//        [SwaggerOperation(summary: "Get entities from Country", OperationId = "GetCountries")]
//        [HttpGet]
//        [EnableQuery(HandleNullPropagation = HandleNullPropagationOption.False)]
//        public async Task<IActionResult> Get()
//        {
//            //if (!await _permissionService.Authorize(PermissionSystemName.Countries))
//            //    return Forbid();

//            //return Ok(await _mediator.Send(new GetQuery<CountryDto>()));

//            return Ok(new List<string> { "Canada", "USA", "China" });
//        }
//    }
//}
