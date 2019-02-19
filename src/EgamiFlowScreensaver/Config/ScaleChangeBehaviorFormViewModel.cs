// <copyright file="ScaleChangeBehaviorFormViewModel.cs" company="natsnudasoft">
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
    /// configuration for a scale change behaviour.
    /// </summary>
    /// <seealso cref="ConfigurationBehaviorFormViewModel" />
    public sealed class ScaleChangeBehaviorFormViewModel : ConfigurationBehaviorFormViewModel
    {
        private float startScaleX;
        private float startScaleY;
        private float endScaleX;
        private float endScaleY;
        private double transitionTime;

        /// <summary>
        /// Gets or sets the scale along the x axis that the behaviour should start from.
        /// </summary>
        public float StartScaleX
        {
            get => this.startScaleX;
            set => this.Set(ref this.startScaleX, value);
        }

        /// <summary>
        /// Gets or sets the scale along the y axis that the behaviour should start from.
        /// </summary>
        public float StartScaleY
        {
            get => this.startScaleY;
            set => this.Set(ref this.startScaleY, value);
        }

        /// <summary>
        /// Gets or sets the scale along the x axis that the behaviour should finish at.
        /// </summary>
        public float EndScaleX
        {
            get => this.endScaleX;
            set => this.Set(ref this.endScaleX, value);
        }

        /// <summary>
        /// Gets or sets the scale along the y axis that the behaviour should finish at.
        /// </summary>
        public float EndScaleY
        {
            get => this.endScaleY;
            set => this.Set(ref this.endScaleY, value);
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
        /// <see cref="ColorChangeConfigurationBehavior"/>.</exception>
        public override void UpdateFromBehavior(ConfigurationBehavior behavior)
        {
            ParameterValidation.IsNotNull(behavior, nameof(behavior));

            if (behavior is ScaleChangeConfigurationBehavior scaleChangeConfigurationBehavior)
            {
                this.StartScaleX = scaleChangeConfigurationBehavior.StartScaleX;
                this.StartScaleY = scaleChangeConfigurationBehavior.StartScaleY;
                this.EndScaleX = scaleChangeConfigurationBehavior.EndScaleX;
                this.EndScaleY = scaleChangeConfigurationBehavior.EndScaleY;
                this.TransitionTime =
                    scaleChangeConfigurationBehavior.TransitionTime.TotalMilliseconds;
            }
            else
            {
                throw new InvalidOperationException(nameof(behavior) + " was an unexpected type.");
            }
        }

        /// <inheritdoc/>
        public override ConfigurationBehavior CreateBehavior()
        {
            return new ScaleChangeConfigurationBehavior
            {
                StartScaleX = this.StartScaleX,
                StartScaleY = this.StartScaleY,
                EndScaleX = this.EndScaleX,
                EndScaleY = this.EndScaleY,
                TransitionTime =
                    new TimeSpan((long)(this.TransitionTime * TimeSpan.TicksPerMillisecond))
            };
        }

        /// <inheritdoc/>
        public override bool Validate(IWin32Window owner) => true;
    }
}