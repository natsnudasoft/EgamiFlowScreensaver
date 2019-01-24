// <copyright file="IScreensaverService.cs" company="natsnudasoft">
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

    /// <summary>
    /// Provides an interface describing operations to manage running a
    /// <see cref="ScreensaverGame"/>.
    /// </summary>
    public interface IScreensaverService
    {
        /// <summary>
        /// Attaches the window of a <see cref="ScreensaverGame"/> to the specified preview window
        /// on a screensaver settings screen.
        /// </summary>
        /// <param name="gameWindowHandle">A handle to the game window.</param>
        /// <param name="previewWindowHandle">A handle to the preview window on a screensaver
        /// settings screen.</param>
        /// <returns>A <see cref="Rectangle"/> describing the bounds of the preview window that the
        /// game window was attached to.
        /// </returns>
        Rectangle AttachGameWindowToPreviewWindow(
            IntPtr gameWindowHandle,
            IntPtr previewWindowHandle);
    }
}