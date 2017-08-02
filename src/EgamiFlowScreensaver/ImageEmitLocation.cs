// <copyright file="ImageEmitLocation.cs" company="natsnudasoft">
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
    /// Represents values that describe the location that images will be emitted on a screensaver.
    /// </summary>
    public enum ImageEmitLocation
    {
        /// <summary>
        /// Images should be emitted from a random corner of the primary screen.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageEmitLocationRandomCorner")]
        RandomCorner,

        /// <summary>
        /// Images should be emitted from the bottom left of the primary screen.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageEmitLocationBottomLeft")]
        BottomLeft,

        /// <summary>
        /// Images should be emitted from the top left of the primary screen.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageEmitLocationTopLeft")]
        TopLeft,

        /// <summary>
        /// Images should be emitted from the top right of the primary screen.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageEmitLocationTopRight")]
        TopRight,

        /// <summary>
        /// Images should be emitted from the bottom right of the primary screen.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageEmitLocationBottomRight")]
        BottomRight,

        /// <summary>
        /// Images should be emitted from the centre of the primary screen.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageEmitLocationCenter")]
        Center,

        /// <summary>
        /// Images should be emitted from random locations on the primary screen.
        /// </summary>
        [EnumResourceDisplayName(typeof(Resources), "ImageEmitLocationRandom")]
        Random
    }
}
