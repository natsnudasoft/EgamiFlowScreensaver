// <copyright file="ConfigurationFormViewModel.cs" company="natsnudasoft">
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

namespace Natsnudasoft.EgamiFlowScreensaver.Config
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Security;
    using System.Windows.Forms;
    using Natsnudasoft.EgamiFlowScreensaver.Properties;
    using Natsnudasoft.NatsnudaLibrary;
    using NLog;
    using ProtoBuf;
    using static System.FormattableString;

    /// <summary>
    /// Provides a class for managing the state of the backing values for the current state of
    /// configuration for a <see cref="ScreensaverGame"/>.
    /// </summary>
    /// <seealso cref="ObservableBase" />
    /// <seealso cref="IDisposable" />
    public sealed class ConfigurationFormViewModel : ObservableBase, IDisposable
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        private readonly IConfigurationFileService configurationFileService;
        private readonly IConfigurationFilesTempCache configurationFilesTempCache;
        private readonly IBehaviorConfigurationFactory behaviorConfigurationFactory;
        private readonly IBehaviorConfigurationFormFactory behaviorConfigurationFormFactory;
        private readonly BindingList<ConfigurationImageItem> images;
        private int selectedImageIndex = -1;
        private Image selectedImagePreview;
        private BackgroundMode backgroundMode;
        private ImageScaleMode backgroundImageScaleMode;
        private float imageEmitRate;
        private int maxImageEmitCount;
        private ImageEmitLocation imageEmitLocation;
        private int customImageEmitLocationX;
        private int customImageEmitLocationY;
        private bool isInfiniteEmitMode;
        private double emitLifetime;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFormViewModel"/> class.
        /// </summary>
        /// <param name="configurationFileService">The configuration file service to use to
        /// perform operations in the configuration directory.</param>
        /// <param name="configurationFilesTempCache">The configuration files cache to use to
        /// cache configuration files before they are committed.</param>
        /// <param name="behaviorConfigurationFactory">The behaviour configuration factory to use
        /// to create instances of behaviour configurations based on a behaviour type.</param>
        /// <param name="behaviorConfigurationFormFactory">The behaviour configuration form factory
        /// to use to create instances of behaviour configuration forms based on a behaviour type.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="configurationFileService"/>,
        /// <paramref name="configurationFilesTempCache"/>,
        /// <paramref name="behaviorConfigurationFactory"/>, or
        /// <paramref name="behaviorConfigurationFormFactory"/> is <see langword="null"/>.
        /// </exception>
        public ConfigurationFormViewModel(
            IConfigurationFileService configurationFileService,
            IConfigurationFilesTempCache configurationFilesTempCache,
            IBehaviorConfigurationFactory behaviorConfigurationFactory,
            IBehaviorConfigurationFormFactory behaviorConfigurationFormFactory)
        {
            ParameterValidation.IsNotNull(
                configurationFileService,
                nameof(configurationFileService));
            ParameterValidation.IsNotNull(
                configurationFilesTempCache,
                nameof(configurationFilesTempCache));
            ParameterValidation.IsNotNull(
                behaviorConfigurationFactory,
                nameof(behaviorConfigurationFactory));
            ParameterValidation.IsNotNull(
                behaviorConfigurationFormFactory,
                nameof(behaviorConfigurationFormFactory));

            this.configurationFileService = configurationFileService;
            this.configurationFilesTempCache = configurationFilesTempCache;
            this.behaviorConfigurationFactory = behaviorConfigurationFactory;
            this.behaviorConfigurationFormFactory = behaviorConfigurationFormFactory;
            this.images = new BindingList<ConfigurationImageItem>
            {
                AllowNew = false,
                RaiseListChangedEvents = true
            };
            this.Behaviors = new List<ConfigurationBehavior>();
        }

        /// <summary>
        /// Gets the collection of image items as defined by the current configuration.
        /// </summary>
        public IBindingList Images => this.images;

        /// <summary>
        /// Gets or sets the index of the image item that is selected in the image items collection.
        /// </summary>
        public int SelectedImageIndex
        {
            get => this.selectedImageIndex;
            set
            {
                this.Set(ref this.selectedImageIndex, value);
                this.OnPropertyChanged(nameof(this.IsImageSelected));
                this.UpdateImagePreview();
            }
        }

        /// <summary>
        /// Gets a value indicating whether an image item is selected in the current image items
        /// collection.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if an image item is selected; otherwise, <see langword="false"/>.
        /// </value>
        public bool IsImageSelected
        {
            get => this.selectedImageIndex != -1;
        }

        /// <summary>
        /// Gets or sets the preview image of the currently selected image item.
        /// </summary>
        public Image SelectedImagePreview
        {
            get => this.selectedImagePreview;
            set => this.Set(ref this.selectedImagePreview, value);
        }

        /// <summary>
        /// Gets or sets the value of the background mode as defined by the current configuration.
        /// </summary>
        public BackgroundMode BackgroundMode
        {
            get => this.backgroundMode;
            set => this.Set(ref this.backgroundMode, value);
        }

        /// <summary>
        /// Gets or sets the rate that images will be emitted (per second) as defined by the current
        /// configuration.
        /// </summary>
        public float ImageEmitRate
        {
            get => this.imageEmitRate;
            set => this.Set(ref this.imageEmitRate, value);
        }

        /// <summary>
        /// Gets or sets the maximum number of images that will be emitted as defined by the current
        /// configuration.
        /// </summary>
        public int MaxImageEmitCount
        {
            get => this.maxImageEmitCount;
            set => this.Set(ref this.maxImageEmitCount, value);
        }

        /// <summary>
        /// Gets or sets the location that images will be emitted on the screen.
        /// </summary>
        public ImageEmitLocation ImageEmitLocation
        {
            get => this.imageEmitLocation;
            set
            {
                this.Set(ref this.imageEmitLocation, value);
                this.OnPropertyChanged(nameof(this.IsCustomImageEmitLocation));
            }
        }

        /// <summary>
        /// Gets a value indicating whether the location that images will be emitted is a custom
        /// value.
        /// </summary>
        public bool IsCustomImageEmitLocation
        {
            get => this.ImageEmitLocation == ImageEmitLocation.Custom;
        }

        /// <summary>
        /// Gets or sets the X coordinate of the emit location if it is in
        /// <see cref="ImageEmitLocation.Custom"/> mode.
        /// </summary>
        public int CustomImageEmitLocationX
        {
            get => this.customImageEmitLocationX;
            set => this.Set(ref this.customImageEmitLocationX, value);
        }

        /// <summary>
        /// Gets or sets the Y coordinate of the emit location if it is in
        /// <see cref="ImageEmitLocation.Custom"/> mode.
        /// </summary>
        public int CustomImageEmitLocationY
        {
            get => this.customImageEmitLocationY;
            set => this.Set(ref this.customImageEmitLocationY, value);
        }

        /// <summary>
        /// Gets the colour of the background of the screensaver if in
        /// <see cref="BackgroundMode.SolidColor"/> as defined by the current configuration.
        /// </summary>
        public Color BackgroundColor { get; private set; }

        /// <summary>
        /// Gets the background image of the screensaver if in <see cref="BackgroundMode.Image"/> as
        /// defined by the current configuration.
        /// </summary>
        public ConfigurationImageItem BackgroundImage { get; private set; }

        /// <summary>
        /// Gets or sets the background image scale mode describing how to scale the background as
        /// described by the current configuration.
        /// </summary>
        public ImageScaleMode BackgroundImageScaleMode
        {
            get => this.backgroundImageScaleMode;
            set => this.Set(ref this.backgroundImageScaleMode, value);
        }

        /// <summary>
        /// Gets a collection of configurations for behaviours that will be attached to any images
        /// emitted.
        /// </summary>
        public IList<ConfigurationBehavior> Behaviors { get; }

        /// <summary>
        /// Gets or sets a value indicating whether or not images will be emitted infinitely.
        /// </summary>
        /// <value><see langword="true"/> if images should be emitted infinitely; otherwise
        /// <see langword="false"/>.</value>
        public bool IsInfiniteImageEmitMode
        {
            get => this.isInfiniteEmitMode;
            set => this.Set(ref this.isInfiniteEmitMode, value);
        }

        /// <summary>
        /// Gets or sets the time that emitted images should live for (in milliseconds).
        /// </summary>
        /// <remarks>This setting is only used if <see cref="IsInfiniteImageEmitMode"/> is
        /// <see langword="true"/>.</remarks>
        public double ImageEmitLifetime
        {
            get => this.emitLifetime;
            set => this.Set(ref this.emitLifetime, value);
        }

        /// <summary>
        /// Displays a dialog allowing a new image to be added to the image item collection.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        public void AddImage(IWin32Window owner)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = Resources.ImageFileFilterString;
                openFileDialog.DefaultExt = ".png";
                if (openFileDialog.ShowDialog(owner) == DialogResult.OK)
                {
                    try
                    {
                        var imageItem = this.configurationFilesTempCache.AddScreensaverImage(
                            openFileDialog.FileName,
                            Path.GetFileName(openFileDialog.FileName));
                        var addedIndex = this.Images.Add(imageItem);
                        this.SelectedImageIndex = addedIndex;
                    }
                    catch (IOException ex)
                    {
                        ShowIOExceptionMessage(owner);
                        Logger.Error(ex, string.Empty);
                    }
                    catch (SecurityException ex)
                    {
                        ShowUnauthorizedAccessExceptionMessage(owner);
                        Logger.Error(ex, string.Empty);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        ShowUnauthorizedAccessExceptionMessage(owner);
                        Logger.Error(ex, string.Empty);
                    }
                    catch (TimeoutException ex)
                    {
                        ShowTimeoutExceptionMessage(owner);
                        Logger.Error(ex, string.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Removes the currently selected image item from the image item collection.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        public void RemoveSelectedImage(IWin32Window owner)
        {
            if (this.SelectedImageIndex >= 0 && this.SelectedImageIndex < this.Images.Count)
            {
                var selectedImage = this.images[this.SelectedImageIndex];
                try
                {
                    this.SelectedImagePreview?.Dispose();
                    this.configurationFilesTempCache
                        .RemoveScreensaverImage(selectedImage.ImageFilePath);
                    this.Images.RemoveAt(this.SelectedImageIndex);
                }
                catch (IOException ex)
                {
                    ShowIOExceptionMessage(owner);
                    Logger.Error(ex, string.Empty);
                }
                catch (UnauthorizedAccessException ex)
                {
                    ShowUnauthorizedAccessExceptionMessage(owner);
                    Logger.Error(ex, string.Empty);
                }
                catch (TimeoutException ex)
                {
                    ShowTimeoutExceptionMessage(owner);
                    Logger.Error(ex, string.Empty);
                }
            }
        }

        /// <summary>
        /// Displays a dialog allowing the colour of the background to be selected.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        public void ChooseBackgroundColor(IWin32Window owner)
        {
            using (var colorDialog = new ColorDialog())
            {
                colorDialog.AnyColor = true;
                colorDialog.FullOpen = true;
                colorDialog.Color = this.BackgroundColor;
                if (colorDialog.ShowDialog(owner) == DialogResult.OK)
                {
                    this.BackgroundColor = colorDialog.Color;
                }
            }
        }

        /// <summary>
        /// Displays a dialog allowing an image to chosen as the background.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        public void ChooseBackgroundImage(IWin32Window owner)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = Resources.ImageFileFilterString;
                openFileDialog.DefaultExt = ".png";
                if (openFileDialog.ShowDialog(owner) == DialogResult.OK)
                {
                    try
                    {
                        this.BackgroundImage = this.configurationFilesTempCache.SetBackgroundImage(
                            openFileDialog.FileName,
                            Path.GetFileName(openFileDialog.FileName));
                    }
                    catch (IOException ex)
                    {
                        ShowIOExceptionMessage(owner);
                        Logger.Error(ex, string.Empty);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        ShowUnauthorizedAccessExceptionMessage(owner);
                        Logger.Error(ex, string.Empty);
                    }
                    catch (TimeoutException ex)
                    {
                        ShowTimeoutExceptionMessage(owner);
                        Logger.Error(ex, string.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Displays a dialog allowing a custom emit location to be selected.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        public void ChooseCustomEmitLocation(IWin32Window owner)
        {
            var emitLocationViewModel = new CustomEmitLocationFormViewModel();
            using (var customEmitLocationDialog = new CustomEmitLocationForm(emitLocationViewModel))
            {
                emitLocationViewModel.CustomImageEmitLocationX = this.CustomImageEmitLocationX;
                emitLocationViewModel.CustomImageEmitLocationY = this.CustomImageEmitLocationY;
                if (customEmitLocationDialog.ShowDialog(owner) == DialogResult.OK)
                {
                    this.CustomImageEmitLocationX = emitLocationViewModel.CustomImageEmitLocationX;
                    this.CustomImageEmitLocationY = emitLocationViewModel.CustomImageEmitLocationY;
                }
            }
        }

        /// <summary>
        /// Displays a dialog allowing behaviours to be applied and configured for image items.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        public void ApplyBehaviors(IWin32Window owner)
        {
            var applyBehaviorsFormViewModel = new ApplyBehaviorsFormViewModel(
                this.Behaviors,
                this.behaviorConfigurationFactory,
                this.behaviorConfigurationFormFactory);
            using (var applyBehaviorsDialog = new ApplyBehaviorsForm(applyBehaviorsFormViewModel))
            {
                if (applyBehaviorsDialog.ShowDialog(owner) == DialogResult.OK)
                {
                    this.Behaviors.Clear();
                    applyBehaviorsFormViewModel.SynchronizeEnabledBehaviors();
                    foreach (var behavior in applyBehaviorsFormViewModel.Behaviors)
                    {
                        this.Behaviors.Add(behavior);
                    }
                }
            }
        }

        /// <summary>
        /// Reads the configuration from disk and synchronises the properties with this view model.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        /// <returns><see langword="true"/> if the settings were successfully read from disk;
        /// otherwise <see langword="false"/>.</returns>
        public bool ReadSettingsFromDisk(IWin32Window owner)
        {
            var result = false;
            try
            {
                var screensaverConfiguration = this.configurationFileService.Open();
                ConfigurationImageItem backgroundImage = null;
                var newBackgroundImageScaleMode = default(ImageScaleMode);
                if (screensaverConfiguration.BackgroundImage != null)
                {
                    backgroundImage = this.configurationFilesTempCache.SetBackgroundImage(
                        screensaverConfiguration.BackgroundImage.ImageFilePath,
                        screensaverConfiguration.BackgroundImage.OriginalFileName);
                    newBackgroundImageScaleMode = screensaverConfiguration.BackgroundImageScaleMode;
                }

                var screensaverImages = new List<ConfigurationImageItem>();
                foreach (var configurationImageItem in screensaverConfiguration.Images)
                {
                    var screensaverImage = this.configurationFilesTempCache.AddScreensaverImage(
                        configurationImageItem.ImageFilePath,
                        configurationImageItem.OriginalFileName);
                    screensaverImages.Add(screensaverImage);
                }

                this.BackgroundMode = screensaverConfiguration.BackgroundMode;
                this.BackgroundColor = screensaverConfiguration.BackgroundColor;
                this.BackgroundImage = backgroundImage;
                this.BackgroundImageScaleMode = newBackgroundImageScaleMode;
                this.ImageEmitRate = screensaverConfiguration.ImageEmitRate;
                this.MaxImageEmitCount = screensaverConfiguration.MaxImageEmitCount;
                this.ImageEmitLocation = screensaverConfiguration.ImageEmitLocation;
                this.CustomImageEmitLocationX = screensaverConfiguration.CustomImageEmitLocationX;
                this.CustomImageEmitLocationY = screensaverConfiguration.CustomImageEmitLocationY;
                this.IsInfiniteImageEmitMode = screensaverConfiguration.IsInfiniteImageEmitMode;
                this.ImageEmitLifetime =
                    screensaverConfiguration.ImageEmitLifetime.TotalMilliseconds;
                this.Images.Clear();
                foreach (var screensaverImage in screensaverImages)
                {
                    this.Images.Add(screensaverImage);
                }

                this.Behaviors.Clear();
                foreach (var behavior in screensaverConfiguration.Behaviors)
                {
                    this.Behaviors.Add(behavior);
                }

                result = true;
            }
            catch (IOException ex)
            {
                ShowIOExceptionMessage(owner);
                Logger.Error(ex, string.Empty);
            }
            catch (UnauthorizedAccessException ex)
            {
                ShowUnauthorizedAccessExceptionMessage(owner);
                Logger.Error(ex, string.Empty);
            }
            catch (TimeoutException ex)
            {
                ShowTimeoutExceptionMessage(owner);
                Logger.Error(ex, string.Empty);
            }
            catch (ProtoException ex)
            {
                ShowProtoExceptionMessage(owner);
                Logger.Error(ex, string.Empty);
            }

            return result;
        }

        /// <summary>
        /// Commits the relevant properties of this view model to the configuration file on disk.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        /// <returns><see langword="true"/> if the settings were successfully written to disk;
        /// otherwise <see langword="false"/>.</returns>
        public bool CommitSettingsToDisk(IWin32Window owner)
        {
            var result = false;
            var backgroundColor = default(Color);
            ConfigurationImageItem backgroundImage = null;
            var newBackgroundImageScaleMode = default(ImageScaleMode);
            switch (this.BackgroundMode)
            {
                case BackgroundMode.Image:
                    backgroundImage = this.configurationFileService
                        .CommitCachedBackgroundImage(this.BackgroundImage);
                    backgroundColor = this.BackgroundColor;
                    newBackgroundImageScaleMode = this.BackgroundImageScaleMode;
                    break;

                case BackgroundMode.SolidColor:
                    backgroundColor = this.BackgroundColor;
                    this.configurationFileService.DeleteOldBackgroundImages();
                    break;

                default:
                    this.configurationFileService.DeleteOldBackgroundImages();
                    break;
            }

            var screensaverConfiguration = new ScreensaverConfiguration
            {
                BackgroundMode = this.BackgroundMode,
                BackgroundColor = backgroundColor,
                BackgroundImage = backgroundImage,
                BackgroundImageScaleMode = newBackgroundImageScaleMode,
                ImageEmitRate = this.ImageEmitRate,
                MaxImageEmitCount = this.MaxImageEmitCount,
                ImageEmitLocation = this.ImageEmitLocation,
                CustomImageEmitLocationX = this.CustomImageEmitLocationX,
                CustomImageEmitLocationY = this.CustomImageEmitLocationY,
                IsInfiniteImageEmitMode = this.IsInfiniteImageEmitMode,
                ImageEmitLifetime =
                    new TimeSpan((long)(this.ImageEmitLifetime * TimeSpan.TicksPerMillisecond))
            };
            var committedImages = this.configurationFileService
                .CommitCachedScreensaverImages(this.images);
            foreach (var configurationImageItem in committedImages)
            {
                screensaverConfiguration.Images.Add(configurationImageItem);
            }

            foreach (var behavior in this.Behaviors)
            {
                screensaverConfiguration.Behaviors.Add(behavior);
            }

            try
            {
                this.configurationFileService.Save(screensaverConfiguration);
                result = true;
            }
            catch (IOException ex)
            {
                ShowIOExceptionMessage(owner);
                Logger.Error(ex, string.Empty);
            }
            catch (UnauthorizedAccessException ex)
            {
                ShowUnauthorizedAccessExceptionMessage(owner);
                Logger.Error(ex, string.Empty);
            }
            catch (TimeoutException ex)
            {
                ShowTimeoutExceptionMessage(owner);
                Logger.Error(ex, string.Empty);
            }

            return result;
        }

        /// <summary>
        /// Validates that the relevant properties of this view model contain valid values to commit
        /// to disk.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        /// <returns><see langword="true"/> if the view model is valid; otherwise
        /// <see langword="false"/>.</returns>
        public bool Validate(IWin32Window owner)
        {
            var validated = true;
            if (this.BackgroundMode == BackgroundMode.Image)
            {
                if (this.BackgroundImage == null)
                {
                    MessageBox.Show(
                        owner,
                        Resources.ChooseABackgroundImageText,
                        Resources.ChooseABackgroundImageCaption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    validated = false;
                }
            }

            return validated;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private static void ShowIOExceptionMessage(IWin32Window owner)
        {
            MessageBox.Show(
                owner,
                Resources.ConfigurationIOExceptionMessage,
                Resources.ConfigurationIOExceptionCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private static void ShowUnauthorizedAccessExceptionMessage(IWin32Window owner)
        {
            MessageBox.Show(
                owner,
                Resources.ConfigurationUnauthorisedAccessExceptionMessage,
                Resources.ConfigurationUnauthorisedAccessExceptionCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private static void ShowTimeoutExceptionMessage(IWin32Window owner)
        {
            MessageBox.Show(
                owner,
                Resources.ConfigurationTimeoutExceptionMessage,
                Resources.ConfigurationTimeoutExceptionCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private static void ShowProtoExceptionMessage(IWin32Window owner)
        {
            MessageBox.Show(
                owner,
                Resources.ConfigurationProtoExceptionMessage,
                Resources.ConfigurationProtoExceptionCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.selectedImagePreview?.Dispose();
            }

            this.configurationFilesTempCache.Clear();
        }

        private void UpdateImagePreview()
        {
            this.SelectedImagePreview?.Dispose();
            if (this.SelectedImageIndex >= 0 && this.SelectedImageIndex < this.Images.Count)
            {
                var filePath = this.images[this.SelectedImageIndex].ImageFilePath;
                try
                {
                    this.SelectedImagePreview = Image.FromFile(filePath);
                }
                catch (FileNotFoundException ex)
                {
                    Logger.Warn(ex, Invariant($"Could not load preview image from '{filePath}'."));
                    this.SelectedImagePreview = null;
                }
                catch (OutOfMemoryException ex)
                {
                    Logger.Warn(ex, Invariant($"Unsupported preview image from '{filePath}'."));
                    this.SelectedImagePreview = null;
                }
            }
            else
            {
                this.SelectedImagePreview = null;
            }
        }
    }
}