// <copyright file="RandomExtensions.cs" company="natsnudasoft">
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

    /// <summary>
    /// Provides extensions to the <see cref="Random"/> class.
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns a random <see cref="float"/> between 0.0 and 1.0.
        /// </summary>
        /// <param name="random">The pseudo random-number generator to use to generate the random
        /// value.</param>
        /// <returns>The <see cref="float"/> that was randomly generated.</returns>
        public static float NextFloat(this Random random)
        {
            return (float)random.NextDouble();
        }

        /// <summary>
        /// Returns a random <see cref="float" /> between 0.0 and the specified maximum value.
        /// </summary>
        /// <param name="random">The pseudo random-number generator to use to generate the random
        /// value.</param>
        /// <param name="maxValue">The maximum value to randomly generate.</param>
        /// <returns> The <see cref="float" /> that was randomly generated.</returns>
        public static float NextFloat(this Random random, float maxValue)
        {
            return random.NextFloat(0f, maxValue);
        }

        /// <summary>
        /// Returns a random <see cref="float" /> between the specified minimum and the specified
        /// maximum value.
        /// </summary>
        /// <param name="random">The pseudo random-number generator to use to generate the random
        /// value.</param>
        /// <param name="minValue">The minimum value to randomly generate.</param>
        /// <param name="maxValue">The maximum value to randomly generate.</param>
        /// <returns> The <see cref="float" /> that was randomly generated.</returns>
        public static float NextFloat(this Random random, float minValue, float maxValue)
        {
            var range = (double)maxValue - minValue;
            var sample = random.NextDouble();
            var scaled = (sample * range) + minValue;
            return (float)scaled;
        }
    }
}
