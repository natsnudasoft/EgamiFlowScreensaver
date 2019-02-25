// <copyright file="TransitionScreensaverImageItemBehavior.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides an abstract base class for behaviours that can be composed and applied to a
    /// <see cref="ScreensaverImageItem"/> and contain time based transitions.
    /// </summary>
    /// <seealso cref="ScreensaverImageItemBehavior"/>
    public abstract class TransitionScreensaverImageItemBehavior : ScreensaverImageItemBehavior
    {
        private static readonly Action<ScreensaverImageItem, float> EmptyTransitionUpdateAction =
            (s, p) => { };

        private readonly Action<ScreensaverImageItem, float> transitionUpdateAction;
        private readonly Action<ScreensaverImageItem, float> endTransitionUpdateAction;
        private readonly double inverseTransitionTime;
        private readonly double inverseEndTransitionTime;
        private TimeSpan currentTime;
        private bool isStartTransitionFinished;
        private bool hasEndTransitionStarted;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransitionScreensaverImageItemBehavior"/>
        /// class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="transitionTime">The time that this transition behaviour will take to
        /// transition from start to finish.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/> is
        /// <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="transitionTime"/> is less
        /// than a zero time.</exception>
        protected TransitionScreensaverImageItemBehavior(
            ScreensaverArea screensaverArea,
            TimeSpan transitionTime)
            : this(screensaverArea, transitionTime, EmptyTransitionUpdateAction)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransitionScreensaverImageItemBehavior"/>
        /// class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="transitionTime">The time that this transition behaviour will take to
        /// transition from start to finish.</param>
        /// <param name="endTransitionTime">The time the image item this behaviour is applied to
        /// will take to transition when it is being destroyed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/> is
        /// <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="transitionTime"/>, or
        /// <paramref name="endTransitionTime"/> is less than a zero time.</exception>
        protected TransitionScreensaverImageItemBehavior(
            ScreensaverArea screensaverArea,
            TimeSpan transitionTime,
            TimeSpan endTransitionTime)
            : this(
                screensaverArea,
                transitionTime,
                EmptyTransitionUpdateAction,
                endTransitionTime,
                EmptyTransitionUpdateAction)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransitionScreensaverImageItemBehavior"/>
        /// class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="transitionTime">The time that this transition behaviour will take to
        /// transition from start to finish.</param>
        /// <param name="transitionUpdateAction">An action to perform on the
        /// <see cref="ScreensaverImageItem"/> this behaviour is being applied to each time the
        /// transition position is updated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/>, or
        /// <paramref name="transitionUpdateAction"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="transitionTime"/> is less
        /// than a zero time.</exception>
        protected TransitionScreensaverImageItemBehavior(
            ScreensaverArea screensaverArea,
            TimeSpan transitionTime,
            Action<ScreensaverImageItem, float> transitionUpdateAction)
            : base(screensaverArea)
        {
            ParameterValidation
                .IsGreaterThanOrEqualTo(transitionTime, TimeSpan.Zero, nameof(transitionTime));
            ParameterValidation.IsNotNull(transitionUpdateAction, nameof(transitionUpdateAction));

            this.inverseTransitionTime = 1d / transitionTime.Ticks;
            this.transitionUpdateAction = transitionUpdateAction;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransitionScreensaverImageItemBehavior"/>
        /// class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="transitionTime">The time that this transition behaviour will take to
        /// transition from start to finish.</param>
        /// <param name="transitionUpdateAction">An action to perform on the
        /// <see cref="ScreensaverImageItem"/> this behaviour is being applied to each time the
        /// transition position is updated.</param>
        /// <param name="endTransitionTime">The time the image item this behaviour is applied to
        /// will take to transition when it is being destroyed.</param>
        /// <param name="endTransitionUpdateAction">An action to perform on the
        /// <see cref="ScreensaverImageItem"/> this behaviour is being applied to each time the
        /// transition position is updated when the image item is being destroyed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/>, or
        /// <paramref name="transitionUpdateAction"/>, or
        /// <paramref name="endTransitionUpdateAction"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="transitionTime"/>, or
        /// <paramref name="endTransitionTime"/> is less than a zero time.</exception>
        protected TransitionScreensaverImageItemBehavior(
            ScreensaverArea screensaverArea,
            TimeSpan transitionTime,
            Action<ScreensaverImageItem, float> transitionUpdateAction,
            TimeSpan endTransitionTime,
            Action<ScreensaverImageItem, float> endTransitionUpdateAction)
            : base(screensaverArea)
        {
            ParameterValidation
                .IsGreaterThanOrEqualTo(transitionTime, TimeSpan.Zero, nameof(transitionTime));
            ParameterValidation.IsNotNull(transitionUpdateAction, nameof(transitionUpdateAction));
            ParameterValidation.IsGreaterThanOrEqualTo(
                endTransitionTime,
                TimeSpan.Zero,
                nameof(endTransitionTime));
            ParameterValidation
                .IsNotNull(endTransitionUpdateAction, nameof(endTransitionUpdateAction));

            this.inverseTransitionTime = 1d / transitionTime.Ticks;
            this.transitionUpdateAction = transitionUpdateAction;
            this.inverseEndTransitionTime = 1d / endTransitionTime.Ticks;
            this.endTransitionUpdateAction = endTransitionUpdateAction;
        }

        /// <inheritdoc/>
        public override bool BlocksDestroy
        {
            get => this.endTransitionUpdateAction != null;
        }

        /// <summary>
        /// Gets the current value of the position of the transition time (between 0.0 and 1.0
        /// inclusive).
        /// </summary>
        protected float TransitionPosition { get; private set; }

        /// <summary>
        /// Gets the current value of the position of the end transition time (between 0.0 and 1.0
        /// inclusive).
        /// </summary>
        protected float EndTransitionPosition { get; private set; }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverImageItem"/> is
        /// <see langword="null"/>.</exception>
        public override void Initialize(ScreensaverImageItem screensaverImageItem)
        {
            ParameterValidation.IsNotNull(screensaverImageItem, nameof(screensaverImageItem));

            this.transitionUpdateAction(screensaverImageItem, this.TransitionPosition);
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverImageItem"/>, or
        /// <paramref name="gameTime"/> is <see langword="null"/>.</exception>
        public override void Update(ScreensaverImageItem screensaverImageItem, GameTime gameTime)
        {
            ParameterValidation.IsNotNull(screensaverImageItem, nameof(screensaverImageItem));
            ParameterValidation.IsNotNull(gameTime, nameof(gameTime));

            this.currentTime += gameTime.ElapsedGameTime;
            if (!screensaverImageItem.IsDestroying)
            {
                if (!this.isStartTransitionFinished)
                {
                    this.UpdateStartTransition(screensaverImageItem);
                }
            }
            else if (!this.BlocksDestroy)
            {
                this.IsFinished = true;
            }
            else
            {
                this.UpdateEndTransition(screensaverImageItem);
            }
        }

        private void UpdateStartTransition(ScreensaverImageItem screensaverImageItem)
        {
            this.TransitionPosition = (float)(this.currentTime.Ticks * this.inverseTransitionTime);
            if (this.TransitionPosition >= 1f)
            {
                if (!this.BlocksDestroy)
                {
                    this.IsFinished = true;
                }

                this.isStartTransitionFinished = true;
                this.TransitionPosition = 1f;
            }

            this.transitionUpdateAction(screensaverImageItem, this.TransitionPosition);
        }

        private void UpdateEndTransition(ScreensaverImageItem screensaverImageItem)
        {
            if (!this.hasEndTransitionStarted)
            {
                this.currentTime = TimeSpan.Zero;
                this.hasEndTransitionStarted = true;
            }

            this.EndTransitionPosition =
                (float)(this.currentTime.Ticks * this.inverseEndTransitionTime);
            if (this.EndTransitionPosition >= 1f)
            {
                this.IsFinished = true;
                this.EndTransitionPosition = 1f;
            }

            this.endTransitionUpdateAction(screensaverImageItem, this.EndTransitionPosition);
        }
    }
}