﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.SecurityCompatiblity53.DataAccess.Contexts;
using EdFi.SecurityCompatiblity53.DataAccess.Models;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;

namespace EdFi.SecurityCompatiblity53.DataAccess.UnitTests
{
    public class SecurityContextMock
    {
        /// <summary>
        /// Sets up a queryable fake security context with minimal data
        /// </summary>
        /// <returns></returns>
        public static ISecurityContext GetMockedSecurityContext()
        {
            var securityContext = A.Fake<ISecurityContext>();
            // The underlying SecurityRepository implementation expects this application, so force it to be there in the fake
            securityContext.Applications = GetFakeDbSet<Application>();
            securityContext.Actions = GetFakeDbSet<Action>();
            securityContext.AuthorizationStrategies = GetFakeDbSet<AuthorizationStrategy>();
            securityContext.ClaimSets = GetFakeDbSet<ClaimSet>();
            securityContext.ClaimSetResourceClaims = GetFakeDbSet<ClaimSetResourceClaim>();
            securityContext.ResourceClaims = GetFakeDbSet<ResourceClaim>();
            securityContext.ResourceClaimAuthorizationMetadatas = GetFakeDbSet<ResourceClaimAuthorizationMetadata>();

            return securityContext;
        }

        private static DbSet<T> GetFakeDbSet<T>() where T : class
        {
            return null;
        }
    }
}
