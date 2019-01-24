﻿// <copyright file="GameCompositionRoot.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.EgamiFlowScreensaver.Config;

    /// <summary>
    /// The composition root of the <see cref="ScreensaverGame"/>.
    /// </summary>
    public static class GameCompositionRoot
    {
        /// <summary>
        /// Composes game services and adds them to the specified
        /// <see cref="GameServiceContainer"/>.
        /// </summary>
        /// <param name="gameServiceContainer">The <see cref="GameServiceContainer"/> to add
        /// composed services to.</param>
        public static void Compose(GameServiceContainer gameServiceContainer)
        {
            var graphicsDeviceService = gameServiceContainer.GetService<IGraphicsDeviceService>();

            var nativeMethods = new NativeMethods();
            gameServiceContainer.AddService<INativeMethods>(nativeMethods);

            var screensaverService = new ScreensaverService(nativeMethods);
            gameServiceContainer.AddService<IScreensaverService>(screensaverService);

            var textureConverterService = new TextureConverterService(graphicsDeviceService);
            gameServiceContainer.AddService<ITextureConverterService>(textureConverterService);

            var screenCaptureService = new ScreenCaptureService(textureConverterService);
            gameServiceContainer.AddService<IScreenCaptureService>(screenCaptureService);

            var configurationFileService = new ConfigurationFileService();
            gameServiceContainer.AddService<IConfigurationFileService>(configurationFileService);

            var backgroundDrawableManager = new BackgroundDrawableManager(gameServiceContainer);
            gameServiceContainer.AddService<IBackgroundDrawableManager>(backgroundDrawableManager);

            var imageScaleService = new ImageScaleService();
            gameServiceContainer.AddService<IImageScaleService>(imageScaleService);
        }
    }
}