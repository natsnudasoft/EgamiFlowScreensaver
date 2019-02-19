// <copyright file="AlphaChangeBehaviorFormViewModel.cs" company="natsnudasoft">
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
    using System.Windows.Forms;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class for managing the state of the backing values for the current state of
    /// configuration for an alpha change behaviour.
    /// </summary>
    /// <seealso cref="ConfigurationBehaviorFormViewModel" />
    public sealed class AlphaChangeBehaviorFormViewModel : ConfigurationBehaviorFormViewModel
    {
        private double transitionTime;
        private float startAlpha;
        private float endAlpha;

        /// <summary>
        /// Gets or sets the alpha value that the behaviour should start from.
        /// </summary>
        public float StartAlpha
        {
            get => this.startAlpha;
            set => this.Set(ref this.startAlpha, value);
        }

        /// <summary>
        /// Gets or sets the alpha value that the behaviour should finish at.
        /// </summary>
        public float EndAlpha
        {
            get => this.endAlpha;
            set => this.Set(ref this.endAlpha, value);
        }

        /// <summary>
        /// Gets or sets the time that the behaviour transition should take (in milliseconds).
        /// </summary>
        public double TransitionTime
        {
            get => this.transitionTime;
            set => this.Set(ref this.transitionTime, value);
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="behavior"/> is
        /// <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">The specified behaviour is not a valid
        /// <see cref="AlphaChangeConfigurationBehavior"/>.</exception>
        public override void UpdateFromBehavior(ConfigurationBehavior behavior)
        {
            ParameterValidation.IsNotNull(behavior, nameof(behavior));

            if (behavior is AlphaChangeConfigurationBehavior alphaChangeConfigurationBehavior)
            {
                this.StartAlpha = alphaChangeConfigurationBehavior.StartAlpha;
                this.EndAlpha = alphaChangeConfigurationBehavior.EndAlpha;
                this.TransitionTime =
                    alphaChangeConfigurationBehavior.TransitionTime.TotalMilliseconds;
            }
            else
            {
                throw new InvalidOperationException(nameof(behavior) + " was an unexpected type.");
            }
        }

        /// <inheritdoc/>
        public override ConfigurationBehavior CreateBehavior()
        {
            return new AlphaChangeConfigurationBehavior
            {
                StartAlpha = this.StartAlpha,
                EndAlpha = this.EndAlpha,
                TransitionTime =
                    new TimeSpan((long)(this.TransitionTime * TimeSpan.TicksPerMillisecond))
            };
        }

        /// <inheritdoc/>
        public override bool Validate(IWin32Window owner) => true;
    }
}