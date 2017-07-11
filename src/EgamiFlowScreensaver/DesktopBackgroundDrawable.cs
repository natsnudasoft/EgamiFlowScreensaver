﻿// <copyright file="DesktopBackgroundDrawable.cs" company="natsnudasoft">
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
    /// Provides a class which will draw a captured image of the desktop as a
    /// <see cref="ScreensaverGame"/> background.
    /// </summary>
    /// <seealso cref="BackgroundDrawable" />
    /// <seealso cref="IDisposable" />
    public sealed class DesktopBackgroundDrawable : BackgroundDrawable, IDisposable
    {
        private readonly IScreenCaptureService screenCaptureService;
        private Texture2D desktopTexture;

        /// <summary>
        /// Initializes a new instance of the <see cref="DesktopBackgroundDrawable"/> class.
        /// </summary>
        /// <param name="screenCaptureService">The screen capture service.</param>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        public DesktopBackgroundDrawable(
            IScreenCaptureService screenCaptureService,
            ScreensaverArea screensaverArea)
            : base(screensaverArea)
        {
            ParameterValidation.IsNotNull(screenCaptureService, nameof(screenCaptureService));

            this.screenCaptureService = screenCaptureService;
        }

        /// <inheritdoc/>
        public override void LoadContent(GraphicsDevice graphicsDevice)
        {
            var screensaverBounds = this.ScreensaverArea.ScreensaverBounds.ToSystemRectangle();
            this.desktopTexture = this.screenCaptureService.CaptureScreenshotTexture(
                screensaverBounds.Location,
                screensaverBounds.Size);
        }

        /// <inheritdoc/>
        public override void Draw(SpriteBatch spriteBatch)
        {
            var screensaverGameBounds = this.ScreensaverArea.ScreensaverGameBounds;
            spriteBatch.Draw(this.desktopTexture, screensaverGameBounds, Color.White);
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
                this.desktopTexture?.Dispose();
            }
        }
    }
}
