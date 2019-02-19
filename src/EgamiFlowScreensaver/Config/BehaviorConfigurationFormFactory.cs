// <copyright file="BehaviorConfigurationFormFactory.cs" company="natsnudasoft">
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
    /// Provides a class capable of creating configuration forms and their associated view models
    /// based on a specified <see cref="ConfigurationBehaviorType" />.
    /// </summary>
    /// <seealso cref="IBehaviorConfigurationFormFactory" />
    /// <seealso cref="ConfigurationBehaviorType" />
    public class BehaviorConfigurationFormFactory : IBehaviorConfigurationFormFactory
    {
        /// <inheritdoc/>
        public bool TryCreate(
            ConfigurationBehaviorType behaviorType,
            out Form behaviorForm,
            out ConfigurationBehaviorFormViewModel behaviorFormViewModel)
        {
            bool result;
            switch (behaviorType)
            {
                case ConfigurationBehaviorType.ColorChange:
                    CreateColorChangeForm(out behaviorForm, out behaviorFormViewModel);
                    result = true;
                    break;
                case ConfigurationBehaviorType.ScaleChange:
                    CreateScaleChangeForm(out behaviorForm, out behaviorFormViewModel);
                    result = true;
                    break;
                case ConfigurationBehaviorType.AlphaChange:
                    CreateAlphaChangeForm(out behaviorForm, out behaviorFormViewModel);
                    result = true;
                    break;
                case ConfigurationBehaviorType.RotationChange:
                    CreateRotationChangeForm(out behaviorForm, out behaviorFormViewModel);
                    result = true;
                    break;
                default:
                    behaviorFormViewModel = default;
                    behaviorForm = default;
                    result = false;
                    break;
            }

            return result;
        }

        private static void CreateColorChangeForm(
            out Form behaviorForm,
            out ConfigurationBehaviorFormViewModel behaviorFormViewModel)
        {
            var colorChangeBehaviorFormViewModel = new ColorChangeBehaviorFormViewModel();
            behaviorFormViewModel = colorChangeBehaviorFormViewModel;
            behaviorForm = new ColorChangeBehaviorForm(colorChangeBehaviorFormViewModel);
        }

        private static void CreateScaleChangeForm(
            out Form behaviorForm,
            out ConfigurationBehaviorFormViewModel behaviorFormViewModel)
        {
            var scaleChangeBehaviorFormViewModel = new ScaleChangeBehaviorFormViewModel();
            behaviorFormViewModel = scaleChangeBehaviorFormViewModel;
            behaviorForm = new ScaleChangeBehaviorForm(scaleChangeBehaviorFormViewModel);
        }

        private static void CreateAlphaChangeForm(
            out Form behaviorForm,
            out ConfigurationBehaviorFormViewModel behaviorFormViewModel)
        {
            var alphaChangeBehaviorFormViewModel = new AlphaChangeBehaviorFormViewModel();
            behaviorFormViewModel = alphaChangeBehaviorFormViewModel;
            behaviorForm = new AlphaChangeBehaviorForm(alphaChangeBehaviorFormViewModel);
        }

        private static void CreateRotationChangeForm(
            out Form behaviorForm,
            out ConfigurationBehaviorFormViewModel behaviorFormViewModel)
        {
            var rotationChangeBehaviorFormViewModel = new RotationChangeBehaviorFormViewModel();
            behaviorFormViewModel = rotationChangeBehaviorFormViewModel;
            behaviorForm = new RotationChangeBehaviorForm(rotationChangeBehaviorFormViewModel);
        }
    }
}