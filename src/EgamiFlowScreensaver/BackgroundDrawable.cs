// <copyright file="BackgroundDrawable.cs" company="natsnudasoft">
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
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides an abstract base for an item that will be drawn as the background to a
    /// <see cref="ScreensaverGame"/>.
    /// </summary>
    public abstract class BackgroundDrawable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundDrawable"/> class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/> is
        /// <see langword="null"/>.</exception>
        protected BackgroundDrawable(ScreensaverArea screensaverArea)
        {
            ParameterValidation.IsNotNull(screensaverArea, nameof(screensaverArea));

            this.ScreensaverArea = screensaverArea;
        }

        /// <summary>
        /// Gets the description of the area of the screensaver.
        /// </summary>
        public ScreensaverArea ScreensaverArea { get; }

        /// <summary>
        /// Loads the content of this <see cref="BackgroundDrawable"/>.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device used by the game.</param>
        public virtual void LoadContent(GraphicsDevice graphicsDevice)
        {
        }

        /// <summary>
        /// Perform any operations required before the <see cref="ScreensaverGame"/> starts drawing.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device used by the game.</param>
        public virtual void BeforeDraw(GraphicsDevice graphicsDevice)
        {
        }

        /// <summary>
        /// Draws the content of this <see cref="BackgroundDrawable"/>.
        /// </summary>
        /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for any drawing.</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}