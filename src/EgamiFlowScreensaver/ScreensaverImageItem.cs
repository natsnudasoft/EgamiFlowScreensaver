// <copyright file="ScreensaverImageItem.cs" company="natsnudasoft">
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

    /// <summary>
    /// Provides a class that encapsulates the current state of an image in a
    /// <see cref="ScreensaverGame"/>.
    /// </summary>
    public sealed class ScreensaverImageItem
    {
        /// <summary>
        /// Gets or sets the current position of this screensaver image.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the speed that this screensaver image moves.
        /// </summary>
        public Vector2 Speed { get; set; }

        /// <summary>
        /// Gets or sets the texture of this screensaver image.
        /// </summary>
        public Texture2D Texture { get; set; }
    }
}