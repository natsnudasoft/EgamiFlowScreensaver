// <copyright file="RectangleExtensions.cs" company="natsnudasoft">
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
    using SystemRectangle = System.Drawing.Rectangle;

    /// <summary>
    /// Provides extensions for methods that relate to the <see cref="Rectangle"/> class.
    /// </summary>
    public static class RectangleExtensions
    {
        /// <summary>
        /// Creates a new <see cref="Rectangle"/> from the specified <see cref="SystemRectangle"/>.
        /// </summary>
        /// <param name="systemRectangle">The <see cref="SystemRectangle"/> to convert.</param>
        /// <returns>The converted <see cref="Rectangle"/>.</returns>
        public static Rectangle ToGameRectangle(this SystemRectangle systemRectangle)
        {
            return new Rectangle(
                systemRectangle.X,
                systemRectangle.Y,
                systemRectangle.Width,
                systemRectangle.Height);
        }

        /// <summary>
        /// Creates a new <see cref="SystemRectangle"/> from the specified <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="rectangle">The <see cref="Rectangle"/> to convert.</param>
        /// <returns>The converted <see cref="SystemRectangle"/>.</returns>
        public static SystemRectangle ToSystemRectangle(this Rectangle rectangle)
        {
            return new SystemRectangle(
                rectangle.X,
                rectangle.Y,
                rectangle.Width,
                rectangle.Height);
        }
    }
}