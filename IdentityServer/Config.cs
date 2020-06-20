// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[] 
            { new ApiResource("employee-api", "Employee API")};
        
        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                new Client
                {
                    ClientName = "Employee Project",
                    ClientId = "employee-project",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:60338/signin-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
        
    }
}