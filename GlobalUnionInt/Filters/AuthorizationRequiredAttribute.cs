using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace GlobalUnionInt.Filters
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext) //OnActionExecuting is part of ActionFIlterAttribute override functions for custom exception checks.
        {
            if (actionContext.Request.Headers.Contains("Token"))
            {
                string tokenVal = actionContext.Request.Headers.GetValues("Token").First();
                string hardcodedTokenCheck = "shake_and_bake";
                if (tokenVal != hardcodedTokenCheck)
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                    { ReasonPhrase = "Tokens do not match!" };
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                { ReasonPhrase = "No token found!" };
            }
            base.OnActionExecuting(actionContext);
        }
    }
}