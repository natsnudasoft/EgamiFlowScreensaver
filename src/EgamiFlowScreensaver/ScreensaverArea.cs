// <copyright file="ScreensaverArea.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework;
    using SystemRectangle = System.Drawing.Rectangle;

    /// <summary>
    /// Provides a class to describe the area used by a <see cref="ScreensaverGame"/>.
    /// </summary>
    public sealed class ScreensaverArea
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverArea"/> class.
        /// </summary>
        /// <param name="screensaverBounds">The bounds of the screensaver in system terms.</param>
        /// <param name="primaryScreenBounds">The bounds of the primary screen in system terms.
        /// </param>
        public ScreensaverArea(Rectangle screensaverBounds, Rectangle primaryScreenBounds)
        {
            this.ScreensaverBounds = screensaverBounds;
            this.ScreensaverGameBounds = new Rectangle(
                Point.Zero,
                this.ScreensaverBounds.Size);
            this.PrimaryScreenBounds = primaryScreenBounds;
            this.PrimaryGameBounds = new Rectangle(
                this.PrimaryScreenBounds.Location - this.ScreensaverBounds.Location,
                this.PrimaryScreenBounds.Size);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverArea"/> class.
        /// </summary>
        /// <param name="screensaverBounds">The bounds of the screensaver in system terms.</param>
        /// <param name="primaryScreenBounds">The bounds of the primary screen in system terms.
        /// </param>
        public ScreensaverArea(
            SystemRectangle screensaverBounds,
            SystemRectangle primaryScreenBounds)
            : this(screensaverBounds.ToGameRectangle(), primaryScreenBounds.ToGameRectangle())
        {
        }

        /// <summary>
        /// Gets the bounds of the screensaver in system terms.
        /// </summary>
        public Rectangle ScreensaverBounds { get; }

        /// <summary>
        /// Gets the bounds of the screensaver in game terms.
        /// </summary>
        public Rectangle ScreensaverGameBounds { get; }

        /// <summary>
        /// Gets the bounds of the primary screen in system terms.
        /// </summary>
        public Rectangle PrimaryScreenBounds { get; }

        /// <summary>
        /// Gets the bounds of the primary screen in game terms.
        /// </summary>
        public Rectangle PrimaryGameBounds { get; }
    }
}