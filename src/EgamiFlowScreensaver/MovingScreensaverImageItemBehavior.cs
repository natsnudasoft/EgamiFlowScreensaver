// <copyright file="MovingScreensaverImageItemBehavior.cs" company="natsnudasoft">
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
    /// Provides a behaviour to apply to an image item that causes the image item to move around the
    /// screen at a specified speed.
    /// </summary>
    /// <seealso cref="ScreensaverImageItemBehavior"/>
    public class MovingScreensaverImageItemBehavior : ScreensaverImageItemBehavior
    {
        /// <summary>
        /// Represents the default minimum speed that an image should be emitted at by a <see
        /// cref="ScreensaverImageEmitter" />.
        /// </summary>
        public const float DefaultMinSpeed = 0.5f;

        /// <summary>
        /// Represents the default maximum speed that an image should be emitted at by a <see
        /// cref="ScreensaverImageEmitter" />.
        /// </summary>
        public const float DefaultMaxSpeed = 8f;

        private readonly Vector2 magnitude;
        private Vector2 direction;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovingScreensaverImageItemBehavior"/>
        /// class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="speed">The speed at which the image item this behaviour is applied to will
        /// move at.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/> is
        /// <see langword="null"/>.</exception>
        public MovingScreensaverImageItemBehavior(ScreensaverArea screensaverArea, Vector2 speed)
            : base(screensaverArea)
        {
            this.direction = new Vector2(Math.Sign(speed.X), Math.Sign(speed.Y));
            this.magnitude = new Vector2(Math.Abs(speed.X), Math.Abs(speed.Y));
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverImageItem"/> is
        /// <see langword="null"/>.</exception>
        public override void Initialize(ScreensaverImageItem screensaverImageItem)
        {
            ParameterValidation.IsNotNull(screensaverImageItem, nameof(screensaverImageItem));
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverImageItem"/> is
        /// <see langword="null"/>.</exception>
        public override void Update(ScreensaverImageItem screensaverImageItem, GameTime gameTime)
        {
            ParameterValidation.IsNotNull(screensaverImageItem, nameof(screensaverImageItem));

            var speed = this.magnitude * this.direction;
            screensaverImageItem.Position += speed;
            var topLeftPosition = screensaverImageItem.Position - screensaverImageItem.Origin;
            var width = screensaverImageItem.Texture.Width;
            var height = screensaverImageItem.Texture.Height;
            var screensaverBounds = this.ScreensaverArea.ScreensaverGameBounds;
            if ((speed.X > 0 && topLeftPosition.X + width > screensaverBounds.Right) ||
                (speed.X < 0 && topLeftPosition.X < screensaverBounds.Left))
            {
                this.direction = new Vector2(-this.direction.X, this.direction.Y);
                var newX = speed.X > 0 ? screensaverBounds.Right - width : screensaverBounds.Left;
                screensaverImageItem.Position = new Vector2(
                    newX + screensaverImageItem.Origin.X,
                    screensaverImageItem.Position.Y);
            }

            if ((speed.Y > 0 && topLeftPosition.Y + height > screensaverBounds.Bottom) ||
                (speed.Y < 0 && topLeftPosition.Y < screensaverBounds.Top))
            {
                this.direction = new Vector2(this.direction.X, -this.direction.Y);
                var newY = speed.Y > 0 ? screensaverBounds.Bottom - height : screensaverBounds.Top;
                screensaverImageItem.Position = new Vector2(
                    screensaverImageItem.Position.X,
                    newY + screensaverImageItem.Origin.Y);
            }
        }
    }
}