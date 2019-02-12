// <copyright file="ImageScaleService.cs" company="natsnudasoft">
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
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class for performing scaling of images.
    /// </summary>
    /// <seealso cref="IImageScaleService" />
    public sealed class ImageScaleService : IImageScaleService
    {
        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="image"/> is
        /// <see langword="null"/>.</exception>
        public Bitmap ScaleImage(Image image, Size scaleSize, ImageScaleMode imageScaleMode)
        {
            ParameterValidation.IsNotNull(image, nameof(image));

            Bitmap scaledImage;
            switch (imageScaleMode)
            {
                case ImageScaleMode.Fill:
                    scaledImage = FillImage(image, scaleSize);
                    break;
                case ImageScaleMode.Fit:
                    scaledImage = FitImage(image, scaleSize);
                    break;
                case ImageScaleMode.Stretch:
                    scaledImage = StretchImage(image, scaleSize);
                    break;
                case ImageScaleMode.Tile:
                    scaledImage = TileImage(image, scaleSize);
                    break;
                default:
                    scaledImage = new Bitmap(image);
                    break;
            }

            return scaledImage;
        }

        private static Bitmap FillImage(Image image, Size scaleSize)
        {
            var scale = Math.Max(
                scaleSize.Width / (float)image.Width,
                scaleSize.Height / (float)image.Height);
            var newSize = new Size((int)(image.Width * scale), (int)(image.Height * scale));
            return ResizeImage(image, newSize);
        }

        private static Bitmap FitImage(Image image, Size scaleSize)
        {
            var scale = Math.Min(
                scaleSize.Width / (float)image.Width,
                scaleSize.Height / (float)image.Height);
            var newSize = new Size((int)(image.Width * scale), (int)(image.Height * scale));
            return ResizeImage(image, newSize);
        }

        private static Bitmap StretchImage(Image image, Size scaleSize)
        {
            return ResizeImage(image, scaleSize);
        }

        private static Bitmap TileImage(Image image, Size scaleSize)
        {
            var tiledBitmap =
                new Bitmap(scaleSize.Width, scaleSize.Height, PixelFormat.Format32bppArgb);
            try
            {
                tiledBitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                using (var brush = new TextureBrush(image, WrapMode.Tile))
                using (var graphics = Graphics.FromImage(tiledBitmap))
                {
                    SetupDefaultGraphicsOptions(graphics);
                    graphics.FillRectangle(brush, 0, 0, scaleSize.Width, scaleSize.Height);
                }
            }
            catch
            {
                tiledBitmap.Dispose();
                throw;
            }

            return tiledBitmap;
        }

        private static Bitmap ResizeImage(Image image, Size scaleSize)
        {
            var destRect = new Rectangle(0, 0, scaleSize.Width, scaleSize.Height);
            var resizedImage = new Bitmap(
                scaleSize.Width, scaleSize.Height, PixelFormat.Format32bppArgb);
            try
            {
                resizedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                using (var graphics = Graphics.FromImage(resizedImage))
                {
                    SetupDefaultGraphicsOptions(graphics);
                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(
                            image,
                            destRect,
                            0,
                            0,
                            image.Width,
                            image.Height,
                            GraphicsUnit.Pixel,
                            wrapMode);
                    }
                }
            }
            catch
            {
                resizedImage.Dispose();
                throw;
            }

            return resizedImage;
        }

        private static void SetupDefaultGraphicsOptions(Graphics graphics)
        {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        }
    }
}