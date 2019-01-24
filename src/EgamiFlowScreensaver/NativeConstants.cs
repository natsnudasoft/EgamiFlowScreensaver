// <copyright file="NativeConstants.cs" company="natsnudasoft">
// Copyright (c) Adrian John Dunstan. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace Natsnudasoft.EgamiFlowScreensaver
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines constants for native methods imported via <see cref="DllImportAttribute"/>.
    /// </summary>
    public static class NativeConstants
    {
#pragma warning disable SA1310 // Field names must not contain underscore
        /// <summary>
        /// The WS_CHILD constant. Imported from p/invoke.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1707:IdentifiersShouldNotContainUnderscores",
            Justification = "Preserving original P/Invoke names.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1709:IdentifiersShouldBeCasedCorrectly",
            MessageId = "CHILD",
            Justification = "Preserving original P/Invoke names.")]
        [CLSCompliant(false)]
        public const uint WS_CHILD = 1073741824;

        /// <summary>
        /// The HWND_MESSAGE constant. Imported from p/invoke.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1707:IdentifiersShouldNotContainUnderscores",
            Justification = "Preserving original P/Invoke names.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1709:IdentifiersShouldBeCasedCorrectly",
            MessageId = "HWND",
            Justification = "Preserving original P/Invoke names.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA1709:IdentifiersShouldBeCasedCorrectly",
            MessageId = "MESSAGE",
            Justification = "Preserving original P/Invoke names.")]
        public static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);
#pragma warning restore SA1310 // Field names must not contain underscore
    }
}