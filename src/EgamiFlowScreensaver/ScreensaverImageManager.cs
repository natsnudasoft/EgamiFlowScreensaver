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
        /// <param name="gameTime">A snapshot of the current game time.</param>
        public void Update(GameTime gameTime)
        {
            foreach (var screensaverImageItem in this.screensaverImageItems)
            {
                screensaverImageItem.Update(gameTime);
            }
        }

        /// <summary>
        /// Draws the items of this <see cref="ScreensaverImageManager"/> to the specified
        /// <see cref="SpriteBatch"/>.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <exception cref="ArgumentNullException"><paramref name="spriteBatch"/> is
        /// <see langword="null"/>.</exception>
        public void Draw(SpriteBatch spriteBatch)
        {
            ParameterValidation.IsNotNull(spriteBatch, nameof(spriteBatch));

            foreach (var screensaverImageItem in this.screensaverImageItems)
            {
                screensaverImageItem.Draw(spriteBatch);
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

            screensaverImageItem.Initialize();
            this.screensaverImageItems.Add(screensaverImageItem);
        }
    }
}