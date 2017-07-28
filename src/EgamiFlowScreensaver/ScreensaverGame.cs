// <copyright file="ScreensaverGame.cs" company="natsnudasoft">
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
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Natsnudasoft.EgamiFlowScreensaver.Config;
    using Properties;
    using SystemBitmap = System.Drawing.Bitmap;
    using SystemControl = System.Windows.Forms.Control;
    using SystemForm = System.Windows.Forms.Form;
    using SystemInformation = System.Windows.Forms.SystemInformation;
    using SystemRectangle = System.Drawing.Rectangle;
    using SystemScreen = System.Windows.Forms.Screen;

    /// <summary>
    /// Uses the MonoGame <see cref="Game"/> class to run a screensaver.
    /// </summary>
    public class ScreensaverGame : Game
    {
        private const string DefaultTextureName = "adie";
        private readonly List<Texture2D> screensaverTextures;
        private readonly GraphicsDeviceManager graphics;
        private readonly IntPtr previewWindowHandle;
        private ScreensaverConfiguration screensaverConfiguration;
        private SpriteBatch spriteBatch;
        private RenderTarget2D renderTarget;
        private ScreensaverArea screensaverArea;
        private MouseState previousMouseState;
        private KeyboardState previousKeyboardState;
        private IBackgroundDrawableManager backgroundDrawableManager;
        private ScreensaverImageManager screensaverImageManager;
        private ScreensaverImageEmitter screensaverImageEmitter;
        private int ignoreInputFrameCount = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverGame"/> class.
        /// </summary>
        public ScreensaverGame()
        {
            this.screensaverTextures = new List<Texture2D>();
            this.IsFixedTimeStep = true;
            this.graphics = new GraphicsDeviceManager(this);
            this.Content = new AssemblyContentManager(
                typeof(ScreensaverGame).Assembly,
                this.Services,
                "Content");
            this.Window.IsBorderless = true;
            this.Window.Title = Resources.WindowTitle;
            var form = (SystemForm)SystemControl.FromHandle(this.Window.Handle);
            form.ShowInTaskbar = false;
#if !DEBUG
            form.TopMost = true;
#endif
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverGame" /> class.
        /// </summary>
        /// <param name="previewWindowHandle">The handle to the preview window in the screensaver
        /// dialog.</param>
        public ScreensaverGame(
            IntPtr previewWindowHandle)
            : this()
        {
            this.previewWindowHandle = previewWindowHandle;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ScreensaverGame"/> is in preview mode.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if this <see cref="ScreensaverGame"/> is in preview mode;
        /// otherwise, <see langword="false"/>.
        /// </value>
        public bool IsPreviewMode => this.previewWindowHandle != IntPtr.Zero;

        /// <inheritdoc/>
        protected override void Initialize()
        {
            GameCompositionRoot.Compose(this.Services);
            var configFileService = this.Services.GetService<IConfigurationFileService>();
            this.screensaverConfiguration = configFileService.Open();
            this.InitializeScreensaverMode();
            this.backgroundDrawableManager = this.Services.GetService<IBackgroundDrawableManager>();
            this.backgroundDrawableManager.Initialize(
                this.screensaverConfiguration,
                this.screensaverArea);
            this.screensaverImageManager = new ScreensaverImageManager(this.screensaverArea);
            this.InitializeImages();
            this.screensaverImageEmitter = new ScreensaverImageEmitter(
                new ScreensaverImageEmitterCounter(this.screensaverConfiguration.ImageEmitRate),
                this.screensaverArea,
                this.screensaverImageManager,
                this.screensaverTextures,
                this.screensaverConfiguration.MaxImageEmitCount,
                this.screensaverConfiguration.ImageEmitLocation);
            this.screensaverImageEmitter.Start();
            base.Initialize();
        }

        /// <inheritdoc/>
        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.backgroundDrawableManager.LoadContent(this.GraphicsDevice);
        }

        /// <inheritdoc/>
        protected override void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            var keyboardState = Keyboard.GetState();
            if (--this.ignoreInputFrameCount >= 0)
            {
                this.previousMouseState = mouseState;
                this.previousKeyboardState = keyboardState;
            }

            var keyboardStateChanged = keyboardState != this.previousKeyboardState;
#if DEBUG
            if (keyboardStateChanged)
            {
                this.Exit();
            }
#else
            var mouseStateChanged = mouseState != this.previousMouseState;
            if (!this.IsPreviewMode && (keyboardStateChanged || mouseStateChanged))
            {
                this.Exit();
            }
#endif
            this.screensaverImageManager.Update();
            this.screensaverImageEmitter.Update(gameTime);

            this.previousMouseState = mouseState;
            this.previousKeyboardState = keyboardState;
            base.Update(gameTime);
        }

        /// <inheritdoc/>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.SteelBlue);

            this.GraphicsDevice.SetRenderTarget(this.renderTarget);
            this.backgroundDrawableManager.BeforeDraw(this.GraphicsDevice);
            this.spriteBatch.Begin();
            this.backgroundDrawableManager.Draw(this.spriteBatch);
            this.screensaverImageManager.Draw(this.spriteBatch);
            this.spriteBatch.End();

            this.GraphicsDevice.SetRenderTarget(null);
            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.renderTarget, Vector2.Zero, Color.White);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.spriteBatch?.Dispose();
                this.graphics?.Dispose();
                this.renderTarget?.Dispose();
                foreach (var screensaverImage in this?.screensaverTextures)
                {
                    screensaverImage?.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        private void InitializeScreensaverMode()
        {
            var screensaverService = this.Services.GetService<IScreensaverService>();
            var primaryScreenBounds = SystemScreen.PrimaryScreen.Bounds;
            if (this.IsPreviewMode)
            {
                this.IsMouseVisible = true;
                this.UpdateScreensaverRenderSize(primaryScreenBounds);
                screensaverService
                    .AttachGameWindowToPreviewWindow(this.Window.Handle, this.previewWindowHandle);
                this.screensaverArea = new ScreensaverArea(
                    primaryScreenBounds,
                    primaryScreenBounds);
            }
            else
            {
                var virtualScreenBounds = SystemInformation.VirtualScreen;
                this.Window.Position = new Point(virtualScreenBounds.X, virtualScreenBounds.Y);
                this.UpdateScreensaverRenderSize(virtualScreenBounds);
                this.screensaverArea = new ScreensaverArea(
                    virtualScreenBounds,
                    primaryScreenBounds);
            }
        }

        private void InitializeImages()
        {
            if (this.screensaverConfiguration.Images.Count == 0)
            {
                var defaultTexture = this.Content.Load<Texture2D>(DefaultTextureName);
                this.screensaverTextures.Add(defaultTexture);
            }
            else
            {
                var textureConverterService = this.Services.GetService<ITextureConverterService>();
                foreach (var imageItem in this.screensaverConfiguration.Images)
                {
                    using (var bitmap = new SystemBitmap(imageItem.ImageFilePath))
                    {
                        this.screensaverTextures.Add(textureConverterService.FromBitmap(bitmap));
                    }
                }
            }
        }

        private void UpdateScreensaverRenderSize(SystemRectangle renderBounds)
        {
            this.renderTarget = new RenderTarget2D(
                this.GraphicsDevice,
                renderBounds.Width,
                renderBounds.Height);
            this.graphics.PreferredBackBufferWidth = renderBounds.Width;
            this.graphics.PreferredBackBufferHeight = renderBounds.Height;
            this.graphics.ApplyChanges();
        }
    }
}
