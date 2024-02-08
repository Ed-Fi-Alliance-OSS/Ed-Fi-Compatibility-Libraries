// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Indicates whether the supplied value is the default value for its type.
        /// </summary>
        /// <param name="value">The value to be evaluated.</param>
        /// <typeparam name="T">The Type of the value.</typeparam>
        /// <returns><b>true</b> if the value is the default value for the type; otherwise <b>false</b>.</returns>
        public static bool IsDefaultValue<T>(this T value)
        {
            return value == null || value.Equals(default(T));
        }
    }
}
