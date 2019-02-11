// <copyright file="ScreensaverConfigurationBackgroundDrawableFactory.cs" company="natsnudasoft">
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
    using Natsnudasoft.EgamiFlowScreensaver.Config;
    using Natsnudasoft.NatsnudaLibrary;
    using SystemColor = System.Drawing.Color;

    /// <summary>
    /// Provides a class which will create instances of <see cref="BackgroundDrawable"/> based on a
    /// <see cref="ScreensaverConfiguration"/> retrieved from the specified
    /// <see cref="IServiceProvider"/>.
    /// </summary>
    /// <seealso cref="IBackgroundDrawableFactory" />
    public sealed class ScreensaverConfigurationBackgroundDrawableFactory :
        IBackgroundDrawableFactory
    {
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ScreensaverConfigurationBackgroundDrawableFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider for the currently running
        /// <see cref="Game"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="serviceProvider"/> is
        /// <see langword="null"/>.</exception>
        public ScreensaverConfigurationBackgroundDrawableFactory(
            IServiceProvider serviceProvider)
        {
            ParameterValidation.IsNotNull(serviceProvider, nameof(serviceProvider));

            this.serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/> is
        /// <see langword="null"/>.</exception>
        public BackgroundDrawable Create(ScreensaverArea screensaverArea)
        {
            ParameterValidation.IsNotNull(screensaverArea, nameof(screensaverArea));

            var configFileService = this.serviceProvider.GetService<IConfigurationFileService>();
            var screensaverConfiguration = configFileService.Open();
            BackgroundDrawable backgroundDrawable;
            switch (screensaverConfiguration.BackgroundMode)
            {
                case BackgroundMode.Desktop:
                    backgroundDrawable =
                        CreateDesktopBackgroundDrawable(this.serviceProvider, screensaverArea);
                    break;
                case BackgroundMode.Image:
                    backgroundDrawable = CreateImageBackgroundDrawable(
                        this.serviceProvider,
                        screensaverConfiguration,
                        screensaverArea);
                    break;
                case BackgroundMode.SolidColor:
                    backgroundDrawable = CreateSolidColorBackgroundDrawable(
                        screensaverConfiguration.BackgroundColor,
                        screensaverArea);
                    break;
                default:
                    backgroundDrawable = CreateSolidColorBackgroundDrawable(
                        SystemColor.SteelBlue,
                        screensaverArea);
                    break;
            }

            return backgroundDrawable;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "Object is handed to caller to dispose.")]
        private static BackgroundDrawable CreateDesktopBackgroundDrawable(
            IServiceProvider serviceProvider,
            ScreensaverArea screensaverArea)
        {
            var screenCaptureService = serviceProvider.GetService<IScreenCaptureService>();
            return new DesktopBackgroundDrawable(screenCaptureService, screensaverArea);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "Object is handed to caller to dispose.")]
        private static BackgroundDrawable CreateImageBackgroundDrawable(
            IServiceProvider serviceProvider,
            ScreensaverConfiguration screensaverConfiguration,
            ScreensaverArea screensaverArea)
        {
            var textureConverterService = serviceProvider.GetService<ITextureConverterService>();
            var imageScaleService = serviceProvider.GetService<IImageScaleService>();
            return new ImageBackgroundDrawable(
                screensaverConfiguration.BackgroundImage.ImageFilePath,
                textureConverterService,
                imageScaleService,
                screensaverConfiguration.BackgroundImageScaleMode,
                screensaverArea,
                screensaverConfiguration.BackgroundColor);
        }

        private static BackgroundDrawable CreateSolidColorBackgroundDrawable(
            SystemColor backgroundColor,
            ScreensaverArea screensaverArea)
        {
            return new SolidColorBackgroundDrawable(backgroundColor, screensaverArea);
        }
    }
}