using IdentityModel;
using IdentityServer4;
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
                //new ApiResource("api", "Github Search API")
                //{
                ////    ApiSecrets = { new Secret("secret".Sha256()) },
                //    UserClaims = new[]
                //    {
                //        JwtClaimTypes.Role,
                //        StandardScopes.OpenId,
                //        StandardScopes.Profile,
                //        StandardScopes.Email,
                //    }
                //}
            };
        }

        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            var redirectUri = configuration["IdpConfig:RedirectUri"];
            var postLogoutRedirectUri = configuration["IdpConfig:RedirectUri"];
            var allowedCorsOrigin = configuration["IdpConfig:AllowedCorsOrigin"];
            return new List<Client>
            {
                new Client
                {
                    ClientName = "Github Search App",
                    Description = "github search app (SPA)",


                    ClientId = "github-search-app",
                    RequireClientSecret = false,
                    AllowedGrantTypes = new List<string>(){
                        OidcConstants.GrantTypes.Implicit
                    },
                    RedirectUris =
                    {
                        redirectUri
                    },
                    PostLogoutRedirectUris = {
                        postLogoutRedirectUri
                    },
                    AllowedCorsOrigins = {
                         
                    },

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
                }
            };
        }
    }
}