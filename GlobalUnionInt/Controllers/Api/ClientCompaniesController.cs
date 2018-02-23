using GlobalUnionInt.Models.Domains;
using GlobalUnionInt.Models.Requests;
using GlobalUnionInt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GlobalUnionInt.Controllers.Api
{
    [RoutePrefix("api/ClientCompanies")]
    public class ClientCompaniesController : ApiController
    {
        IClientCompaniesService _clientCompaniesService;

        public ClientCompaniesController(IClientCompaniesService clientCompaniesService)
        {
            _clientCompaniesService = clientCompaniesService;
        }

        [Route(), HttpPost]
        public HttpResponseMessage Insert(ClientCompaniesAddRequest model)
        {
            try
            {
                int id = _clientCompaniesService.Insert(model);
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
                IEnumerable<ClientCompanies> response = _clientCompaniesService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(ClientCompaniesUpdateRequest model)
        {
            try
            {
                _clientCompaniesService.Update(model);
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
                _clientCompaniesService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
