// <copyright file="ScaleChangeScreensaverImageItemBehavior.cs" company="natsnudasoft">
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

    /// <summary>
    /// Provides a behaviour to apply to an image item that causes the image item to transition from
    /// one scale to another over a specified time frame.
    /// </summary>
    /// <seealso cref="TransitionScreensaverImageItemBehavior"/>
    public sealed class ScaleChangeScreensaverImageItemBehavior :
        TransitionScreensaverImageItemBehavior
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScaleChangeScreensaverImageItemBehavior"/>
        /// class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="startScale">The scale that the image item this behaviour is applied to will
        /// start at. This value can have components out of range to delay the start of the
        /// transition.</param>
        /// <param name="endScale">The scale that the image item this behaviour is applied to will
        /// finish at. This value can have components out of range to advance the end of the
        /// transition.</param>
        /// <param name="transitionTime">The time the image item this behaviour is applied to will
        /// take to transition between the specified scales.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/> is
        /// <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="transitionTime"/> is less
        /// than a zero time.</exception>
        public ScaleChangeScreensaverImageItemBehavior(
            ScreensaverArea screensaverArea,
            Vector2 startScale,
            Vector2 endScale,
            TimeSpan transitionTime)
            : base(
                screensaverArea,
                transitionTime,
                (s, p) => s.Scale =
                    Vector2.Max(Vector2.Lerp(startScale, endScale, p), Vector2.Zero))
        {
        }
    }
}