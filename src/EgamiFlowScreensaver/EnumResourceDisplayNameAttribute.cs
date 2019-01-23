// <copyright file="EnumResourceDisplayNameAttribute.cs" company="natsnudasoft">
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
    using System.Reflection;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Represents an attribute to define a display name on an enum value that is retrieved from a
    /// specified resource type.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class EnumResourceDisplayNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumResourceDisplayNameAttribute"/> class.
        /// </summary>
        /// <param name="resourceType">The <see cref="Type"/> that the resource is to be retrieved
        /// from.</param>
        /// <param name="enumDisplayNameResourceName">The name of the resource in the specified
        /// resource <see cref="Type"/> to retrieve the enum display name from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="resourceType"/>, or
        /// <paramref name="enumDisplayNameResourceName"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="enumDisplayNameResourceName"/> is
        /// empty.</exception>
        /// <exception cref="InvalidOperationException">The specified resource was not found
        /// on the specified resource <see cref="Type"/>.</exception>
        public EnumResourceDisplayNameAttribute(
            Type resourceType,
            string enumDisplayNameResourceName)
        {
            ParameterValidation.IsNotNull(resourceType, nameof(resourceType));
            ParameterValidation.IsNotNull(
                enumDisplayNameResourceName,
                nameof(enumDisplayNameResourceName));
            ParameterValidation.IsNotEmpty(
                enumDisplayNameResourceName,
                nameof(enumDisplayNameResourceName));

            var enumDisplayNameResourceNameProperty = resourceType.GetProperty(
                enumDisplayNameResourceName,
                BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (enumDisplayNameResourceNameProperty == null)
            {
                throw new InvalidOperationException("Specified resource not found.");
            }

            this.DisplayName = (string)enumDisplayNameResourceNameProperty.GetValue(null);
        }

        /// <summary>
        /// Gets the display name to show for the enum this
        /// <see cref="EnumResourceDisplayNameAttribute"/> is attached to.
        /// </summary>
        public string DisplayName { get; }
    }
}