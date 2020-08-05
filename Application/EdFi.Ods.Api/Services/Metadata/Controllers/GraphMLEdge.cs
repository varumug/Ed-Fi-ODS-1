﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Services.Metadata.Controllers
{
    // ReSharper disable once InconsistentNaming
    public class GraphMLEdge
    {
        public GraphMLEdge(string source, string target)
        {
            Source = source;
            Target = target;
        }

        public string Source { get; }

        public string Target { get; }
    }
}
