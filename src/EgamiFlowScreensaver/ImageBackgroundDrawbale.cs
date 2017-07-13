// <copyright file="ImageBackgroundDrawbale.cs" company="natsnudasoft">
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
    /// Provides a class which will draw a specified image as a <see cref="ScreensaverGame"/>
    /// background.
    /// </summary>
    /// <seealso cref="BackgroundDrawable" />
    /// <seealso cref="IDisposable" />
    public sealed class ImageBackgroundDrawbale : BackgroundDrawable, IDisposable
    {
        private readonly string backgroundImageFilePath;
        private readonly ITextureConverterService textureConverterService;
        private Texture2D imageTexture;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBackgroundDrawbale"/> class.
        /// </summary>
        /// <param name="backgroundImageFilePath">The path to image file to use as the background.
        /// </param>
        /// <param name="textureConverterService">The texture converter service.</param>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <exception cref="ArgumentNullException"><paramref name="backgroundImageFilePath"/>,
        /// <paramref name="textureConverterService"/>, or <paramref name="screensaverArea"/> is
        /// <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="backgroundImageFilePath"/> is
        /// empty.</exception>
        public ImageBackgroundDrawbale(
            string backgroundImageFilePath,
            ITextureConverterService textureConverterService,
            ScreensaverArea screensaverArea)
            : base(screensaverArea)
        {
            ParameterValidation.IsNotNull(backgroundImageFilePath, nameof(backgroundImageFilePath));
            ParameterValidation.IsNotEmpty(
                backgroundImageFilePath,
                nameof(backgroundImageFilePath));
            ParameterValidation.IsNotNull(textureConverterService, nameof(textureConverterService));

            this.backgroundImageFilePath = backgroundImageFilePath;
            this.textureConverterService = textureConverterService;
        }

        /// <inheritdoc/>
        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            using (var bitmap = new System.Drawing.Bitmap(this.backgroundImageFilePath))
            {
                this.imageTexture = this.textureConverterService.FromBitmap(bitmap);
            }
        }

        /// <inheritdoc/>
        public override void Draw(SpriteBatch spriteBatch)
        {
            var screensaverGameBounds = this.ScreensaverArea.ScreensaverGameBounds;
            spriteBatch.Draw(this.imageTexture, screensaverGameBounds, Color.White);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.imageTexture?.Dispose();
            }
        }
    }
}
