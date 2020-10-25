// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Context
{
    public class CallContextStorage : IContextStorage
    {
        private readonly IDictionary<string, object> _state = new Dictionary<string, object>();

        public void SetValue(string key, object value)
        {
            _state[key] = value;
        }

        public T GetValue<T>(string key)
        {
            return _state.TryGetValue(key, out object data)
                ? (T) data
                : default;
        }
    }
}
