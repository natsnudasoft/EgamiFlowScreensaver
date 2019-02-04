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
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class that encapsulates the current state of an image in a
    /// <see cref="ScreensaverGame"/>.
    /// </summary>
    public sealed class ScreensaverImageItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverImageItem"/> class.
        /// </summary>
        /// <param name="texture">The texture that represents the image of this
        /// <see cref="ScreensaverImageItem"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="texture"/>
        /// is <see langword="null"/>.</exception>
        public ScreensaverImageItem(Texture2D texture)
        {
            ParameterValidation.IsNotNull(texture, nameof(texture));

            this.Texture = texture;
            this.Scale = Vector2.One;
            this.Color = Color.White;
            this.Alpha = 1f;
        }

        /// <summary>
        /// Gets or sets the current position of this screensaver image.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the speed that this screensaver image moves.
        /// </summary>
        public Vector2 Speed { get; set; }

        /// <summary>
        /// Gets the texture of this screensaver image.
        /// </summary>
        public Texture2D Texture { get; }

        /// <summary>
        /// Gets or sets the origin to use when drawing this screensaver image.
        /// </summary>
        public Vector2 Origin { get; set; }

        /// <summary>
        /// Gets or sets the colour this screensaver image will be drawn as.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets the alpha value (opacity) this screensaver image will be drawn at.
        /// </summary>
        public float Alpha { get; set; }

        /// <summary>
        /// Gets or sets the rotation value of this screensaver image (in radians).
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// Gets or sets the effects to use for mirroring of this screensaver image.
        /// </summary>
        public SpriteEffects SpriteEffects { get; set; }

        /// <summary>
        /// Gets or sets the current scale this screensaver image will be drawn at.
        /// </summary>
        public Vector2 Scale { get; set; }

        /// <summary>
        /// Draws this <see cref="ScreensaverImageItem"/> to the specified
        /// <see cref="SpriteBatch"/>.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="spriteBatch"/> is
        /// <see langword="null"/>.</exception>
        public void Draw(SpriteBatch spriteBatch)
        {
            ParameterValidation.IsNotNull(spriteBatch, nameof(spriteBatch));

            spriteBatch.Draw(
                this.Texture,
                this.Position,
                null,
                this.Color * this.Alpha,
                this.Rotation,
                this.Origin,
                this.Scale,
                this.SpriteEffects,
                0f);
        }
    }
}