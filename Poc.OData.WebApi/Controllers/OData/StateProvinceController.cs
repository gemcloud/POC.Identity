using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Poc.OData.WebApi.DataLayers.Entities;
using Poc.OData.WebApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.OData.WebApi.Controllers.OData
{

    [Produces("application/json")]
    [Route("odata/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class StateProvinceController : ODataController  // BaseODataController
    {
        #region Properties

        #endregion

        #region Constructor (Ctor) 
        //public StateProvinceController(IMediator mediator, IPermissionService permissionService)
        //{
        //    _mediator = mediator;
        //    _permissionService = permissionService;
        //}

        public StateProvinceController()
        {

        }
        #endregion

        #region methods (Actions)

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [SwaggerOperation(summary: "Get entity from StateProvince by key", OperationId = "GetStateProvinceById")]
        [HttpGet("{key}")]
        public async Task<IActionResult> Get(int key)
        {
            //if (!await _permissionService.Authorize(PermissionSystemName.Countries))
            //    return Forbid();

            //var states = await _mediator.Send(new GetQuery<StateProvinceDto>() { Id = key });
            //if (!states.Any())
            //    return NotFound();

            //return Ok(states);

            var states = dummyState.ContainsKey(key);
            if (!states)
            {
                return NotFound();
            }
            return Ok(dummyState[key]);
        }

        [SwaggerOperation(summary: "Get entities from StateProvince", OperationId = "GetStateProvinces")]
        //[HttpGet]
        //[EnableQuery(HandleNullPropagation = HandleNullPropagationOption.False)]

        [HttpPost("list")]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            //if (!await _permissionService.Authorize(PermissionSystemName.Countries))
            //    return Forbid();

            //return Ok(await _mediator.Send(new GetQuery<StateProvinceDto>()));

            return base.Ok(dummyState.Select(d => d.Value).ToList()); 
        }

        #endregion

        #region Utils & Proviate

        private static readonly IDictionary<int, StateProvince> dummyState = new Dictionary<int, StateProvince>()
        {
            {1 ,  new StateProvince {ID = 1 , CountryId ="CA", Name="BC-Can" } },
            {2 ,  new StateProvince {ID = 2 , CountryId ="CA", Name="AB-Can" } },
            {3 ,  new StateProvince {ID = 3 , CountryId ="CA", Name="ON-Can" } },
            {4 ,  new StateProvince {ID = 20 , CountryId ="USA", Name="Washton DC" } },
            {5 ,  new StateProvince {ID = 30 , CountryId ="USA", Name="Califonia" } }
        };
        #endregion
    }
}
