// <copyright file="RotationChangeBehaviorFormViewModel.cs" company="natsnudasoft">
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
    /// configuration for a rotation change behaviour.
    /// </summary>
    /// <seealso cref="ConfigurationBehaviorFormViewModel" />
    public sealed class RotationChangeBehaviorFormViewModel : ConfigurationBehaviorFormViewModel
    {
        private readonly ILifetimeDetails lifetimeDetails;
        private double transitionTime;
        private float startRotation;
        private float endRotation;
        private bool randomlyInvertRotation;
        private bool endTransitionEnabled;
        private float endTransitionRotation;
        private double endTransitionTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="RotationChangeBehaviorFormViewModel"/>
        /// class.
        /// </summary>
        /// <param name="lifetimeDetails">The current lifetime settings of any images emitted.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="lifetimeDetails"/> is
        /// <see langword="null"/>.</exception>
        public RotationChangeBehaviorFormViewModel(ILifetimeDetails lifetimeDetails)
        {
            ParameterValidation.IsNotNull(lifetimeDetails, nameof(lifetimeDetails));

            this.lifetimeDetails = lifetimeDetails;
        }

        /// <summary>
        /// Gets or sets the rotation value that the behaviour should start from.
        /// </summary>
        public float StartRotation
        {
            get => this.startRotation;
            set => this.Set(ref this.startRotation, value);
        }

        /// <summary>
        /// Gets or sets the rotation value that the behaviour should finish at.
        /// </summary>
        public float EndRotation
        {
            get => this.endRotation;
            set => this.Set(ref this.endRotation, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the behaviour should randomly invert the values
        /// of rotation each time an image with this behaviour attached is emitted.
        /// </summary>
        public bool RandomlyInvertRotation
        {
            get => this.randomlyInvertRotation;
            set => this.Set(ref this.randomlyInvertRotation, value);
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
        /// Gets or sets the rotation value that the behaviour will finish at when the image item
        /// it is attached to is being destroyed.
        /// </summary>
        public float EndTransitionRotation
        {
            get => this.endTransitionRotation;
            set => this.Set(ref this.endTransitionRotation, value);
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
        /// <see cref="RotationChangeConfigurationBehavior"/>.</exception>
        public override void UpdateFromBehavior(ConfigurationBehavior behavior)
        {
            ParameterValidation.IsNotNull(behavior, nameof(behavior));

            if (behavior is RotationChangeConfigurationBehavior rotationChangeConfigurationBehavior)
            {
                this.StartRotation = rotationChangeConfigurationBehavior.StartRotation;
                this.EndRotation = rotationChangeConfigurationBehavior.EndRotation;
                this.RandomlyInvertRotation =
                    rotationChangeConfigurationBehavior.RandomlyInvertRotation;
                this.TransitionTime =
                    rotationChangeConfigurationBehavior.TransitionTime.TotalMilliseconds;
                this.EndTransitionEnabled =
                    rotationChangeConfigurationBehavior.EndTransitionEnabled;
                this.EndTransitionRotation =
                    rotationChangeConfigurationBehavior.EndTransitionRotation;
                this.EndTransitionTime =
                    rotationChangeConfigurationBehavior.EndTransitionTime.TotalMilliseconds;
            }
            else
            {
                throw new InvalidOperationException(nameof(behavior) + " was an unexpected type.");
            }
        }

        /// <inheritdoc/>
        public override ConfigurationBehavior CreateBehavior()
        {
            return new RotationChangeConfigurationBehavior
            {
                StartRotation = this.StartRotation,
                EndRotation = this.EndRotation,
                RandomlyInvertRotation = this.RandomlyInvertRotation,
                TransitionTime =
                    new TimeSpan((long)(this.TransitionTime * TimeSpan.TicksPerMillisecond)),
                EndTransitionEnabled = this.EndTransitionEnabled,
                EndTransitionRotation = this.EndTransitionRotation,
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