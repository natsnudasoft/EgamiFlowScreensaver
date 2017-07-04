// <copyright file="ScreenCaptureService.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.NatsnudaLibrary;
    using CopyPixelOperation = System.Drawing.CopyPixelOperation;
    using PixelFormat = System.Drawing.Imaging.PixelFormat;
    using SystemBitmap = System.Drawing.Bitmap;
    using SystemGraphics = System.Drawing.Graphics;
    using SystemPoint = System.Drawing.Point;
    using SystemSize = System.Drawing.Size;

    /// <summary>
    /// Provides a class capable of capturing the screen as an image.
    /// </summary>
    /// <seealso cref="IScreenCaptureService" />
    public class ScreenCaptureService : IScreenCaptureService
    {
        private readonly ITextureConverterService textureConverterService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenCaptureService" /> class.
        /// </summary>
        /// <param name="textureConverterService">The texture converter service to use to for
        /// converting captured images to a <see cref="Texture2D"/>.</param>
        public ScreenCaptureService(ITextureConverterService textureConverterService)
        {
            ParameterValidation.IsNotNull(textureConverterService, nameof(textureConverterService));

            this.textureConverterService = textureConverterService;
        }

        /// <inheritdoc/>
        public Texture2D CaptureScreenshotTexture(
            SystemPoint captureLocation,
            SystemSize captureSize)
        {
            using (var bitmap = new SystemBitmap(
                captureSize.Width,
                captureSize.Height,
                PixelFormat.Format32bppArgb))
            {
                using (var graphics = SystemGraphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(
                        captureLocation,
                        SystemPoint.Empty,
                        captureSize,
                        CopyPixelOperation.SourceCopy);
                }

                return this.textureConverterService.FromBitmap(bitmap);
            }
        }
    }
}
