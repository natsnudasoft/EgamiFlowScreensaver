// <copyright file="ScreensaverImageEmitterCounter.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Provides a class to manage the rate that images should be emitted by a
    /// <see cref="ScreensaverImageEmitter"/>.
    /// </summary>
    public sealed class ScreensaverImageEmitterCounter
    {
        private readonly float particleRateInverse;
        private float elapsed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverImageEmitterCounter"/> class.
        /// </summary>
        /// <param name="emitRate">The number of images that will be emitted per second by a
        /// <see cref="ScreensaverImageEmitter"/> using this
        /// <see cref="ScreensaverImageEmitterCounter"/>.</param>
        public ScreensaverImageEmitterCounter(float emitRate)
        {
            this.EmitRate = emitRate;
            this.particleRateInverse = 1f / emitRate;
        }

        /// <summary>
        /// Gets the number of images that will be emitted per second by a
        /// <see cref="ScreensaverImageEmitter"/> using this
        /// <see cref="ScreensaverImageEmitterCounter"/>.
        /// </summary>
        public float EmitRate { get; }

        /// <summary>
        /// Updates the state of this <see cref="ScreensaverImageEmitterCounter"/> and retrieves the
        /// number of images to emit.
        /// </summary>
        /// <param name="gameTime">A snapshot of the current game time.</param>
        /// <returns>The number of images that should be emitted.</returns>
        public int UpdateEmit(GameTime gameTime)
        {
            var emitCount = 0;
            this.elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (this.elapsed > this.particleRateInverse)
            {
                ++emitCount;
                this.elapsed -= this.particleRateInverse;
            }

            return emitCount;
        }
    }
}