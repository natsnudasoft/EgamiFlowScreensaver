// <copyright file="IScreenCaptureService.cs" company="natsnudasoft">
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
    using SystemPoint = System.Drawing.Point;
    using SystemSize = System.Drawing.Size;

    /// <summary>
    /// Provides an interface describing methods for capturing the screen as an image.
    /// </summary>
    public interface IScreenCaptureService
    {
        /// <summary>
        /// Captures the desktop as an image and converts it to a <see cref="TiledTexture2D"/>.
        /// </summary>
        /// <param name="captureLocation">The location on the desktop of the screenshot to capture.
        /// </param>
        /// <param name="captureSize">The size of the screenshot to capture.</param>
        /// <returns>A <see cref="TiledTexture2D"/> of the desktop image that was captured.
        /// </returns>
        TiledTexture2D CaptureScreenshotTexture(
            SystemPoint captureLocation,
            SystemSize captureSize);
    }
}