// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Infrastructure.Pipelines;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.Authorization.Pipeline;

namespace EdFi.Ods.Common.Infrastructure.Pipelines.Delete
{
    public class DeleteContext : IAuthorizationPipelineContext, IHasIdentifier
    {
        public DeleteContext(Guid identifier, ApiKeyContext apiKeyContext, string etagValue = null)
        {
            Id = identifier;
            ApiKeyContext = apiKeyContext;

            if (!string.IsNullOrWhiteSpace(etagValue))
            {
                ETag = etagValue;
            }
        }

        public string ETag { get; set; }

        public Guid Id { get; set; }

        public ApiKeyContext ApiKeyContext { get; set; }
    }
}
