// <copyright file="ITextureConverterService.cs" company="natsnudasoft">
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
    using SystemBitmap = System.Drawing.Bitmap;

    /// <summary>
    /// Provides an interface describing methods for converting to and from textures.
    /// </summary>
    public interface ITextureConverterService
    {
        /// <summary>
        /// Creates a <see cref="Texture2D"/> from the specified <see cref="SystemBitmap"/>.
        /// </summary>
        /// <param name="bitmap">The <see cref="SystemBitmap"/> to convert from.</param>
        /// <returns>The converted bitmap as a <see cref="Texture2D"/>.</returns>
        Texture2D FromBitmap(SystemBitmap bitmap);
    }
}