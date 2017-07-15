// <copyright file="IImageScaleService.cs" company="natsnudasoft">
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
    using System.Drawing;

    /// <summary>
    /// Provides an interface describing methods for performing scaling of images.
    /// </summary>
    public interface IImageScaleService
    {
        /// <summary>
        /// Scales the specified image to the specified size using the specified
        /// <see cref="ImageScaleMode"/>.
        /// </summary>
        /// <param name="image">The original image to scale.</param>
        /// <param name="scaleSize">The area that the image is being scaled to.</param>
        /// <param name="imageScaleMode">The image scale mode to use.</param>
        /// <returns>A <see cref="Bitmap"/> of the scaled image.</returns>
        Bitmap ScaleImage(Image image, Size scaleSize, ImageScaleMode imageScaleMode);
    }
}