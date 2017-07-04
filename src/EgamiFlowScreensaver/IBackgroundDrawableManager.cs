// <copyright file="IBackgroundDrawableManager.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.EgamiFlowScreensaver.Config;

    /// <summary>
    /// Provides an interface describing methods able to manage a <see cref="BackgroundDrawable"/>
    /// based on a specified <see cref="ScreensaverConfiguration"/>.
    /// </summary>
    public interface IBackgroundDrawableManager
    {
        /// <summary>
        /// Initializes this <see cref="BackgroundDrawableManager" /> based on the specified
        /// <see cref="ScreensaverConfiguration"/>.
        /// </summary>
        /// <param name="screensaverConfiguration">The configuration options for the screensaver.
        /// </param>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        void Initialize(
            ScreensaverConfiguration screensaverConfiguration,
            ScreensaverArea screensaverArea);

        /// <summary>
        /// Loads the content of the <see cref="BackgroundDrawable"/> that is managed by this
        /// <see cref="BackgroundDrawableManager"/>.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device used by the game.</param>
        void LoadContent(GraphicsDevice graphicsDevice);

        /// <summary>
        /// Performs any operations on the <see cref="BackgroundDrawable"/> that is managed by this
        /// <see cref="BackgroundDrawableManager"/> that should occur before drawing.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device used by the game.</param>
        void BeforeDraw(GraphicsDevice graphicsDevice);

        /// <summary>
        /// Draws the <see cref="BackgroundDrawable"/> that is managed by this
        /// <see cref="BackgroundDrawableManager"/>.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use for drawing.</param>
        void Draw(SpriteBatch spriteBatch);
    }
}