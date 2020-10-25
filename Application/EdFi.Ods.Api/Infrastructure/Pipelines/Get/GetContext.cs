﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.Authorization.Pipeline;

namespace EdFi.Ods.Api.Infrastructure.Pipelines.Get
{
    public class GetContext<TEntityModel> : IAuthorizationPipelineContext, IHasPersistentModel<TEntityModel>, IHasETag, IHasIdentifier
        where TEntityModel : class
    {
        public GetContext(Guid id, string etag, ApiKeyContext apiKeyContext)
        {
            Id = id;
            ETag = etag;
            ApiKeyContext = apiKeyContext;
        }

        public string ETag { get; set; }

        public ApiKeyContext ApiKeyContext { get; set; }

        public Guid Id { get; set; }

        public TEntityModel PersistentModel { get; set; }
    }
}
