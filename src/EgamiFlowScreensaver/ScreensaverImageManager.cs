// <copyright file="ScreensaverImageManager.cs" company="natsnudasoft">
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
    /// Provides a class to manage the state of a collection of screensaver images.
    /// </summary>
    public sealed class ScreensaverImageManager
    {
        private readonly ScreensaverArea screensaverArea;
        private readonly List<ScreensaverImageItem> screensaverImageItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverImageManager"/> class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/> is
        /// <see langword="null"/>.</exception>
        public ScreensaverImageManager(ScreensaverArea screensaverArea)
        {
            ParameterValidation.IsNotNull(screensaverArea, nameof(screensaverArea));

            this.screensaverArea = screensaverArea;
            this.screensaverImageItems = new List<ScreensaverImageItem>();
        }

        /// <summary>
        /// Updates the state of this <see cref="ScreensaverImageManager"/>.
        /// </summary>
        public void Update()
        {
            var screensaverBounds = this.screensaverArea.ScreensaverGameBounds;
            foreach (var screensaverImageItem in this.screensaverImageItems)
            {
                screensaverImageItem.Position += screensaverImageItem.Speed;
                var positionX = screensaverImageItem.Position.X;
                var positionY = screensaverImageItem.Position.Y;
                var speedX = screensaverImageItem.Speed.X;
                var speedY = screensaverImageItem.Speed.Y;
                var width = screensaverImageItem.Texture.Width;
                var height = screensaverImageItem.Texture.Height;
                if ((speedX > 0 && positionX + width > screensaverBounds.Right) ||
                    (speedX < 0 && positionX < screensaverBounds.Left))
                {
                    screensaverImageItem.Speed = new Vector2(-speedX, speedY);
                    var newX =
                        speedX > 0 ? screensaverBounds.Right - width : screensaverBounds.Left;
                    screensaverImageItem.Position = new Vector2(newX, positionY);
                }

                if ((speedY > 0 && positionY + height > screensaverBounds.Bottom) ||
                    (speedY < 0 && positionY < screensaverBounds.Top))
                {
                    screensaverImageItem.Speed = new Vector2(speedX, -speedY);
                    var newY =
                        speedY > 0 ? screensaverBounds.Bottom - height : screensaverBounds.Top;
                    screensaverImageItem.Position = new Vector2(positionX, newY);
                }
            }
        }

        /// <summary>
        /// Draws the items of this <see cref="ScreensaverImageManager"/> to the specified
        /// <see cref="SpriteBatch"/>.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var screensaverImageItem in this.screensaverImageItems)
            {
                spriteBatch.Draw(
                    screensaverImageItem.Texture,
                    screensaverImageItem.Position,
                    Color.White);
            }
        }

        /// <summary>
        /// Adds the specified screensaver image to the collection of images managed by this
        /// <see cref="ScreensaverImageManager"/>.
        /// </summary>
        /// <param name="screensaverImageItem">The screensaver image item to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverImageItem"/> is
        /// <see langword="null"/>.</exception>
        public void AddScreensaverImage(ScreensaverImageItem screensaverImageItem)
        {
            ParameterValidation.IsNotNull(screensaverImageItem, nameof(screensaverImageItem));

            this.screensaverImageItems.Add(screensaverImageItem);
        }
    }
}