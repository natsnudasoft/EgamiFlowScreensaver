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
    using System.Runtime.InteropServices;
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.NatsnudaLibrary;
    using ImageLockMode = System.Drawing.Imaging.ImageLockMode;
    using PixelFormat = System.Drawing.Imaging.PixelFormat;
    using SystemBitmap = System.Drawing.Bitmap;
    using SystemRectangle = System.Drawing.Rectangle;

    /// <summary>
    /// Provides methods for converting to and from textures.
    /// </summary>
    /// <seealso cref="ITextureConverterService" />
    public class TextureConverterService : ITextureConverterService
    {
        private readonly IGraphicsDeviceService graphicsDeviceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextureConverterService"/> class.
        /// </summary>
        /// <param name="graphicsDeviceService">The graphics device service to use to help create
        /// instances of <see cref="Texture2D"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="graphicsDeviceService"/> is
        /// <see langword="null"/>.</exception>
        public TextureConverterService(IGraphicsDeviceService graphicsDeviceService)
        {
            ParameterValidation.IsNotNull(graphicsDeviceService, nameof(graphicsDeviceService));

            this.graphicsDeviceService = graphicsDeviceService;
        }

        /// <inheritdoc/>
        /// <exception cref="Exception">The operation failed for an unknown reason.</exception>
        public Texture2D FromBitmap(SystemBitmap bitmap)
        {
            var texture = new Texture2D(
                this.graphicsDeviceService.GraphicsDevice,
                bitmap.Width,
                bitmap.Height,
                false,
                SurfaceFormat.Bgra32);
            var data = bitmap.LockBits(
                new SystemRectangle(0, 0, bitmap.Width, bitmap.Height),
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
