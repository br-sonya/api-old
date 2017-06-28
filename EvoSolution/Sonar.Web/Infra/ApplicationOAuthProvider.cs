using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Sonar.BLL;
using Sonar.BLL.Exceptions;
using Sonar.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Sonar.Web.Infra
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                using (var dbContext = new SonarFrameworkDbContext())
                {
                    var bll = new UserAccountBLL(new UserAccountRepository(dbContext), dbContext);

                    var email = context.UserName;
                    var password = context.Password;

                    var user = await bll.Login(email, password);

                    ClaimsIdentity oAuthIdentity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);

                    oAuthIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Name));

                    AuthenticationProperties properties = new AuthenticationProperties(new Dictionary<string, string>
                    {
                        { "userId", user.Id.ToString() },
                        { "name", user.Name }
                    });

                    var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                    context.Validated(ticket);
                }
            }
            catch (BusinessException ex)
            {
                context.SetError("invalid_grant", ex.Message);
                return;
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }
    }
}