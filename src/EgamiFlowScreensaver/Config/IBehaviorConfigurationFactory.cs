// <copyright file="IBehaviorConfigurationFactory.cs" company="natsnudasoft">
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
    /// <summary>
    /// Provides an interface describing operations for creating behaviour configurations based on a
    /// specified <see cref="ConfigurationBehaviorType" />.
    /// </summary>
    public interface IBehaviorConfigurationFactory
    {
        /// <summary>
        /// Creates a new <see cref="ConfigurationBehavior"/> from the specified behaviour type.
        /// </summary>
        /// <param name="behaviorType">The type of the behaviour to create a configuration for.
        /// </param>
        /// <returns>The created <see cref="ConfigurationBehavior"/>.</returns>
        ConfigurationBehavior Create(ConfigurationBehaviorType behaviorType);
    }
}