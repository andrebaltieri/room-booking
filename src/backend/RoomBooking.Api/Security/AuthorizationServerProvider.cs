using Microsoft.Owin.Security.OAuth;
using RoomBooking.Api.Resources;
using RoomBooking.Business.Services;
using RoomBooking.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace RoomBooking.Api.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {            
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                using (IAuthenticationService service = new AuthenticationService())
                {
                    var user = service.Authenticate(context.UserName, context.Password);

                    if (user == null)
                    {
                        context.SetError("invalid_grant", Messages.UsernameOrPasswordIsInvalid);
                        return;
                    }

                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                    identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
                    identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));

                    var roles = new List<string>();
                    foreach (var role in user.Roles)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
                        roles.Add(role.Name);
                    }

                    GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                    Thread.CurrentPrincipal = principal;

                    context.Validated(identity);
                }
            }
            catch
            {
                context.SetError("invalid_grant", Messages.FailedToRetrieveUserInformation);
            }
        }
    }
}