// <copyright file="AlphaChangeScreensaverImageItemBehavior.cs" company="natsnudasoft">
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
    /// one alpha value to another over a specified time frame.
    /// </summary>
    /// <seealso cref="TransitionScreensaverImageItemBehavior"/>
    public sealed class AlphaChangeScreensaverImageItemBehavior :
        TransitionScreensaverImageItemBehavior
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlphaChangeScreensaverImageItemBehavior"/>
        /// class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="startAlpha">The alpha value that the image item this behaviour is applied
        /// to will start at. This value can be out of range to delay the start of the transition.
        /// </param>
        /// <param name="endAlpha">The alpha value that the image item this behaviour is applied to
        /// will finish at. This value can be out of range to advance to the end of the transition
        /// faster.</param>
        /// <param name="transitionTime">The time the image item this behaviour is applied to will
        /// take to transition between the specified alpha values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/> is
        /// <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="transitionTime"/> is less
        /// than a zero time.</exception>
        public AlphaChangeScreensaverImageItemBehavior(
            ScreensaverArea screensaverArea,
            float startAlpha,
            float endAlpha,
            TimeSpan transitionTime)
            : base(
                screensaverArea,
                transitionTime,
                (s, p) => s.Alpha =
                    MathHelper.Clamp(MathHelper.Lerp(startAlpha, endAlpha, p), 0f, 1f))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlphaChangeScreensaverImageItemBehavior"/>
        /// class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="startAlpha">The alpha value that the image item this behaviour is applied
        /// to will start at. This value can be out of range to delay the start of the transition.
        /// </param>
        /// <param name="endAlpha">The alpha value that the image item this behaviour is applied to
        /// will finish at. This value can be out of range to advance to the end of the transition
        /// faster.</param>
        /// <param name="transitionTime">The time the image item this behaviour is applied to will
        /// take to transition between the specified alpha values.</param>
        /// <param name="endTransitionAlpha">The alpha value that the image item this behaviour is
        /// applied to will finish at when it is being destroyed (starting from
        /// <paramref name="endAlpha"/>).</param>
        /// <param name="endTransitionTime">The time the image item this behaviour is applied to
        /// will take to transition when it is being destroyed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/> is
        /// <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="transitionTime"/>, or
        /// <paramref name="endTransitionTime"/> is less than a zero time.</exception>
        public AlphaChangeScreensaverImageItemBehavior(
            ScreensaverArea screensaverArea,
            float startAlpha,
            float endAlpha,
            TimeSpan transitionTime,
            float endTransitionAlpha,
            TimeSpan endTransitionTime)
            : base(
                screensaverArea,
                transitionTime,
                (s, p) => s.Alpha =
                    MathHelper.Clamp(MathHelper.Lerp(startAlpha, endAlpha, p), 0f, 1f),
                endTransitionTime,
                (s, p) => s.Alpha =
                    MathHelper.Clamp(MathHelper.Lerp(endAlpha, endTransitionAlpha, p), 0f, 1f))
        {
        }
    }
}