// <copyright file="EnumHelper.cs" company="natsnudasoft">
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
    using System.Linq;
    using System.Reflection;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class containing helper operations that can be performed on enums or elements of
    /// enums.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets a display name from the specified enum value, using an
        /// <see cref="EnumResourceDisplayNameAttribute"/> if one exists.
        /// </summary>
        /// <typeparam name="T">The enum type of the member that a display name is being retrieved
        /// for.</typeparam>
        /// <param name="enumValue">The value of an enum that a display name is being retrieved for.
        /// </param>
        /// <returns>A <see cref="string"/> containing the display name that was retrieved.
        /// </returns>
        /// <seealso cref="EnumResourceDisplayNameAttribute" />
        public static string GetEnumDisplayName<T>(T enumValue)
        {
            ParameterValidation.IsNotNull(enumValue, nameof(enumValue));

            var enumValueMemberInfo = typeof(T).GetMember(enumValue.ToString()).FirstOrDefault();
            var enumDisplayName = enumValueMemberInfo?.ToString();
            if (enumValueMemberInfo != null)
            {
                var enumResourceDisplayNameAttribute =
                    enumValueMemberInfo.GetCustomAttribute<EnumResourceDisplayNameAttribute>();
                if (enumResourceDisplayNameAttribute != null)
                {
                    enumDisplayName = enumResourceDisplayNameAttribute.DisplayName;
                }
            }

            return enumDisplayName;
        }
    }
}