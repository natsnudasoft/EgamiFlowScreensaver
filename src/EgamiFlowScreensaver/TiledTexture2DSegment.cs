// <copyright file="TiledTexture2DSegment.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Represents a segment of a larger image.
    /// </summary>
    public sealed class TiledTexture2DSegment : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TiledTexture2DSegment"/> class.
        /// </summary>
        /// <param name="segmentTexture">The texture of this segment as part of a larger image.
        /// </param>
        /// <param name="segmentArea">The area of this segment in relation to the larger image the
        /// segment is part of.</param>
        /// <exception cref="ArgumentNullException"><paramref name="segmentTexture"/> is
        /// <see langword="null"/>.</exception>
        public TiledTexture2DSegment(
            Texture2D segmentTexture,
            Rectangle segmentArea)
        {
            ParameterValidation.IsNotNull(segmentTexture, nameof(segmentTexture));

            this.SegmentTexture = segmentTexture;
            this.SegmentArea = segmentArea;
        }

        /// <summary>
        /// Gets the texture of this segment.
        /// </summary>
        public Texture2D SegmentTexture { get; }

        /// <summary>
        /// Gets the area of this segment in relation to the larger image the segment is part of.
        /// </summary>
        public Rectangle SegmentArea { get; }

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
                this.SegmentTexture.Dispose();
            }
        }
    }
}
