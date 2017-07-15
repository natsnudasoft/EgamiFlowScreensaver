// <copyright file="TextureConverterService.cs" company="natsnudasoft">
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
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.NatsnudaLibrary;
    using ImageLockMode = System.Drawing.Imaging.ImageLockMode;
    using PixelFormat = System.Drawing.Imaging.PixelFormat;
    using SystemBitmap = System.Drawing.Bitmap;
    using SystemPoint = System.Drawing.Point;
    using SystemRectangle = System.Drawing.Rectangle;

    /// <summary>
    /// Provides methods for converting to and from textures.
    /// </summary>
    /// <seealso cref="ITextureConverterService" />
    public class TextureConverterService : ITextureConverterService
    {
        private const int DefaultImageSize = 2048;
        private readonly IGraphicsDeviceService graphicsDeviceService;
        private readonly int maxWidth;
        private readonly int maxHeight;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextureConverterService"/> class.
        /// </summary>
        /// <param name="graphicsDeviceService">The graphics device service to use to help create
        /// instances of <see cref="Texture2D"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="graphicsDeviceService"/> is
        /// <see langword="null"/>.</exception>
        public TextureConverterService(IGraphicsDeviceService graphicsDeviceService)
            : this(graphicsDeviceService, DefaultImageSize, DefaultImageSize)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextureConverterService"/> class.
        /// </summary>
        /// <param name="graphicsDeviceService">The graphics device service to use to help create
        /// instances of <see cref="Texture2D"/>.</param>
        /// <param name="maxWidth">The maximum width that a single texture converted by this
        /// service can be. Images larger than this will be tiled to multiple textures.</param>
        /// <param name="maxHeight">The maximum height that a single texture converted by this
        /// service can be. Images larger than this will be tiled to multiple textures.</param>
        /// <exception cref="ArgumentNullException"><paramref name="graphicsDeviceService"/> is
        /// <see langword="null"/>.</exception>
        public TextureConverterService(
            IGraphicsDeviceService graphicsDeviceService,
            int maxWidth,
            int maxHeight)
        {
            ParameterValidation.IsNotNull(graphicsDeviceService, nameof(graphicsDeviceService));

            this.graphicsDeviceService = graphicsDeviceService;
            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;
        }

        /// <inheritdoc/>
        /// <exception cref="Exception">The operation failed for an unknown reason.</exception>
        /// <exception cref="InvalidOperationException">The specified bitmap is too large. Use
        /// <see cref="FromLargeBitmap"/> instead.
        /// </exception>
        public Texture2D FromBitmap(SystemBitmap bitmap)
        {
            if (bitmap.Width > this.maxWidth || bitmap.Height > this.maxHeight)
            {
                throw new InvalidOperationException("The specified bitmap is too large.");
            }

            return this.FromBitmapArea(bitmap, new SystemRectangle(SystemPoint.Empty, bitmap.Size));
        }

        /// <inheritdoc/>
        /// <exception cref="Exception">The operation failed for an unknown reason.</exception>
        public TiledTexture2D FromLargeBitmap(SystemBitmap bitmap)
        {
            var x = 0;
            var y = 0;
            var width = bitmap.Width;
            var height = bitmap.Height;
            var tiledTextureSegments = new List<TiledTexture2DSegment>();
            while (y < height)
            {
                while (x < width)
                {
                    var segmentWidth = Math.Min(this.maxWidth, width - x);
                    var segmentHeight = Math.Min(this.maxHeight, height - y);
                    var segmentArea = new SystemRectangle(x, y, segmentWidth, segmentHeight);
                    var segmentTexture = this.FromBitmapArea(bitmap, segmentArea);
#pragma warning disable CC0022 // Should dispose object
                    tiledTextureSegments.Add(new TiledTexture2DSegment(
                        segmentTexture,
                        segmentArea.ToGameRectangle()));
#pragma warning restore CC0022 // Should dispose object
                    x += this.maxWidth;
                }

                x = 0;
                y += this.maxWidth;
            }

            return new TiledTexture2D(tiledTextureSegments, width, height);
        }

        private Texture2D FromBitmapArea(SystemBitmap bitmap, SystemRectangle area)
        {
            var texture = new Texture2D(
                this.graphicsDeviceService.GraphicsDevice,
                area.Width,
                area.Height,
                false,
                SurfaceFormat.Bgra32);
            var data = bitmap.LockBits(
                area,
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppPArgb);
            var bytes = new byte[data.Height * data.Stride];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
            texture.SetData(bytes);
            bitmap.UnlockBits(data);
            return texture;
        }
    }
}
