// <copyright file="ConfigurationBehaviorType.cs" company="natsnudasoft">
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

namespace Natsnudasoft.EgamiFlowScreensaver.Config
{
    using Natsnudasoft.EgamiFlowScreensaver.Properties;

    /// <summary>
    /// Represents values of available behaviours that have associated configurations.
    /// </summary>
    public enum ConfigurationBehaviorType
    {
        /// <summary>
        /// Represents a configuration for a colour change behaviour.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageItemBehaviorTypeColorChange")]
        ColorChange,

        /// <summary>
        /// Represents a configuration for a scale change behaviour.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageItemBehaviorTypeScaleChange")]
        ScaleChange,

        /// <summary>
        /// Represents a configuration for an alpha change behaviour.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageItemBehaviorTypeAlphaChange")]
        AlphaChange,

        /// <summary>
        /// Represents a configuration for a rotation change behaviour.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageItemBehaviorTypeRotationChange")]
        RotationChange
    }
}