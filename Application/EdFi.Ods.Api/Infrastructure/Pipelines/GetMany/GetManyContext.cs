// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Infrastructure.Pipelines;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.Authorization.Pipeline;

namespace EdFi.Ods.Common.Infrastructure.Pipelines.GetMany
{
    public class GetManyContext<TResourceModel, TEntityModel>
        : IAuthorizationPipelineContext, IHasPersistentModel<TEntityModel>, IHasPersistentModels<TEntityModel>, IHasResource<TResourceModel> // IHasETag, IHasIdentifier
        where TResourceModel : IHasETag
        where TEntityModel : class
    {
        public GetManyContext(TResourceModel resourceSpecification, IQueryParameters queryParameters, ApiKeyContext apiKeyContext)
        {
            Resource = resourceSpecification;
            QueryParameters = queryParameters;
            ApiKeyContext = apiKeyContext;
        }

        /// <summary>
        ///     Gets or sets additional query parameters to apply to the search/filter.
        /// </summary>
        public IQueryParameters QueryParameters { get; set; }

        /// <summary>
        ///     Gets or sets the persistent model to be used as a specification for the query.
        /// </summary>
        public TEntityModel PersistentModel { get; set; }

        /// <summary>
        ///     Gets or sets the list of persistent models retrieved from storage.
        /// </summary>
        public IList<TEntityModel> PersistentModels { get; set; }

        /// <summary>
        ///     Gets or sets the resource model to be used as a specification for the query.
        /// </summary>
        public TResourceModel Resource { get; set; }

        public ApiKeyContext ApiKeyContext { get; set; }
    }
}
