// <copyright file="CenterImageEmitDetails.cs" company="natsnudasoft">
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
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.EgamiFlowScreensaver.Config;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class capable of creating locations at the centre of a screen for a
    /// <see cref="ScreensaverImageEmitter" />.
    /// </summary>
    public sealed class CenterImageEmitDetails : ImageEmitDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CenterImageEmitDetails"/> class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="screensaverConfiguration">The <see cref="ScreensaverConfiguration"/>
        /// representing the configured state of the screensaver.</param>
        /// <param name="behaviorFactories">A collection of factories that define how to create
        /// behaviours that will be attached to any images emitted by a
        /// <see cref="ScreensaverImageEmitter"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/>,
        /// <paramref name="screensaverConfiguration"/>, or <paramref name="behaviorFactories"/>
        /// is <see langword="null"/>.</exception>
        public CenterImageEmitDetails(
            ScreensaverArea screensaverArea,
            ScreensaverConfiguration screensaverConfiguration,
            IEnumerable<Func<IScreensaverImageItemBehavior>> behaviorFactories)
            : base(screensaverArea, screensaverConfiguration, behaviorFactories)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CenterImageEmitDetails"/> class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="screensaverConfiguration">The <see cref="ScreensaverConfiguration"/>
        /// representing the configured state of the screensaver.</param>
        /// <param name="behaviorFactories">A collection of factories that define how to create
        /// behaviours that will be attached to any images emitted by a
        /// <see cref="ScreensaverImageEmitter"/>.</param>
        /// <param name="random">A pseudo-random number generator that can be used to generate
        /// randomness in the <see cref="CenterImageEmitDetails"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/>,
        /// <paramref name="screensaverConfiguration"/>, <paramref name="behaviorFactories"/>, or
        /// <paramref name="random"/> is <see langword="null"/>.</exception>
        public CenterImageEmitDetails(
            ScreensaverArea screensaverArea,
            ScreensaverConfiguration screensaverConfiguration,
            IEnumerable<Func<IScreensaverImageItemBehavior>> behaviorFactories,
            Random random)
            : base(screensaverArea, screensaverConfiguration, behaviorFactories, random)
        {
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="texture"/> is
        /// <see langword="null"/>.</exception>
        public override ScreensaverImageItem CreateScreensaverImageItem(Texture2D texture)
        {
            ParameterValidation.IsNotNull(texture, nameof(texture));

            var origin = new Vector2(texture.Width, texture.Height) / 2f;
            var gameCenter = this.ScreensaverArea.PrimaryGameBounds.Center.ToVector2();
            var minX = gameCenter.X - PositionDistribution;
            var maxX = gameCenter.X + PositionDistribution;
            var minY = gameCenter.Y - PositionDistribution;
            var maxY = gameCenter.Y + PositionDistribution;
            var position = new Vector2(
                this.Random.NextFloat(minX, maxX),
                this.Random.NextFloat(minY, maxY));
            return new ScreensaverImageItem(
                texture,
                this.BehaviorFactories.Select(f => f?.Invoke()))
            {
                Position = position,
                Origin = origin
            };
        }
    }
}