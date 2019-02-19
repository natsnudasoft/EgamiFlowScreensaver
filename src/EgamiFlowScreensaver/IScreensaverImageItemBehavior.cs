// <copyright file="IScreensaverImageItemBehavior.cs" company="natsnudasoft">
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
    /// Provides an interface that encapsulates methods available to behaviours that can be composed
    /// and applied to a <see cref="ScreensaverImageItem"/>.
    /// </summary>
    public interface IScreensaverImageItemBehavior
    {
        /// <summary>
        /// Performs any initialization steps required by this
        /// <see cref="IScreensaverImageItemBehavior"/> that will be applied to the specified
        /// <see cref="ScreensaverImageItem"/>.
        /// </summary>
        /// <param name="screensaverImageItem">The <see cref="ScreensaverImageItem"/> that is having
        /// this behaviour initialized.</param>
        void Initialize(ScreensaverImageItem screensaverImageItem);

        /// <summary>
        /// Performs any update steps required by this <see cref="IScreensaverImageItemBehavior"/>
        /// that will be applied to the specified <see cref="ScreensaverImageItem"/>.
        /// </summary>
        /// <param name="screensaverImageItem">The <see cref="ScreensaverImageItem"/> that is having
        /// this behaviour updated.</param>
        /// <param name="gameTime">A snapshot of the current game time.</param>
        void Update(ScreensaverImageItem screensaverImageItem, GameTime gameTime);
    }
}