using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace ExpendituresALevel.Filters
{
    public class MyAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext actionContext)
        {
            if (Authorize(actionContext))
            {
                return;
            }
            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext actionContext)
        {
            var challengeMessage = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            challengeMessage.Headers.Add("WWW-Authenticate", "Basic");
            throw new HttpResponseException(challengeMessage);
        }

        private bool Authorize(AuthorizationContext actionContext)
        {
            try
            {
                string ipAddress = actionContext.HttpContext.Request.UserHostAddress;


                if (IsIpAddressAllowed(ipAddress.Trim()))
                {
                    return false;
                }

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool IsIpAddressAllowed(string IpAddress)
        {
            if (!string.IsNullOrWhiteSpace(IpAddress))
            {
                var allowIPAddress = ConfigurationManager.AppSettings["AllowedIPAddresses"];
                if (string.IsNullOrEmpty(allowIPAddress))
                    return true;
                string[] addresses = allowIPAddress.Split(',');

                return addresses.Where(a => a.Trim().Equals(IpAddress, StringComparison.InvariantCultureIgnoreCase)).Any();
            }
            return false;
        }
    }
}