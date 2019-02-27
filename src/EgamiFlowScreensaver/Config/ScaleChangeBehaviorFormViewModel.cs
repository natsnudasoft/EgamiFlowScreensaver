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
    using Natsnudasoft.EgamiFlowScreensaver.Properties;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class for managing the state of the backing values for the current state of
    /// configuration for a scale change behaviour.
    /// </summary>
    /// <seealso cref="ConfigurationBehaviorFormViewModel" />
    public sealed class ScaleChangeBehaviorFormViewModel : ConfigurationBehaviorFormViewModel
    {
        private readonly ILifetimeDetails lifetimeDetails;
        private float startScaleX;
        private float startScaleY;
        private float endScaleX;
        private float endScaleY;
        private double transitionTime;
        private bool endTransitionEnabled;
        private float endTransitionScaleX;
        private float endTransitionScaleY;
        private double endTransitionTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScaleChangeBehaviorFormViewModel"/> class.
        /// </summary>
        /// <param name="lifetimeDetails">The current lifetime settings of any images emitted.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="lifetimeDetails"/> is
        /// <see langword="null"/>.</exception>
        public ScaleChangeBehaviorFormViewModel(ILifetimeDetails lifetimeDetails)
        {
            ParameterValidation.IsNotNull(lifetimeDetails, nameof(lifetimeDetails));

            this.lifetimeDetails = lifetimeDetails;
        }

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

        /// <summary>
        /// Gets a value indicating whether or not images will be emitted infinitely.
        /// </summary>
        public bool IsInfiniteImageEmitMode
        {
            get => this.lifetimeDetails.IsInfiniteImageEmitMode;
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the ending transition will be enabled for
        /// the image item this behaviour is attached to.
        /// </summary>
        /// <value><see langword="true"/> if the ending transition will be enabled for the image
        /// item this behaviour is attached to; otherwise <see langword="false"/>.</value>
        public bool EndTransitionEnabled
        {
            get => this.endTransitionEnabled;
            set => this.Set(ref this.endTransitionEnabled, value && this.IsInfiniteImageEmitMode);
        }

        /// <summary>
        /// Gets or sets the scale value along the x axis that the behaviour will finish at when the
        /// image item it is attached to is being destroyed.
        /// </summary>
        public float EndTransitionScaleX
        {
            get => this.endTransitionScaleX;
            set => this.Set(ref this.endTransitionScaleX, value);
        }

        /// <summary>
        /// Gets or sets the scale value along the y axis that the behaviour will finish at when the
        /// image item it is attached to is being destroyed.
        /// </summary>
        public float EndTransitionScaleY
        {
            get => this.endTransitionScaleY;
            set => this.Set(ref this.endTransitionScaleY, value);
        }

        /// <summary>
        /// Gets or sets the time that the behaviour will take to transition when the image item
        /// it is attached to is being destroyed (in milliseconds).
        /// </summary>
        public double EndTransitionTime
        {
            get => this.endTransitionTime;
            set => this.Set(ref this.endTransitionTime, value);
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
                this.EndTransitionEnabled = scaleChangeConfigurationBehavior.EndTransitionEnabled;
                this.EndTransitionScaleX = scaleChangeConfigurationBehavior.EndTransitionScaleX;
                this.EndTransitionScaleY = scaleChangeConfigurationBehavior.EndTransitionScaleY;
                this.EndTransitionTime =
                    scaleChangeConfigurationBehavior.EndTransitionTime.TotalMilliseconds;
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
                    new TimeSpan((long)(this.TransitionTime * TimeSpan.TicksPerMillisecond)),
                EndTransitionEnabled = this.EndTransitionEnabled,
                EndTransitionScaleX = this.EndTransitionScaleX,
                EndTransitionScaleY = this.EndTransitionScaleY,
                EndTransitionTime =
                    new TimeSpan((long)(this.EndTransitionTime * TimeSpan.TicksPerMillisecond))
            };
        }

        /// <inheritdoc/>
        public override bool Validate(IWin32Window owner)
        {
            var validated = true;
            if (this.IsInfiniteImageEmitMode &&
                this.TransitionTime > this.lifetimeDetails.ImageEmitLifetime)
            {
                if (MessageBox.Show(
                    owner,
                    Resources.TransitionTimeLessThanLifetimeText,
                    Resources.TransitionTimeLessThanLifetimeCaption,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    validated = false;
                }
            }

            return validated;
        }
    }
}