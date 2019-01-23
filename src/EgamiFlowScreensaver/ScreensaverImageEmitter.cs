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

        private readonly ScreensaverArea screensaverArea;
        private readonly ScreensaverImageEmitterCounter counter;
        private readonly ScreensaverImageManager screensaverImageManager;
        private readonly IReadOnlyList<Texture2D> screensaverTextures;
        private readonly int maxEmitCount;
        private readonly ImageEmitLocation imageEmitLocation;
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
        /// <param name="imageEmitLocation">The location that images will be emitted on the
        /// screensaver.</param>
        /// <exception cref="ArgumentNullException"><paramref name="counter"/>,
        /// <paramref name="screensaverArea"/>, <paramref name="screensaverImageManager"/>, or
        /// <paramref name="screensaverTextures"/> is <see langword="null"/>.</exception>
        public ScreensaverImageEmitter(
            ScreensaverImageEmitterCounter counter,
            ScreensaverArea screensaverArea,
            ScreensaverImageManager screensaverImageManager,
            IReadOnlyList<Texture2D> screensaverTextures,
            int maxEmitCount,
            ImageEmitLocation imageEmitLocation)
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
            this.imageEmitLocation = imageEmitLocation;
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
                    for (int i = 0; i < emitCount; ++i)
                    {
                        var textureIndex = this.random.Next(0, this.screensaverTextures.Count);
                        var texture = this.screensaverTextures[textureIndex];
                        var imageEmitDetails = this.GetImageEmitDetails(texture);
                        var screensaverImageItem = new ScreensaverImageItem
                        {
                            Position = imageEmitDetails.Position,
                            Speed = imageEmitDetails.Speed,
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

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly
        private (Vector2 Position, Vector2 Speed) GetImageEmitDetails(Texture2D texture)
#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
        {
            (Vector2, Vector2) imageEmitDetails;
            switch (this.imageEmitLocation)
            {
                case ImageEmitLocation.RandomCorner:
                    imageEmitDetails = this.GetRandomCornerEmitDetails(texture);
                    break;
                case ImageEmitLocation.Random:
                    imageEmitDetails = this.GetRandomEmitDetails();
                    break;
                case ImageEmitLocation.Center:
                    imageEmitDetails = this.GetCenterEmitDetails(texture);
                    break;
                case ImageEmitLocation.BottomRight:
                    imageEmitDetails = this.GetBottomRightEmitDetails();
                    break;
                case ImageEmitLocation.TopRight:
                    imageEmitDetails = this.GetTopRightEmitDetails(texture);
                    break;
                case ImageEmitLocation.TopLeft:
                    imageEmitDetails = this.GetTopLeftEmitDetails(texture);
                    break;
                case ImageEmitLocation.BottomLeft:
                default:
                    imageEmitDetails = this.GetBottomLeftEmitDetails(texture);
                    break;
            }

            return imageEmitDetails;
        }

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly
        private (Vector2 Position, Vector2 Speed) GetRandomCornerEmitDetails(Texture2D texture)
#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
        {
            var cornerProbability = this.random.Next(0, 4);
            switch (cornerProbability)
            {
                case 0:
                    return this.GetBottomRightEmitDetails();
                case 1:
                    return this.GetTopRightEmitDetails(texture);
                case 2:
                    return this.GetTopLeftEmitDetails(texture);
                case 3:
                default:
                    return this.GetBottomLeftEmitDetails(texture);
            }
        }

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly
        private (Vector2 Position, Vector2 Speed) GetRandomEmitDetails()
#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
        {
            var minX = this.screensaverArea.PrimaryGameBounds.Left;
            var maxX = this.screensaverArea.PrimaryGameBounds.Right;
            var minY = this.screensaverArea.PrimaryGameBounds.Top;
            var maxY = this.screensaverArea.PrimaryGameBounds.Bottom;
            var position = new Vector2(
                this.random.NextFloat(minX, maxX),
                this.random.NextFloat(minY, maxY));
            var speed = new Vector2(
                this.random.NextFloat(MinSpeed, MaxSpeed),
                this.random.NextFloat(MinSpeed, MaxSpeed));
            this.RandomlyNegateSpeed(ref speed);
            return (position, speed);
        }

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly
        private (Vector2 Position, Vector2 Speed) GetCenterEmitDetails(Texture2D texture)
#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
        {
            var originCenter = this.screensaverArea.PrimaryGameBounds.Center.ToVector2() -
                (new Vector2(texture.Width, texture.Height) / 2f);
            var minX = originCenter.X - PositionDistribution;
            var maxX = originCenter.X + PositionDistribution;
            var minY = originCenter.Y - PositionDistribution;
            var maxY = originCenter.Y + PositionDistribution;
            var position = new Vector2(
                this.random.NextFloat(minX, maxX),
                this.random.NextFloat(minY, maxY));
            var speed = new Vector2(
                this.random.NextFloat(MinSpeed, MaxSpeed),
                this.random.NextFloat(MinSpeed, MaxSpeed));
            this.RandomlyNegateSpeed(ref speed);
            return (position, speed);
        }

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly
        private (Vector2 Position, Vector2 Speed) GetBottomRightEmitDetails()
#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
        {
            var bottomRightPrimary = new Point(
                this.screensaverArea.PrimaryGameBounds.Right,
                this.screensaverArea.PrimaryGameBounds.Bottom);
            var minX = bottomRightPrimary.X;
            var maxX = bottomRightPrimary.X + TwoPositionDistribution;
            var minY = bottomRightPrimary.Y;
            var maxY = bottomRightPrimary.Y + TwoPositionDistribution;
            var position = new Vector2(
                this.random.NextFloat(minX, maxX),
                this.random.NextFloat(minY, maxY));
            var speed = new Vector2(
                -this.random.NextFloat(MinSpeed, MaxSpeed),
                -this.random.NextFloat(MinSpeed, MaxSpeed));
            return (position, speed);
        }

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly
        private (Vector2 Position, Vector2 Speed) GetTopRightEmitDetails(Texture2D texture)
#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
        {
            var topRightPrimary = new Point(
                this.screensaverArea.PrimaryGameBounds.Right,
                this.screensaverArea.PrimaryGameBounds.Top);
            var minX = topRightPrimary.X;
            var maxX = topRightPrimary.X + TwoPositionDistribution;
            var minY = topRightPrimary.Y - texture.Height - TwoPositionDistribution;
            var maxY = topRightPrimary.Y - texture.Height;
            var position = new Vector2(
                this.random.NextFloat(minX, maxX),
                this.random.NextFloat(minY, maxY));
            var speed = new Vector2(
                -this.random.NextFloat(MinSpeed, MaxSpeed),
                this.random.NextFloat(MinSpeed, MaxSpeed));
            return (position, speed);
        }

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly
        private (Vector2 Position, Vector2 Speed) GetTopLeftEmitDetails(Texture2D texture)
#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
        {
            var topLeftPrimary = new Point(
                this.screensaverArea.PrimaryGameBounds.Left,
                this.screensaverArea.PrimaryGameBounds.Top);
            var minX = topLeftPrimary.X - texture.Width - TwoPositionDistribution;
            var maxX = topLeftPrimary.X - texture.Width;
            var minY = topLeftPrimary.Y - texture.Height - TwoPositionDistribution;
            var maxY = topLeftPrimary.Y - texture.Height;
            var position = new Vector2(
                this.random.NextFloat(minX, maxX),
                this.random.NextFloat(minY, maxY));
            var speed = new Vector2(
                this.random.NextFloat(MinSpeed, MaxSpeed),
                this.random.NextFloat(MinSpeed, MaxSpeed));
            return (position, speed);
        }

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly
        private (Vector2 Position, Vector2 Speed) GetBottomLeftEmitDetails(Texture2D texture)
#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
        {
            var bottomLeftPrimary = new Point(
                this.screensaverArea.PrimaryGameBounds.Left,
                this.screensaverArea.PrimaryGameBounds.Bottom);
            var minX = bottomLeftPrimary.X - texture.Width - TwoPositionDistribution;
            var maxX = bottomLeftPrimary.X - texture.Width;
            var minY = bottomLeftPrimary.Y;
            var maxY = bottomLeftPrimary.Y + TwoPositionDistribution;
            var position = new Vector2(
                this.random.NextFloat(minX, maxX),
                this.random.NextFloat(minY, maxY));
            var speed = new Vector2(
                this.random.NextFloat(MinSpeed, MaxSpeed),
                -this.random.NextFloat(MinSpeed, MaxSpeed));
            return (position, speed);
        }

        private void RandomlyNegateSpeed(ref Vector2 speed)
        {
            if (this.random.Next(0, 2) == 0)
            {
                speed.X = -speed.X;
            }

            if (this.random.Next(0, 2) == 0)
            {
                speed.Y = -speed.Y;
            }
        }
    }
}