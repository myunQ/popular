using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace MyIdentityServer
{
    public static class ConfigData
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiScope> GetScopes() => new ApiScope[]
        {
            new ApiScope("scope1"),
            new ApiScope("scope2")
        };

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
                {
                    Scopes = { "scope1" }
                },

                new ApiResource("api2", "My API 2")
                {
                    Scopes = { "scope2" }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            var client = new Client
            {
                ClientId = "client",

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.Implicit,

                //指定基于授权码的令牌请求是否需要证明密钥（默认为true）。
                // RequirePkce = false 之后请求授权服务器就不需要提供URL参数code_challenge和code_challenge_method
                //RequirePkce = false,

                // 登录成功回调处理地址，处理回调返回的数据
                RedirectUris = { "https://localhost:44363/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:44363/signout-callback-oidc" },

                // scopes that client has access to
                AllowedScopes = {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "scope1",
                    "scope2"
                },

                // 是否允许浏览器传入 access token。默认值 false。
                //AllowAccessTokensViaBrowser = true,
                //AlwaysIncludeUserClaimsInIdToken = true,

                //AllowOfflineAccess = true
            };

           
            return new List<Client>
            {
                client
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims = new []
                    {
                        new Claim("name", "Alice"),
                        new Claim("website", "https://alice.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",
                    Claims = new []
                    {
                        new Claim("name", "Bob"),
                        new Claim("website", "https://bob.com")
                    }
                }
            };
        }
    }
}
