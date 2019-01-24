// <copyright file="ImageBackgroundDrawable.cs" company="natsnudasoft">
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
    using SystemBitmap = System.Drawing.Bitmap;

    /// <summary>
    /// Provides a class which will draw a specified image as a <see cref="ScreensaverGame"/>
    /// background.
    /// </summary>
    /// <seealso cref="BackgroundDrawable" />
    /// <seealso cref="IDisposable" />
    public sealed class ImageBackgroundDrawable : BackgroundDrawable, IDisposable
    {
        private readonly string backgroundImageFilePath;
        private readonly ITextureConverterService textureConverterService;
        private readonly IImageScaleService imageScaleService;
        private readonly ImageScaleMode imageScaleMode;
        private TiledTexture2D imageTiledTexture;
        private Vector2 imagePosition;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBackgroundDrawable"/> class.
        /// </summary>
        /// <param name="backgroundImageFilePath">The path to image file to use as the background.
        /// </param>
        /// <param name="textureConverterService">The texture converter service.</param>
        /// <param name="imageScaleService">The image scale service.</param>
        /// <param name="imageScaleMode">How to scale and position the background image.</param>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <exception cref="ArgumentNullException"><paramref name="backgroundImageFilePath"/>,
        /// <paramref name="textureConverterService"/>, <paramref name="imageScaleService"/>, or
        /// <paramref name="screensaverArea"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="backgroundImageFilePath"/> is
        /// empty.</exception>
        public ImageBackgroundDrawable(
            string backgroundImageFilePath,
            ITextureConverterService textureConverterService,
            IImageScaleService imageScaleService,
            ImageScaleMode imageScaleMode,
            ScreensaverArea screensaverArea)
            : base(screensaverArea)
        {
            ParameterValidation.IsNotNull(backgroundImageFilePath, nameof(backgroundImageFilePath));
            ParameterValidation.IsNotEmpty(
                backgroundImageFilePath,
                nameof(backgroundImageFilePath));
            ParameterValidation.IsNotNull(textureConverterService, nameof(textureConverterService));
            ParameterValidation.IsNotNull(imageScaleService, nameof(imageScaleService));

            this.backgroundImageFilePath = backgroundImageFilePath;
            this.textureConverterService = textureConverterService;
            this.imageScaleService = imageScaleService;
            this.imageScaleMode = imageScaleMode;
        }

        /// <inheritdoc/>
        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            using (var bitmap = new SystemBitmap(this.backgroundImageFilePath))
            {
                var scaledImage = this.imageScaleService.ScaleImage(
                    bitmap,
                    this.ScreensaverArea.ScreensaverBounds.ToSystemRectangle().Size,
                    this.imageScaleMode);
                this.imageTiledTexture = this.textureConverterService.FromLargeBitmap(scaledImage);
            }

            switch (this.imageScaleMode)
            {
                case ImageScaleMode.Fill:
                case ImageScaleMode.Fit:
                case ImageScaleMode.Center:
                    this.CenterImagePosition();
                    break;
                default:
                    break;
            }
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="spriteBatch"/> is
        /// <see langword="null"/>.</exception>
        public override void Draw(SpriteBatch spriteBatch)
        {
            ParameterValidation.IsNotNull(spriteBatch, nameof(spriteBatch));

            foreach (var tiledTextureSegment in this.imageTiledTexture.TiledTextureSegments)
            {
                spriteBatch.Draw(
                    tiledTextureSegment.SegmentTexture,
                    this.imagePosition + tiledTextureSegment.SegmentArea.Location.ToVector2(),
                    Color.White);
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void CenterImagePosition()
        {
            var widthDifference =
                this.imageTiledTexture.Width - this.ScreensaverArea.ScreensaverBounds.Width;
            var heightDifference =
                this.imageTiledTexture.Height - this.ScreensaverArea.ScreensaverBounds.Height;
            this.imagePosition = new Vector2(
                this.imagePosition.X - (widthDifference / 2f),
                this.imagePosition.Y - (heightDifference / 2f));
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.imageTiledTexture?.Dispose();
            }
        }
    }
}