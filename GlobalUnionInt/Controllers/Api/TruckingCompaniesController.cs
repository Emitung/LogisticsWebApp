using GlobalUnionInt.Models.Domains;
using GlobalUnionInt.Models.Requests;
using GlobalUnionInt.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GlobalUnionInt.Controllers.Api
{
    [RoutePrefix("api/TruckingCompanies")]
    public class TruckingCompaniesController : ApiController
    {

        ITruckingCompaniesService _truckingCompaniesService;

        public TruckingCompaniesController(ITruckingCompaniesService truckingCompaniesService)
        {
            _truckingCompaniesService = truckingCompaniesService;
        }

        [Route(), HttpPost]
        public HttpResponseMessage Insert(TruckingCompaniesAddRequest model)
        {
            try
            {
                int id = _truckingCompaniesService.Insert(model);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route(), HttpGet]
        public HttpResponseMessage SelectAll()
        {
            try
            {
                IEnumerable<TruckingCompanies> response = _truckingCompaniesService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(TruckingCompaniesUpdateRequest model)
        {
            try
            {
                _truckingCompaniesService.Update(model);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _truckingCompaniesService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
