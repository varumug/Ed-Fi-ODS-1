﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Api.NHibernate.Architecture
{
    public interface IEdFiDescriptorReflectionProvider
    {
        /// <summary>
        /// Returns dictionary of all Descriptor entity type full names keyed by entity name.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, string> GetDescriptorEntityNameMapping();
    }
}
