﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            //new ApiScope("scope2"),
        };

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
                {
                    Scopes = { "scope1" }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            var client = new Client
            {
                ClientId = "client",

                // no interactive user, use the clientid/secret for authentication
                //AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedGrantTypes = GrantTypes.Hybrid,

                RedirectUris = { "https://localhost:5001/oauth2/callback" },

                //指定基于授权码的令牌请求是否需要证明密钥（默认为true）。
                // RequirePkce = false 之后请求授权服务器就不需要提供URL参数code_challenge和code_challenge_method
                RequirePkce = false,

                // secret for authentication
                ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                // scopes that client has access to
                //AllowedScopes = { "api1" }
                AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "scope1"
                    },

                // 是否允许浏览器传入 access token。默认值 false。
                //AllowAccessTokensViaBrowser = true,
                AlwaysIncludeUserClaimsInIdToken = true,

                AllowOfflineAccess = true
            };

            if (client.AllowedScopes.Contains("openid"))
            {
                if (client.AllowedScopes.Contains("profile"))
                {
                    if (client.AllowedScopes.Contains("api1"))
                    {

                    }
                }
            }
            
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
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }
    }
}
