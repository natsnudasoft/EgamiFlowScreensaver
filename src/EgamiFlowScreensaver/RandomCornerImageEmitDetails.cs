// <copyright file="RandomCornerImageEmitDetails.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.EgamiFlowScreensaver.Config;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class capable of creating locations in a random corner of the screen for a
    /// <see cref="ScreensaverImageEmitter" />.
    /// </summary>
    public sealed class RandomCornerImageEmitDetails : ImageEmitDetails
    {
        private readonly Func<Texture2D, ScreensaverImageItem>[] screensaverImageItemStrategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomCornerImageEmitDetails"/> class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="screensaverConfiguration">
        /// The <see cref="ScreensaverConfiguration"/> representing the configured state of the
        /// screensaver.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/>, or
        /// <paramref name="screensaverConfiguration"/> is <see langword="null"/>.</exception>
        public RandomCornerImageEmitDetails(
            ScreensaverArea screensaverArea,
            ScreensaverConfiguration screensaverConfiguration)
            : base(screensaverArea, screensaverConfiguration)
        {
            var bottomRightImageEmitDetails = new BottomRightImageEmitDetails(
                screensaverArea,
                screensaverConfiguration);
            var topRightImageEmitDetails = new TopRightImageEmitDetails(
                screensaverArea,
                screensaverConfiguration);
            var topLeftImageEmitDetails = new TopLeftImageEmitDetails(
                screensaverArea,
                screensaverConfiguration);
            var bottomLeftImageEmitDetails = new BottomLeftImageEmitDetails(
                screensaverArea,
                screensaverConfiguration);
            this.screensaverImageItemStrategies = new Func<Texture2D, ScreensaverImageItem>[]
            {
                bottomRightImageEmitDetails.CreateScreensaverImageItem,
                topRightImageEmitDetails.CreateScreensaverImageItem,
                topLeftImageEmitDetails.CreateScreensaverImageItem,
                bottomLeftImageEmitDetails.CreateScreensaverImageItem
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomCornerImageEmitDetails"/> class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="screensaverConfiguration">The <see cref="ScreensaverConfiguration"/>
        /// representing the configured state of the screensaver.</param>
        /// <param name="random">A pseudo-random number generator that can be used to generate
        /// randomness in the <see cref="RandomCornerImageEmitDetails"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/>,
        /// <paramref name="screensaverConfiguration"/>, or <paramref name="random"/> is
        /// <see langword="null"/>.</exception>
        public RandomCornerImageEmitDetails(
            ScreensaverArea screensaverArea,
            ScreensaverConfiguration screensaverConfiguration,
            Random random)
            : base(screensaverArea, screensaverConfiguration, random)
        {
            var bottomRightImageEmitDetails = new BottomRightImageEmitDetails(
                screensaverArea,
                screensaverConfiguration,
                random);
            var topRightImageEmitDetails = new TopRightImageEmitDetails(
                screensaverArea,
                screensaverConfiguration,
                random);
            var topLeftImageEmitDetails = new TopLeftImageEmitDetails(
                screensaverArea,
                screensaverConfiguration,
                random);
            var bottomLeftImageEmitDetails = new BottomLeftImageEmitDetails(
                screensaverArea,
                screensaverConfiguration,
                random);
            this.screensaverImageItemStrategies = new Func<Texture2D, ScreensaverImageItem>[]
            {
                bottomRightImageEmitDetails.CreateScreensaverImageItem,
                topRightImageEmitDetails.CreateScreensaverImageItem,
                topLeftImageEmitDetails.CreateScreensaverImageItem,
                bottomLeftImageEmitDetails.CreateScreensaverImageItem
            };
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="texture"/> is
        /// <see langword="null"/>.</exception>
        public override ScreensaverImageItem CreateScreensaverImageItem(Texture2D texture)
        {
            ParameterValidation.IsNotNull(texture, nameof(texture));

            var randomEmitDetailFunctionIndex =
                this.Random.Next(0, this.screensaverImageItemStrategies.Length);
            return this.screensaverImageItemStrategies[randomEmitDetailFunctionIndex](texture);
        }
    }
}