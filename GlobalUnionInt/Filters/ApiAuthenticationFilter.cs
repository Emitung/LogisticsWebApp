using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;

namespace GlobalUnionInt.Filters
{
    public class ApiAuthenticationFilter : GenericAuthenticationFilter
    {
        public override bool OnAuthorizeUser(string userName, string password, HttpActionContext context)
        {
            //TODO: Do database lookup here and validate username and password
            if(userName == "rickybobby" && password == "Password1!")
            {
                BasicAuthenticationIdentity basicIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if(basicIdentity != null)
                {
                    //these could come from your database
                    basicIdentity.UserId = 2;
                    basicIdentity.FullName = "Ricky Bobby";
                }
                return true;
            }

            //username and password did not match
            return false;
        }
    }
}