// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Dtos;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Features.RouteInformations
{
    public class ProfilesOpenApiMetadataRouteInformation : IOpenApiMetadataRouteInformation
    {

        private readonly ApiSettings _apiSettings;

        public ProfilesOpenApiMetadataRouteInformation(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }
        public RouteInformation GetRouteInformation()
            => new RouteInformation
            {
                Name = MetadataRouteConstants.Profiles,
                Template = $"{CreateRoute()}/swagger.json"
            };

        private string CreateRoute()
        {
            //metadata/data/v3/profiles/test-profile-resource-includeonly/swagger.json
            string prefix = $"metadata/data/v{ApiVersionConstants.Ods}/";

            if (_apiSettings.GetApiMode() == ApiMode.YearSpecific)
            {
                prefix += RouteConstants.SchoolYearFromRoute;
            }

            if (_apiSettings.GetApiMode() == ApiMode.InstanceYearSpecific)
            {
                prefix += RouteConstants.InstanceIdFromRoute;
                prefix += RouteConstants.SchoolYearFromRoute;
            }

            prefix += "profiles/{profileName}";

            return prefix.TrimSuffix("/");
        }
    }
}