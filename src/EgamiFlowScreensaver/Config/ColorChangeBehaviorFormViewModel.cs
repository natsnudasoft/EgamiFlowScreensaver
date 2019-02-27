﻿// <copyright file="ColorChangeBehaviorFormViewModel.cs" company="natsnudasoft">
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
    using System.Drawing;
    using System.Windows.Forms;
    using Natsnudasoft.EgamiFlowScreensaver.Properties;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class for managing the state of the backing values for the current state of
    /// configuration for a colour change behaviour.
    /// </summary>
    /// <seealso cref="ConfigurationBehaviorFormViewModel" />
    public sealed class ColorChangeBehaviorFormViewModel : ConfigurationBehaviorFormViewModel
    {
        private readonly ILifetimeDetails lifetimeDetails;
        private double transitionTime;
        private bool endTransitionEnabled;
        private Color endTransitionColor;
        private double endTransitionTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorChangeBehaviorFormViewModel"/> class.
        /// </summary>
        /// <param name="lifetimeDetails">The current lifetime settings of any images emitted.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="lifetimeDetails"/> is
        /// <see langword="null"/>.</exception>
        public ColorChangeBehaviorFormViewModel(ILifetimeDetails lifetimeDetails)
        {
            ParameterValidation.IsNotNull(lifetimeDetails, nameof(lifetimeDetails));

            this.lifetimeDetails = lifetimeDetails;
        }

        /// <summary>
        /// Gets the colour that the behaviour should start from.
        /// </summary>
        public Color StartColor { get; private set; }

        /// <summary>
        /// Gets the colour that the behaviour should finish at.
        /// </summary>
        public Color EndColor { get; private set; }

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
        /// Gets or sets the colour that the behaviour will finish at when the image item it is
        /// attached to is being destroyed.
        /// </summary>
        public Color EndTransitionColor
        {
            get => this.endTransitionColor;
            set => this.Set(ref this.endTransitionColor, value);
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

        /// <summary>
        /// Displays a dialog allowing the start colour to be selected.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        public void ChooseStartColor(IWin32Window owner)
        {
            if (ChooseColor(owner, this.StartColor, out var newColor))
            {
                this.StartColor = newColor;
            }
        }

        /// <summary>
        /// Displays a dialog allowing the end colour to be selected.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        public void ChooseEndColor(IWin32Window owner)
        {
            if (ChooseColor(owner, this.EndColor, out var newColor))
            {
                this.EndColor = newColor;
            }
        }

        /// <summary>
        /// Displays a dialog allowing the end transition colour to be selected.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        public void ChooseEndTransitionColor(IWin32Window owner)
        {
            if (ChooseColor(owner, this.EndTransitionColor, out var newColor))
            {
                this.EndTransitionColor = newColor;
            }
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="behavior"/> is
        /// <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">The specified behaviour is not a valid
        /// <see cref="ColorChangeConfigurationBehavior"/>.</exception>
        public override void UpdateFromBehavior(ConfigurationBehavior behavior)
        {
            ParameterValidation.IsNotNull(behavior, nameof(behavior));

            if (behavior is ColorChangeConfigurationBehavior colorChangeConfigurationBehavior)
            {
                this.StartColor = colorChangeConfigurationBehavior.StartColor;
                this.EndColor = colorChangeConfigurationBehavior.EndColor;
                this.TransitionTime =
                    colorChangeConfigurationBehavior.TransitionTime.TotalMilliseconds;
                this.EndTransitionEnabled = colorChangeConfigurationBehavior.EndTransitionEnabled;
                this.EndTransitionColor = colorChangeConfigurationBehavior.EndTransitionColor;
                this.EndTransitionTime =
                    colorChangeConfigurationBehavior.EndTransitionTime.TotalMilliseconds;
            }
            else
            {
                throw new InvalidOperationException(nameof(behavior) + " was an unexpected type.");
            }
        }

        /// <inheritdoc/>
        public override ConfigurationBehavior CreateBehavior()
        {
            return new ColorChangeConfigurationBehavior
            {
                StartColor = this.StartColor,
                EndColor = this.EndColor,
                TransitionTime =
                    new TimeSpan((long)(this.TransitionTime * TimeSpan.TicksPerMillisecond)),
                EndTransitionEnabled = this.EndTransitionEnabled,
                EndTransitionColor = this.EndTransitionColor,
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

        private static bool ChooseColor(
            IWin32Window owner,
            Color existingColor,
            out Color newColor)
        {
            var result = false;
            newColor = existingColor;
            using (var colorDialog = new ColorDialog())
            {
                colorDialog.AnyColor = true;
                colorDialog.FullOpen = true;
                colorDialog.Color = existingColor;
                if (colorDialog.ShowDialog(owner) == DialogResult.OK)
                {
                    newColor = colorDialog.Color;
                    result = true;
                }
            }

            return result;
        }
    }
}