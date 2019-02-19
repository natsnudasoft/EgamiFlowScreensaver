// <copyright file="BehaviorConfigurationFactory.cs" company="natsnudasoft">
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
    using System;

    /// <summary>
    /// Provides a class capable of creating behaviour configurations based on a specified
    /// <see cref="ConfigurationBehaviorType"/>.
    /// </summary>
    /// <seealso cref="IBehaviorConfigurationFactory" />
    /// <seealso cref="ConfigurationBehaviorType"/>
    public sealed class BehaviorConfigurationFactory : IBehaviorConfigurationFactory
    {
        /// <inheritdoc/>
        /// <exception cref="InvalidOperationException">No method exists for creating a behaviour
        /// configuration from the value specified by <paramref name="behaviorType"/>.</exception>
        public ConfigurationBehavior Create(ConfigurationBehaviorType behaviorType)
        {
            ConfigurationBehavior behavior;
            switch (behaviorType)
            {
                case ConfigurationBehaviorType.ColorChange:
                    behavior = new ColorChangeConfigurationBehavior();
                    break;
                case ConfigurationBehaviorType.AlphaChange:
                    behavior = new AlphaChangeConfigurationBehavior();
                    break;
                case ConfigurationBehaviorType.ScaleChange:
                    behavior = new ScaleChangeConfigurationBehavior();
                    break;
                case ConfigurationBehaviorType.RotationChange:
                    behavior = new RotationChangeConfigurationBehavior();
                    break;
                default:
                    throw new InvalidOperationException("There is no behavior configuration " +
                        "associated with the specified behavior type " +
                        $"({behaviorType}).");
            }

            return behavior;
        }
    }
}