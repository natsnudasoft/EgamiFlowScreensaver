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

    /// <summary>
    /// Provides a class for performing scaling of images.
    /// </summary>
    /// <seealso cref="IImageScaleService" />
    public sealed class ImageScaleService : IImageScaleService
    {
        /// <inheritdoc/>
        public Bitmap ScaleImage(Image image, Size scaleSize, ImageScaleMode imageScaleMode)
        {
            switch (imageScaleMode)
            {
                case ImageScaleMode.Fill:
                    return FillImage(image, scaleSize);
                case ImageScaleMode.Fit:
                    return FitImage(image, scaleSize);
                case ImageScaleMode.Stretch:
                    return StretchImage(image, scaleSize);
                case ImageScaleMode.Tile:
                    return TileImage(image, scaleSize);
                default:
                    return new Bitmap(image);
            }
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
                new Bitmap(scaleSize.Width, scaleSize.Height, PixelFormat.Format32bppPArgb);
            tiledBitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var brush = new TextureBrush(image, WrapMode.Tile))
            using (var graphics = Graphics.FromImage(tiledBitmap))
            {
                SetupDefaultGraphicsOptions(graphics);
                graphics.FillRectangle(brush, 0, 0, scaleSize.Width, scaleSize.Height);
            }

            return tiledBitmap;
        }

        private static Bitmap ResizeImage(Image image, Size scaleSize)
        {
            var destRect = new Rectangle(0, 0, scaleSize.Width, scaleSize.Height);
            var resizedImage =
                new Bitmap(scaleSize.Width, scaleSize.Height, PixelFormat.Format32bppPArgb);
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
