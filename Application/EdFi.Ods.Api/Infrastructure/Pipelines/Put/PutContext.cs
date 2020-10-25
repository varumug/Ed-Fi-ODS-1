// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.Authorization.Pipeline;

namespace EdFi.Ods.Api.Infrastructure.Pipelines.Put
{
    public class PutContext<TResourceModel, TEntityModel> : IAuthorizationPipelineContext, IHasPersistentModel<TEntityModel>, IHasResource<TResourceModel>, IHasIdentifier
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifier
    {
        private readonly ValidationState validationState;

        public PutContext(TResourceModel resource, ValidationState validationState, ApiKeyContext apiKeyContext, string etagValue = null)
        {
            this.validationState = validationState;
            Resource = resource;
            ApiKeyContext = apiKeyContext;
            ETagValue = etagValue;
        }

        public string ETagValue { get; set; }

        public bool? IsValid
        {
            get { return validationState.IsValid; }
            set { validationState.IsValid = value; }
        }

        public bool EnforceOptimisticLock
        {
            get { return Resource.ETag != null; }
        }

        public Guid Id
        {
            get { return PersistentModel.Id; }
            set { throw new NotImplementedException("Cannot set the identifier of the persistent model through the context."); }
        }

        public TEntityModel PersistentModel { get; set; }

        public TResourceModel Resource { get; set; }

        public ApiKeyContext ApiKeyContext { get; set; }
    }
}
