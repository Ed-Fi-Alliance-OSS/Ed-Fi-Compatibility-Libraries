﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.EntityFrameworkCore;

namespace EdFi.SecurityCompatiblity53.DataAccess.Contexts
{
    public class SqlServerSecurityContext : SecurityContext
    {
        // The default behavior is appropriate for this sub-class.
        public SqlServerSecurityContext(DbContextOptions options) : base(options) { }
    }
}
