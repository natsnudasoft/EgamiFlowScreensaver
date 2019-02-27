// <copyright file="ScreensaverImageEmitter.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class to manage the emitting of images in a <see cref="ScreensaverGame"/>.
    /// </summary>
    public sealed class ScreensaverImageEmitter
    {
        private const float MinSpeed = 0.5f;
        private const float MaxSpeed = 8f;
        private const int PositionDistribution = 5;
        private const int TwoPositionDistribution = PositionDistribution * 2;

        private readonly ScreensaverImageEmitterCounter counter;
        private readonly ScreensaverImageManager screensaverImageManager;
        private readonly IReadOnlyList<Texture2D> screensaverTextures;
        private readonly IImageEmitDetails imageEmitDetails;
        private readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverImageEmitter"/> class.
        /// </summary>
        /// <param name="counter">The counter to use to control when new images are emitted.</param>
        /// <param name="screensaverImageManager">The <see cref="ScreensaverImageManager"/> of the
        /// current screensaver.</param>
        /// <param name="screensaverTextures">A collection of available screensaver textures to
        /// randomly choose from when emitting an image.</param>
        /// <param name="imageEmitDetails">The details describing where and how many images will be
        /// emitted.</param>
        /// <exception cref="ArgumentNullException"><paramref name="counter"/>,
        /// <paramref name="screensaverImageManager"/>, <paramref name="screensaverTextures"/>, or
        /// <paramref name="imageEmitDetails"/> is <see langword="null"/>.</exception>
        public ScreensaverImageEmitter(
            ScreensaverImageEmitterCounter counter,
            ScreensaverImageManager screensaverImageManager,
            IReadOnlyList<Texture2D> screensaverTextures,
            IImageEmitDetails imageEmitDetails)
            : this(
                  counter,
                  screensaverImageManager,
                  screensaverTextures,
                  imageEmitDetails,
                  new Random())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverImageEmitter"/> class.
        /// </summary>
        /// <param name="counter">The counter to use to control when new images are emitted.</param>
        /// <param name="screensaverImageManager">The <see cref="ScreensaverImageManager"/> of the
        /// current screensaver.</param>
        /// <param name="screensaverTextures">A collection of available screensaver textures to
        /// randomly choose from when emitting an image.</param>
        /// <param name="imageEmitDetails">The details describing where and how many images will be
        /// emitted.</param>
        /// <param name="random">A pseudo-random number generator that can be used to generate
        /// randomness in the <see cref="ScreensaverImageEmitter"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="counter"/>,
        /// <paramref name="screensaverImageManager"/>, <paramref name="screensaverTextures"/>,
        /// <paramref name="imageEmitDetails"/>, or <paramref name="random"/> is
        /// <see langword="null"/>.</exception>
        public ScreensaverImageEmitter(
            ScreensaverImageEmitterCounter counter,
            ScreensaverImageManager screensaverImageManager,
            IReadOnlyList<Texture2D> screensaverTextures,
            IImageEmitDetails imageEmitDetails,
            Random random)
        {
            ParameterValidation.IsNotNull(counter, nameof(counter));
            ParameterValidation.IsNotNull(screensaverImageManager, nameof(screensaverImageManager));
            ParameterValidation.IsNotNull(screensaverTextures, nameof(screensaverTextures));
            ParameterValidation.IsNotNull(imageEmitDetails, nameof(imageEmitDetails));
            ParameterValidation.IsNotNull(random, nameof(random));

            this.counter = counter;
            this.screensaverImageManager = screensaverImageManager;
            this.screensaverTextures = screensaverTextures;
            this.imageEmitDetails = imageEmitDetails;
            this.random = random;
        }

        /// <summary>
        /// Gets a value indicating whether this emitter is running.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if this emitter is running; otherwise, <see langword="false"/>.
        /// </value>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Starts this emitter, allowing it emit images again.
        /// </summary>
        public void Start()
        {
            this.IsRunning = true;
        }

        /// <summary>
        /// Stops this emitter from emitting any images.
        /// </summary>
        public void Stop()
        {
            this.IsRunning = false;
        }

        /// <summary>
        /// Updates the state of the emitter, emitting any new images if necessary.
        /// </summary>
        /// <param name="gameTime">A snapshot of the current game time.</param>
        public void Update(GameTime gameTime)
        {
            if (this.IsRunning)
            {
                var imageCount = this.screensaverImageManager.ImageCount;
                if (imageCount >= this.imageEmitDetails.MaxImageEmitCount)
                {
                    this.StopIfNotInfiniteImageEmitMode();
                }
                else if (this.screensaverTextures.Count > 0)
                {
                    var emitCount = this.counter.UpdateEmit(gameTime);
                    for (int i = 0; i < emitCount; ++i)
                    {
                        var textureIndex = this.random.Next(0, this.screensaverTextures.Count);
                        var texture = this.screensaverTextures[textureIndex];
                        var screensaverImageItem =
                            this.imageEmitDetails.CreateScreensaverImageItem(texture);
                        this.screensaverImageManager.AddScreensaverImage(screensaverImageItem);
                        imageCount = this.screensaverImageManager.ImageCount;
                        if (imageCount >= this.imageEmitDetails.MaxImageEmitCount)
                        {
                            this.StopIfNotInfiniteImageEmitMode();
                            break;
                        }
                    }
                }
            }
        }

        private void StopIfNotInfiniteImageEmitMode()
        {
            if (!this.imageEmitDetails.IsInfiniteImageEmitMode)
            {
                this.Stop();
            }
        }
    }
}