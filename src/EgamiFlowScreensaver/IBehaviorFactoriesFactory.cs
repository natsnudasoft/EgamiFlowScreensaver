// <copyright file="IBehaviorFactoriesFactory.cs" company="natsnudasoft">
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
    using System.Collections.Generic;
    using Natsnudasoft.EgamiFlowScreensaver.Config;

    /// <summary>
    /// Provides an interface describing operations to create factories that are capable of creating
    /// behaviours that can be applied to images that are emitted by a screensaver.
    /// </summary>
    public interface IBehaviorFactoriesFactory
    {
        /// <summary>
        /// Creates a collection of factories capable of creating behaviours that can be applied to
        /// images emitted by a screensaver based on the specified list of behaviour configurations.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="configurationBehaviors">The list of configuration behaviours to use as a
        /// template to create the behaviour factories.</param>
        /// <param name="isInfiniteImageEmitMode">A value indicating whether or not images will be
        /// emitted infinitely.</param>
        /// <returns>The collection of factories that was created.</returns>
        IEnumerable<Func<IScreensaverImageItemBehavior>> Create(
            ScreensaverArea screensaverArea,
            IEnumerable<ConfigurationBehavior> configurationBehaviors,
            bool isInfiniteImageEmitMode);
    }
}