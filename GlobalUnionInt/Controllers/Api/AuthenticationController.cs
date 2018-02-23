using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GlobalUnionInt.Filters;
using System.Threading;

namespace GlobalUnionInt.Controllers.Api
{
    [ApiAuthenticationFilter]
    [RoutePrefix("api/auths")]
    public class AuthenticationController : ApiController
    {
        [Route("login"), HttpPost]
        public HttpResponseMessage Authenticate()
        {
            if(Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                BasicAuthenticationIdentity identity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (identity != null)
                    return GetAuthToken();
            }

            return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "No token created");
        }

        public HttpResponseMessage GetAuthToken()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", "shake_and_bake");
            response.Headers.Add("TokenExpires", DateTime.Now.AddHours(1).ToString());
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpires");
            return response;
        }
    }
}
