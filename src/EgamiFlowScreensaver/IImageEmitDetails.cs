// <copyright file="IImageEmitDetails.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Provides an interface describing the capability of creating image items for a
    /// <see cref="ScreensaverImageEmitter" />.
    /// </summary>
    /// <seealso cref="ScreensaverImageItem"/>
    public interface IImageEmitDetails
    {
        /// <summary>
        /// Gets the rate that images should be emitted by a <see cref="ScreensaverImageEmitter"/>.
        /// </summary>
        float ImageEmitRate { get; }

        /// <summary>
        /// Gets the maximum number of images that should be emitted by a
        /// <see cref="ScreensaverImageEmitter" />.
        /// </summary>
        int MaxImageEmitCount { get; }

        /// <summary>
        /// Creates a <see cref="ScreensaverImageItem"/> based on the parameters of this
        /// <see cref="IImageEmitDetails"/>.
        /// </summary>
        /// <param name="texture">The texture details describing the parameters of the image that an
        /// emit location is being created for.</param>
        /// <returns>The <see cref="ScreensaverImageItem"/> that was created.</returns>
        ScreensaverImageItem CreateScreensaverImageItem(Texture2D texture);
    }
}