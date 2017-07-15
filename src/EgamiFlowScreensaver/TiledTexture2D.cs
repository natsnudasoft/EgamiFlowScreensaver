// <copyright file="TiledTexture2D.cs" company="natsnudasoft">
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
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Represents a collection of tiled instances of <see cref="Texture2D"/> to encapsulate an
    /// image of an arbitrary size.
    /// </summary>
    public class TiledTexture2D : IDisposable
    {
        private readonly TiledTexture2DSegment[] tiledTextureSegments;

        /// <summary>
        /// Initializes a new instance of the <see cref="TiledTexture2D"/> class.
        /// </summary>
        /// <param name="tiledTextureSegments">The individual tiled texture segments of an image of
        /// an arbitrary size.</param>
        /// <param name="width">The width of the overall image; i.e. the width of all of the
        /// segments combined.</param>
        /// <param name="height">The height of the overall image; i.e. the height of all of the
        /// segments combined.</param>
        public TiledTexture2D(
            IEnumerable<TiledTexture2DSegment> tiledTextureSegments,
            int width,
            int height)
        {
            ParameterValidation.IsNotNull(tiledTextureSegments, nameof(tiledTextureSegments));

            this.tiledTextureSegments = tiledTextureSegments.ToArray();
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets the individual tiled texture segments that make up this
        /// <see cref="TiledTexture2D"/>.
        /// </summary>
        public IEnumerable<TiledTexture2DSegment> TiledTextureSegments => this.tiledTextureSegments;

        /// <summary>
        /// Gets the width of the overall image; i.e. the width of all of the segments combined.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the height of the overall image; i.e. the height of all of the segments combined.
        /// </summary>
        public int Height { get; }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var tiledTextureSegment in this.tiledTextureSegments)
                {
                    tiledTextureSegment?.Dispose();
                }
            }
        }
    }
}
