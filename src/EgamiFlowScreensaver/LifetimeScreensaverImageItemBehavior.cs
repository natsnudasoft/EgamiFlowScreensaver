// <copyright file="LifetimeScreensaverImageItemBehavior.cs" company="natsnudasoft">
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
    /// Provides a behaviour to apply to an image item that causes the image item to be destroyed
    /// after a specified lifetime.
    /// </summary>
    public sealed class LifetimeScreensaverImageItemBehavior : ScreensaverImageItemBehavior
    {
        private readonly TimeSpan lifetime;
        private TimeSpan currentTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="LifetimeScreensaverImageItemBehavior"/>
        /// class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="lifetime">The time the image item this behaviour is applied to will live
        /// for.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/> is
        /// <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="lifetime"/> is less than a
        /// zero time.</exception>
        public LifetimeScreensaverImageItemBehavior(
            ScreensaverArea screensaverArea,
            TimeSpan lifetime)
            : base(screensaverArea)
        {
            ParameterValidation.IsGreaterThanOrEqualTo(lifetime, TimeSpan.Zero, nameof(lifetime));

            this.lifetime = lifetime;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverImageItem"/> is
        /// <see langword="null"/>.</exception>
        public override void Initialize(ScreensaverImageItem screensaverImageItem)
        {
            ParameterValidation.IsNotNull(screensaverImageItem, nameof(screensaverImageItem));
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverImageItem"/>, or
        /// <paramref name="gameTime"/> is <see langword="null"/>.</exception>
        public override void Update(ScreensaverImageItem screensaverImageItem, GameTime gameTime)
        {
            ParameterValidation.IsNotNull(screensaverImageItem, nameof(screensaverImageItem));
            ParameterValidation.IsNotNull(gameTime, nameof(gameTime));

            this.currentTime += gameTime.ElapsedGameTime;
            if (this.currentTime >= this.lifetime)
            {
                screensaverImageItem.BeginDestroy();
                this.IsFinished = true;
            }
        }
    }
}