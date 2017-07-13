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
        private const int PositionDistribution = 20;

        private readonly ScreensaverArea screensaverArea;
        private readonly ScreensaverImageEmitterCounter counter;
        private readonly ScreensaverImageManager screensaverImageManager;
        private readonly IReadOnlyList<Texture2D> screensaverTextures;
        private readonly int maxEmitCount;
        private readonly Random random;
        private int currentEmitCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverImageEmitter"/> class.
        /// </summary>
        /// <param name="counter">The counter to use to control when new images are emitted.</param>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="screensaverImageManager">The <see cref="ScreensaverImageManager"/> of the
        /// current screensaver.</param>
        /// <param name="screensaverTextures">A collection of available screensaver textures to
        /// randomly choose from when emitting an image.</param>
        /// <param name="maxEmitCount">The maximum number of images that can be emitted. When this
        /// value is reached, this <see cref="ScreensaverImageEmitter"/> will stop.</param>
        /// <exception cref="ArgumentNullException"><paramref name="counter"/>,
        /// <paramref name="screensaverArea"/>, <paramref name="screensaverImageManager"/>, or
        /// <paramref name="screensaverTextures"/> is <see langword="null"/>.</exception>
        public ScreensaverImageEmitter(
            ScreensaverImageEmitterCounter counter,
            ScreensaverArea screensaverArea,
            ScreensaverImageManager screensaverImageManager,
            IReadOnlyList<Texture2D> screensaverTextures,
            int maxEmitCount)
        {
            ParameterValidation.IsNotNull(counter, nameof(counter));
            ParameterValidation.IsNotNull(screensaverArea, nameof(screensaverArea));
            ParameterValidation.IsNotNull(screensaverImageManager, nameof(screensaverImageManager));
            ParameterValidation.IsNotNull(screensaverTextures, nameof(screensaverTextures));

            this.counter = counter;
            this.screensaverArea = screensaverArea;
            this.screensaverImageManager = screensaverImageManager;
            this.screensaverTextures = screensaverTextures;
            this.random = new Random();
            this.maxEmitCount = maxEmitCount;
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
                if (this.currentEmitCount >= this.maxEmitCount)
                {
                    this.Stop();
                }
                else if (this.screensaverTextures.Count > 0)
                {
                    var emitCount = this.counter.UpdateEmit(gameTime);
                    var bottomLeftPrimary = new Point(
                        this.screensaverArea.PrimaryGameBounds.Left,
                        this.screensaverArea.PrimaryGameBounds.Bottom);
                    for (int i = 0; i < emitCount; ++i)
                    {
                        var textureIndex = this.random.Next(0, this.screensaverTextures.Count);
                        var texture = this.screensaverTextures[textureIndex];
                        var minLeft = bottomLeftPrimary.X - texture.Width - PositionDistribution;
                        var maxLeft = bottomLeftPrimary.X - texture.Width + PositionDistribution;
                        var minBottom = bottomLeftPrimary.Y - PositionDistribution;
                        var maxBottom = bottomLeftPrimary.Y + PositionDistribution;
                        var position = new Vector2(
                            this.random.NextFloat(minLeft, maxLeft),
                            this.random.NextFloat(minBottom, maxBottom));
                        var speed = new Vector2(
                            this.random.NextFloat(MinSpeed, MaxSpeed),
                            -this.random.NextFloat(MinSpeed, MaxSpeed));
                        var screensaverImageItem = new ScreensaverImageItem
                        {
                            Position = position,
                            Speed = speed,
                            Texture = texture
                        };
                        this.screensaverImageManager.AddScreensaverImage(screensaverImageItem);
                        if (++this.currentEmitCount >= this.maxEmitCount)
                        {
                            this.Stop();
                            break;
                        }
                    }
                }
            }
        }
    }
}
