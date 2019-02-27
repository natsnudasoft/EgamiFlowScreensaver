// <copyright file="IBehaviorConfigurationFormFactory.cs" company="natsnudasoft">
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
    using System.Windows.Forms;

    /// <summary>
    /// Provides an interface describing operations for creating configuration forms and their
    /// associated view models based on a specified <see cref="ConfigurationBehaviorType" />.
    /// </summary>
    public interface IBehaviorConfigurationFormFactory
    {
        /// <summary>
        /// Tries to create a behaviour configuration form and its' associated view model based on
        /// the specified behaviour type.
        /// </summary>
        /// <param name="behaviorType">The type of the behaviour to create a configuration form for.
        /// </param>
        /// <param name="lifetimeDetails">The current lifetime settings of any images emitted.
        /// </param>
        /// <param name="behaviorForm">If successful contains the created behaviour configuration
        /// form.</param>
        /// <param name="behaviorFormViewModel">If successful contains the created view model
        /// associated with the created behaviour configuration form.</param>
        /// <returns><see langword="true"/> if a valid behaviour configuration form and its'
        /// associated view model was created; otherwise <see langword="false"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1021:AvoidOutParameters",
            MessageId = "2#",
            Justification = "We allow this in a 'Try' method.")]
        bool TryCreate(
            ConfigurationBehaviorType behaviorType,
            ILifetimeDetails lifetimeDetails,
            out Form behaviorForm,
            out ConfigurationBehaviorFormViewModel behaviorFormViewModel);
    }
}