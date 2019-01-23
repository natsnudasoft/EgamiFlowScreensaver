// <copyright file="ScreensaverService.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class with operations to manage running a <see cref="ScreensaverGame"/>.
    /// </summary>
    /// <seealso cref="IScreensaverService" />
    public sealed class ScreensaverService : IScreensaverService
    {
        private readonly INativeMethods nativeMethods;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverService"/> class.
        /// </summary>
        /// <param name="nativeMethods">The native methods service to be used by this service.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="nativeMethods"/> is
        /// <see langword="null"/>.</exception>
        public ScreensaverService(INativeMethods nativeMethods)
        {
            ParameterValidation.IsNotNull(nativeMethods, nameof(nativeMethods));

            this.nativeMethods = nativeMethods;
        }

        /// <inheritdoc/>
        public Rectangle AttachGameWindowToPreviewWindow(
            IntPtr gameWindowHandle,
            IntPtr previewWindowHandle)
        {
            var previewArea = this.nativeMethods.GetClientRect(previewWindowHandle);
            this.nativeMethods.SetParent(gameWindowHandle, previewWindowHandle);
            this.nativeMethods.SetWindowLongPtr(
                new HandleRef(this, gameWindowHandle),
                (int)WindowLongFlags.GWL_STYLE,
                new IntPtr(NativeConstants.WS_CHILD));
            this.nativeMethods.MoveWindow(
                gameWindowHandle,
                previewArea.X,
                previewArea.Y,
                previewArea.Width,
                previewArea.Height,
                false);
            return new Rectangle(
                previewArea.X,
                previewArea.Y,
                previewArea.Width,
                previewArea.Height);
        }
    }
}