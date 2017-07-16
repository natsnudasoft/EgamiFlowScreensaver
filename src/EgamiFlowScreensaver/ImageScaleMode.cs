// <copyright file="ImageScaleMode.cs" company="natsnudasoft">
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
    using Properties;

    /// <summary>
    /// Represents values that describe how to scale and position an image on a drawing area.
    /// </summary>
    public enum ImageScaleMode
    {
        /// <summary>
        /// The image should not be scaled and remain centred on the drawing area.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageScaleModeCenter")]
        Center,

        /// <summary>
        /// The image should scale either up or down to the minimum possible size required to fill
        /// the entire drawing area, maintaining original aspect ratio.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageScaleModeFill")]
        Fill,

        /// <summary>
        /// The image should scale either up or down to the maximum possible size required to
        /// display the entire image on the drawing area, maintaining original aspect ratio.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageScaleModeFit")]
        Fit,

        /// <summary>
        /// The image should scale either up or down to the same size as the drawing area, ignoring
        /// original aspect ratio.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageScaleModeStretch")]
        Stretch,

        /// <summary>
        /// The image should not be scaled and, starting from the top left of the drawing area will
        /// be repeated as necessary until the entire drawing area is filled.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageScaleModeTile")]
        Tile
    }
}
