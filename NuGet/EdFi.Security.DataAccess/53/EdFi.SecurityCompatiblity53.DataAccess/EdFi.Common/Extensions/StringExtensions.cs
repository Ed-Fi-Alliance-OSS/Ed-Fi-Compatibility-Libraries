// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text.RegularExpressions;

namespace EdFi.Common.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex _termSplitter = new Regex("([A-Z]([A-Z]*)(?=[A-Z])|[A-Z][a-z0-9]+)", RegexOptions.Compiled);

        /// <summary>
        /// Returns a string that has the first character converted to upper-case.
        /// </summary>
        /// <param name="text">The text to be processed.</param>
        /// <returns>A string that has the first character converted to upper-case.</returns>
        public static string ToMixedCase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text.Length == 1)
            {
                return text;
            }

            return char.ToUpper(text[0]) + text.Substring(1);
        }

        public static bool TryTrimSuffix(this string text, string suffix, out string trimmedText)
        {
            trimmedText = null;

            if (text == null)
            {
                return false;
            }

            int pos = text.LastIndexOf(suffix);

            if (pos < 0)
            {
                return false;
            }

            if (text.Length - pos == suffix.Length)
            {
                trimmedText = text.Substring(0, pos);
                return true;
            }

            ;

            return false;
        }

        public static bool TryReplaceSuffix(this string text, string oldSuffix, string newSuffix, out string newText)
        {
            newText = null;

            string trimmedText;

            if (!text.TryTrimSuffix(oldSuffix, out trimmedText))
            {
                return false;
            }

            newText = trimmedText + newSuffix;
            return true;
        }

        public static bool TryTrimPrefix(this string text, string prefix, out string trimmedText)
        {
            trimmedText = null;

            if (text == null)
            {
                return false;
            }

            if (text.StartsWith(prefix))
            {
                if (text.Length == prefix.Length)
                {
                    trimmedText = string.Empty;
                }
                else
                {
                    trimmedText = text.Substring(prefix.Length);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Provides an extension-based overload method for performing case-insensitive equality checks more succinctly.
        /// </summary>
        /// <param name="text">The string to be evaluated.</param>
        /// <param name="compareText">The string to compare against.</param>
        /// <returns><b>true</b> if the strings are equal (ignoring case); otherwise <b>false</b>.</returns>
        public static bool EqualsIgnoreCase(this string text, string compareText)
        {
            if (text == null)
            {
                return compareText == null;
            }

            return text.Equals(compareText, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
