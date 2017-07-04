// <copyright file="SolidColorBackgroundDrawable.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework.Graphics;
    using SystemColor = System.Drawing.Color;

    /// <summary>
    /// Provides a class which will draw a solid colour as a <see cref="ScreensaverGame"/>
    /// background.
    /// </summary>
    /// <seealso cref="BackgroundDrawable" />
    public class SolidColorBackgroundDrawable : BackgroundDrawable
    {
        private readonly Color backgroundColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolidColorBackgroundDrawable"/> class.
        /// </summary>
        /// <param name="backgroundColor">The colour to use for the background.</param>
        /// <param name="screensaverArea">The screensaver area.</param>
        public SolidColorBackgroundDrawable(
            SystemColor backgroundColor,
            ScreensaverArea screensaverArea)
            : base(screensaverArea)
        {
            this.backgroundColor = new Color(
                backgroundColor.R,
                backgroundColor.G,
                backgroundColor.B,
                byte.MaxValue);
        }

        /// <inheritdoc/>
        public override void BeforeDraw(GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(this.backgroundColor);
        }
    }
}
