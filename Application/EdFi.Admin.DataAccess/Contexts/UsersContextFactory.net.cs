﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System;
using System.Collections.Generic;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Admin.DataAccess.Contexts
{
    public class UsersContextFactory : IUsersContextFactory
    {
        private readonly Dictionary<DatabaseEngine, Type> _usersContextTypeByDatabaseEngine = new Dictionary<DatabaseEngine, Type>
        {
            {DatabaseEngine.SqlServer, typeof(SqlServerUsersContext)},
            {DatabaseEngine.Postgres, typeof(PostgresUsersContext)}
        };

        private readonly DatabaseEngine _databaseEngine;

        public UsersContextFactory(IApiConfigurationProvider configurationProvider)
        {
            Preconditions.ThrowIfNull(configurationProvider, nameof(configurationProvider));
            _databaseEngine = configurationProvider.DatabaseEngine;
        }

        public IUsersContext CreateContext()
        {
            if (_usersContextTypeByDatabaseEngine.TryGetValue(_databaseEngine, out Type contextType))
            {
                return Activator.CreateInstance(contextType) as IUsersContext;
            }

            throw new InvalidOperationException(
                $"Cannot create an IUsersContext for database type {_databaseEngine.DisplayName}");
        }
    }
}
#endif