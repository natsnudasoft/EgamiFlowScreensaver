// <copyright file="BackgroundDrawableManager.cs" company="natsnudasoft">
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
    using Natsnudasoft.EgamiFlowScreensaver.Config;
    using Natsnudasoft.NatsnudaLibrary;
    using SystemColor = System.Drawing.Color;

    /// <summary>
    /// Provides a class to manage a <see cref="BackgroundDrawable"/> based on a specified
    /// <see cref="ScreensaverConfiguration"/>.
    /// </summary>
    public sealed class BackgroundDrawableManager : IBackgroundDrawableManager, IDisposable
    {
        private readonly IServiceProvider serviceProvider;
        private BackgroundDrawable backgroundDrawable;

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundDrawableManager"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider for the currently running
        /// <see cref="Game"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="serviceProvider"/> is
        /// <see langword="null"/>.</exception>
        public BackgroundDrawableManager(IServiceProvider serviceProvider)
        {
            ParameterValidation.IsNotNull(serviceProvider, nameof(serviceProvider));

            this.serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public void Initialize(
            ScreensaverConfiguration screensaverConfiguration,
            ScreensaverArea screensaverArea)
        {
            switch (screensaverConfiguration.BackgroundMode)
            {
                case BackgroundMode.Desktop:
                    var screenCaptureService =
                        this.serviceProvider.GetService<IScreenCaptureService>();
                    this.backgroundDrawable = new DesktopBackgroundDrawable(
                        screenCaptureService,
                        screensaverArea);
                    break;
                case BackgroundMode.Image:
                    var textureConverterService =
                        this.serviceProvider.GetService<ITextureConverterService>();
                    this.backgroundDrawable = new ImageBackgroundDrawbale(
                        screensaverConfiguration.BackgroundImage.ImageFilePath,
                        textureConverterService,
                        screensaverArea);
                    break;
                case BackgroundMode.SolidColor:
                    this.backgroundDrawable = new SolidColorBackgroundDrawable(
                        screensaverConfiguration.BackgroundColor,
                        screensaverArea);
                    break;
                default:
                    this.backgroundDrawable = new SolidColorBackgroundDrawable(
                        SystemColor.SteelBlue,
                        screensaverArea);
                    break;
            }
        }

        /// <inheritdoc/>
        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            this.CheckInitialized();
            this.backgroundDrawable.LoadContent(graphicsDevice);
        }

        /// <inheritdoc/>
        public void BeforeDraw(GraphicsDevice graphicsDevice)
        {
            this.CheckInitialized();
            this.backgroundDrawable.BeforeDraw(graphicsDevice);
        }

        /// <inheritdoc/>
        public void Draw(SpriteBatch spriteBatch)
        {
            this.CheckInitialized();
            this.backgroundDrawable.Draw(spriteBatch);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void CheckInitialized()
        {
            if (this.backgroundDrawable == null)
            {
                throw new InvalidOperationException(
                    "The " + nameof(BackgroundDrawableManager) + " has not been initialized.");
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                (this.backgroundDrawable as IDisposable)?.Dispose();
            }
        }
    }
}
