// <copyright file="ScreensaverImageItemBehavior.cs" company="natsnudasoft">
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
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides an abstract base class for behaviours that can be composed and applied to a
    /// <see cref="ScreensaverImageItem"/>.
    /// </summary>
    public abstract class ScreensaverImageItemBehavior : IScreensaverImageItemBehavior
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverImageItemBehavior "/> class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/> is
        /// <see langword="null"/>.</exception>
        protected ScreensaverImageItemBehavior(ScreensaverArea screensaverArea)
        {
            ParameterValidation.IsNotNull(screensaverArea, nameof(screensaverArea));

            this.ScreensaverArea = screensaverArea;
        }

        /// <inheritdoc/>
        public bool IsFinished { get; protected set; }

        /// <inheritdoc/>
        public virtual bool BlocksDestroy
        {
            get => false;
        }

        /// <summary>
        /// Gets the description of the area of the screensaver.
        /// </summary>
        protected ScreensaverArea ScreensaverArea { get; }

        /// <inheritdoc/>
        public abstract void Initialize(ScreensaverImageItem screensaverImageItem);

        /// <inheritdoc/>
        public abstract void Update(ScreensaverImageItem screensaverImageItem, GameTime gameTime);
    }
}