// <copyright file="BackgroundDrawableManager.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class to manage a <see cref="BackgroundDrawable"/> that will be created by a
    /// specified <see cref="IBackgroundDrawableFactory"/>.
    /// </summary>
    /// <seealso cref="IBackgroundDrawableManager"/>
    /// <seealso cref="IDisposable"/>
    public sealed class BackgroundDrawableManager : IBackgroundDrawableManager, IDisposable
    {
        private readonly IBackgroundDrawableFactory backgroundDrawableFactory;
        private BackgroundDrawable backgroundDrawable;

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundDrawableManager"/> class.
        /// </summary>
        /// <param name="backgroundDrawableFactory">The factory to use to provide instances of
        /// <see cref="BackgroundDrawable"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="backgroundDrawableFactory"/> is
        /// <see langword="null"/>.</exception>
        public BackgroundDrawableManager(IBackgroundDrawableFactory backgroundDrawableFactory)
        {
            ParameterValidation.IsNotNull(
                backgroundDrawableFactory,
                nameof(backgroundDrawableFactory));

            this.backgroundDrawableFactory = backgroundDrawableFactory;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/> is
        /// <see langword="null"/>.</exception>
        public void Initialize(ScreensaverArea screensaverArea)
        {
            ParameterValidation.IsNotNull(screensaverArea, nameof(screensaverArea));

            this.backgroundDrawable = this.backgroundDrawableFactory.Create(screensaverArea);
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="graphicsDevice"/> is
        /// <see langword="null"/>.</exception>
        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            ParameterValidation.IsNotNull(graphicsDevice, nameof(graphicsDevice));

            this.CheckInitialized();
            this.backgroundDrawable.LoadContent(graphicsDevice);
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="graphicsDevice"/> is
        /// <see langword="null"/>.</exception>
        public void BeforeDraw(GraphicsDevice graphicsDevice)
        {
            ParameterValidation.IsNotNull(graphicsDevice, nameof(graphicsDevice));

            this.CheckInitialized();
            this.backgroundDrawable.BeforeDraw(graphicsDevice);
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="spriteBatch"/> is
        /// <see langword="null"/>.</exception>
        public void Draw(SpriteBatch spriteBatch)
        {
            ParameterValidation.IsNotNull(spriteBatch, nameof(spriteBatch));

            this.CheckInitialized();
            this.backgroundDrawable.Draw(spriteBatch);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Naming",
            "CA2204:Literals should be spelled correctly",
            MessageId = nameof(BackgroundDrawableManager),
            Justification = "Exception message describing name of class.")]
        private void CheckInitialized()
        {
            if (this.backgroundDrawable == null)
            {
                throw new InvalidOperationException(
                    "The " + nameof(BackgroundDrawableManager) + " has not been initialized.");
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                (this.backgroundDrawable as IDisposable)?.Dispose();
            }
        }
    }
}