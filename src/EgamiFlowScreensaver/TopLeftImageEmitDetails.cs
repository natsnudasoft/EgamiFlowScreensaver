// <copyright file="TopLeftImageEmitDetails.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.EgamiFlowScreensaver.Config;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class capable of creating locations at the top left of a screen for a
    /// <see cref="ScreensaverImageEmitter" />.
    /// </summary>
    public sealed class TopLeftImageEmitDetails : ImageEmitDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopLeftImageEmitDetails"/> class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="screensaverConfiguration">The <see cref="ScreensaverConfiguration"/>
        /// representing the configured state of the screensaver.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/>, or
        /// <paramref name="screensaverConfiguration"/> is <see langword="null"/>.</exception>
        public TopLeftImageEmitDetails(
            ScreensaverArea screensaverArea,
            ScreensaverConfiguration screensaverConfiguration)
            : base(screensaverArea, screensaverConfiguration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopLeftImageEmitDetails"/> class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="screensaverConfiguration">The <see cref="ScreensaverConfiguration"/>
        /// representing the configured state of the screensaver.</param>
        /// <param name="random">A pseudo-random number generator that can be used to generate
        /// randomness in the <see cref="TopLeftImageEmitDetails"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/>,
        /// <paramref name="screensaverConfiguration"/>, or <paramref name="random"/> is
        /// <see langword="null"/>.</exception>
        public TopLeftImageEmitDetails(
            ScreensaverArea screensaverArea,
            ScreensaverConfiguration screensaverConfiguration,
            Random random)
            : base(screensaverArea, screensaverConfiguration, random)
        {
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="texture"/> is
        /// <see langword="null"/>.</exception>
        public override ScreensaverImageItem CreateScreensaverImageItem(Texture2D texture)
        {
            ParameterValidation.IsNotNull(texture, nameof(texture));

            var origin = new Vector2(texture.Width, texture.Height) / 2f;
            var topLeftPrimary = new Point(
                this.ScreensaverArea.PrimaryGameBounds.Left,
                this.ScreensaverArea.PrimaryGameBounds.Top);
            var maxX = topLeftPrimary.X - texture.Width + origin.X;
            var minX = maxX - TwoPositionDistribution;
            var maxY = topLeftPrimary.Y - texture.Height + origin.Y;
            var minY = maxY - TwoPositionDistribution;
            var position = new Vector2(
                this.Random.NextFloat(minX, maxX),
                this.Random.NextFloat(minY, maxY));
            var speed = new Vector2(
                this.Random.NextFloat(MinSpeed, MaxSpeed),
                this.Random.NextFloat(MinSpeed, MaxSpeed));
            return new ScreensaverImageItem(texture)
            {
                Position = position,
                Origin = origin,
                Speed = speed
            };
        }
    }
}