// <copyright file="ConfigurationBehavior.cs" company="natsnudasoft">
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
    using ProtoBuf;

    /// <summary>
    /// Provides an abstract base class for managing the state of the configuration for a behaviour.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(101, typeof(ColorChangeConfigurationBehavior))]
    [ProtoInclude(102, typeof(ScaleChangeConfigurationBehavior))]
    [ProtoInclude(103, typeof(AlphaChangeConfigurationBehavior))]
    [ProtoInclude(104, typeof(RotationChangeConfigurationBehavior))]
    public abstract class ConfigurationBehavior
    {
        /// <summary>
        /// Gets the type of behaviour that this configuration represents.
        /// </summary>
        public abstract ConfigurationBehaviorType ConfigurationBehaviorType { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ConfigurationBehavior"/> is
        /// enabled.
        /// </summary>
        /// <value><see langword="true"/> if enabled; otherwise, <see langword="false"/>.</value>
        [ProtoMember(1)]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets the description of the behaviour that this configuration represents.
        /// </summary>
        public abstract string Description { get; }
    }
}