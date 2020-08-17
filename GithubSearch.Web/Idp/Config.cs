using IdentityModel;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using static IdentityModel.OidcConstants;

namespace GithubSearch.Web.Idp
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "roles",
                    DisplayName = "Roles",
                    Description = "Your role(s)",
                    UserClaims = new[] { JwtClaimTypes.Role },
                    ShowInDiscoveryDocument = true,
                    Required = true,
                    Emphasize = true,
                    Enabled = true,
                }
            };
        }


        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("api")
                {
                    UserClaims = new[]
                    {
                        JwtClaimTypes.Role,
                        "name",
                        StandardScopes.Email,
                    }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
            };
        }

        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            var redirectUri = configuration["IdpConfig:RedirectUri"];
            var postLogoutRedirectUri = configuration["IdpConfig:PostLogoutRedirectUri"];
            var allowedCorsOrigin = configuration["IdpConfig:AllowedCorsOrigin"];


            var angularClient = new Client
            {
                ClientName = "Github Search App",
                Description = "github search app (SPA)",

                ClientId = "github-search-app",
                RequireClientSecret = false,
                AllowedGrantTypes = new List<string>() { OidcConstants.GrantTypes.Implicit },
                AllowedScopes =
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        StandardScopes.Email,
                        "roles",
                        "api"
                    },
                AllowAccessTokensViaBrowser = true,
                AlwaysSendClientClaims = true,

                AccessTokenLifetime = 18000,
                IdentityTokenLifetime = 18000,
            };

            angularClient.RedirectUris = new[] { redirectUri };
            angularClient.PostLogoutRedirectUris = new[] { postLogoutRedirectUri };

            if (!string.IsNullOrWhiteSpace(allowedCorsOrigin))
            {
                angularClient.AllowedCorsOrigins = new[] { allowedCorsOrigin };
            }

            return new List<Client>
            {
               angularClient
            };
        }
    }
}