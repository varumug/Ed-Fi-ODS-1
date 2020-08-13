// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.CodeGen.Generators
{
    public class Controllers : ControllersBase
    {
        protected override void Configure()
        {
            BaseNamespaceName = "EdFi.Ods.Api.NetCore.Controllers";
            RequestBaseNamespaceName = "EdFi.Ods.Api.Models.Requests";
        }
    }
}
