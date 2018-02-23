using GlobalUnionInt.Services.interfaces;
using LeaseHold.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GlobalUnionInt.Controllers.Api
{
    [RoutePrefix("api/StateProvinces")]
    public class StateProvinceController : ApiController
    {
        IStateProvinceService _stateProvinceService;

        public StateProvinceController(IStateProvinceService stateProvinceService)
        {
            _stateProvinceService = stateProvinceService;
        }

        [Route(), HttpGet]
        public HttpResponseMessage SelectAll()
        {
            try
            {
                IEnumerable<StateProvince> response = _stateProvinceService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            } 
        }
    }
}
